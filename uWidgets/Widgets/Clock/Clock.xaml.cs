using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using uWidgets.Infrastructure.Files;
using uWidgets.Infrastructure.Models;
using uWidgets.Utilities;

namespace uWidgets.Widgets.Clock;

public partial class Clock
{
    public ClockSettings ClockSettings;

    public Clock(
        IFileHandler<AppSettings> settingsManager, 
        IFileHandler<List<WidgetLayout>> layoutManager, 
        IFileHandler<AppLocale> localeManager, 
        Guid id)
        : base(settingsManager, layoutManager, localeManager, id)
    {
        InitializeComponent();
        
        ClockSettings = layoutManager.Get().First(x => x.Id == Id).Settings?.Deserialize<ClockSettings>() 
                        ?? throw new FormatException(nameof(ClockSettings));

        if (ClockSettings.Analog)
            AnalogClock.Visibility = Visibility.Visible;
        else
            DigitalClock.Visibility = Visibility.Visible;

        var timer = new DispatcherTimer
        {
            Interval = ClockSettings.Analog
                ? ClockSettings.ShowSeconds ? TimeSpan.FromSeconds(0.1) : TimeSpan.FromSeconds(5)
                : TimeSpan.FromSeconds(1)
        };
        timer.Tick += OnTick;
        timer.Start();
        OnTick(null, null);

        SizeChanged += OnSizeChanged;
        MouseDoubleClick += (_,_) => Process.Start("explorer.exe", @"shell:AppsFolder\Microsoft.WindowsAlarms_8wekyb3d8bbwe!App");

        Show();
    }

    private void OnSizeChanged(object sender, SizeChangedEventArgs e)
    {
        var widgetSize = SettingsManager.Get().WidgetSize;
        var small = Math.Min(Width, Height) <= widgetSize;
        Strokes.Visibility = small ? Visibility.Hidden : Visibility.Visible;
        Seconds.Visibility = ClockSettings.ShowSeconds ? Visibility.Visible : Visibility.Hidden;
        Date.Visibility = small ? Visibility.Hidden : Visibility.Visible;

        DigitalClock.RowDefinitions[0].Height = Height <= widgetSize
            ? new GridLength(0) 
            : new GridLength(1, GridUnitType.Star);

        (DigitalClock.Children[1] as Viewbox).VerticalAlignment = Height <= widgetSize
            ? VerticalAlignment.Center
            : VerticalAlignment.Top;

        Numbers.RenderTransform = small ? new ScaleTransform(1.1, 1.1, 500, 500) : new ScaleTransform();
        foreach (TextBlock number in Numbers.Children)
        {
            number.FontFamily = (FontFamily)System.Windows.Application.Current.Resources[small ? "SfProLight" : "SfProMedium"];
        }
            
        DataContext = new ClockViewModel
        {
            SecondHandThickness = small ? 12 : 7,
            AnalogPadding = Math.Min(Width, Height) * 0.07,
            DigitalPadding = Math.Min(Width, Height) * 0.15,
        };
    }
    
    private void OnTick(object? sender, EventArgs? e)
    {
        var now = DateTime.Now;
        
        if (ClockSettings.Analog)
        {
            Seconds.RenderTransform = new RotateTransform((now.Second + now.Millisecond / 1000.0) * 6, 500, 500);
            Minutes.RenderTransform = new RotateTransform((now.Minute + now.Second / 60.0) * 6, 500, 500);
            Hours.RenderTransform = new RotateTransform((now.Hour + now.Minute / 60.0) * 30, 500, 500);
        }
        else
        {
            var hours = ClockSettings.ShowAMPM 
                ? DateTimeFormat.Hours12 
                : DateTimeFormat.Hours24;
            var minutes = DateTimeFormat.Minutes;
            var seconds = ClockSettings.ShowSeconds 
                ? DateTimeFormat.Seconds 
                : string.Empty;
            var ampm = ClockSettings.ShowAMPM 
                ? DateTimeFormat.AMPM 
                : string.Empty;
            
            Time.Text = now.ToString($"{hours}{minutes}{seconds}{ampm}");

            var settings = SettingsManager.Get();
            var medium = Width <= settings.WidgetSize * 2 + settings.WidgetPadding;

            if (medium)
            {
                Date.Text = now.ToString(DateTimeFormat.DateShort, new CultureInfo(settings.Region.Language));
            }
            else
            {
                var date = now.ToString(DateTimeFormat.Date, new CultureInfo(settings.Region.Language));
                Date.Text = char.ToUpper(date[0]) + date[1..];
            }
        }
    }
}