using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using uWidgets.Configuration.Interfaces;
using uWidgets.Configuration.Models;
using uWidgets.UserInterface.Models;

namespace uWidgets.Widgets.Clock;

public partial class Clock
{
    private ClockSettings clockSettings;
    private DispatcherTimer timer;

    public Clock(ISettingsManager settingsManager, ILayoutManager layoutManager, ILocaleManager localeManager, Guid id)
        : base(settingsManager, layoutManager, localeManager, id)
    {
        InitializeComponent();
        OnSettingsChanged();
        OnSizeChanged();
        OnTick();

        SizeChanged += (_, _) => OnSizeChanged();
        MouseDoubleClick += (_,_) => Process.Start("explorer.exe", @"shell:AppsFolder\Microsoft.WindowsAlarms_8wekyb3d8bbwe!App");
        
        Show();
    }

    private void OnSizeChanged()
    {
        var widgetSize = SettingsManager.Get().WidgetSize;
        var small = Math.Min(Width, Height) <= widgetSize;
        
        Strokes.Visibility = small ? Visibility.Hidden : Visibility.Visible;
        Date.Visibility = small ? Visibility.Hidden : Visibility.Visible;

        DigitalClock.RowDefinitions[0].Height = new GridLength(Height <= widgetSize ? 0 : 1, GridUnitType.Star);
        DigitalClockTimeViewbox.VerticalAlignment = Height <= widgetSize ? VerticalAlignment.Center : VerticalAlignment.Top;

        Numbers.RenderTransform = small ? new ScaleTransform(1.1, 1.1, 500, 500) : new ScaleTransform();
        
        foreach (TextBlock number in Numbers.Children)
        {
            number.FontFamily = (FontFamily)Application.Current.Resources[small ? "SfProLight" : "SfProMedium"];
        }

        foreach (Path secondHandPath in Seconds.Children)
        {
            secondHandPath.StrokeThickness = small ? 12 : 7;
        }

        AnalogClock.Margin = new Thickness(Math.Min(Width, Height) * 0.07);
        DigitalClock.Margin = new Thickness(Math.Min(Width, Height) * 0.15);
    }

    private void OnSettingsChanged()
    {
        clockSettings = LayoutManager.Get(Id).Settings?.Deserialize<ClockSettings>() 
                        ?? throw new FormatException(nameof(clockSettings));

        AnalogClock.Visibility = clockSettings.Analog ? Visibility.Visible : Visibility.Collapsed;
        DigitalClock.Visibility = clockSettings.Analog ? Visibility.Collapsed : Visibility.Visible;
        Seconds.Visibility = clockSettings.ShowSeconds ? Visibility.Visible : Visibility.Hidden;
        
        var timerInterval = clockSettings.Analog
            ? clockSettings.ShowSeconds ? TimeSpan.FromSeconds(0.1) : TimeSpan.FromSeconds(5)
            : TimeSpan.FromSeconds(1);

        if (timer?.Interval != timerInterval)
        {
            timer?.Stop();
            timer = new DispatcherTimer { Interval = timerInterval };
            timer.Tick += (_,_) => OnTick();
            timer.Start();
        }
    }
    
    private void OnTick()
    {
        var now = DateTime.Now;
        var settings = SettingsManager.Get();
        var cultureInfo = new CultureInfo(settings.Region.Language);
        var smallWidth = Width <= settings.WidgetSize * 2 + settings.WidgetPadding;
        
        if (clockSettings.Analog)
        {
            Seconds.RenderTransform = new RotateTransform((now.Second + now.Millisecond / 1000.0) * 6, 500, 500);
            Minutes.RenderTransform = new RotateTransform((now.Minute + now.Second / 60.0) * 6, 500, 500);
            Hours.RenderTransform = new RotateTransform((now.Hour + now.Minute / 60.0) * 30, 500, 500);
        }
        else
        {
            var hours = clockSettings.ShowAMPM ? DateTimeFormat.Hours12 : DateTimeFormat.Hours24;
            var minutes = DateTimeFormat.Minutes;
            var seconds = clockSettings.ShowSeconds ? DateTimeFormat.Seconds : string.Empty;
            var ampm = clockSettings.ShowAMPM ? DateTimeFormat.AMPM : string.Empty;
            var date = smallWidth ? DateTimeFormat.Date : DateTimeFormat.DateShort;

            Time.Text = now.ToString($"{hours}{minutes}{seconds}{ampm}");
            Date.Text = Capitalize(now.ToString(date, cultureInfo));
        }
    }

    private static string Capitalize(string text) => char.ToUpper(text[0]) + text[1..];
}