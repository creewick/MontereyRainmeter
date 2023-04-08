using System;
using System.Globalization;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using uWidgets.Models;

namespace uWidgets.Widgets;

public partial class Clock
{
    public ClockSettings ClockSettings;
    
    public Clock(WidgetLayout layout, Settings settings, LocaleStrings localeStrings) 
        : base(layout, settings, localeStrings)
    {
        InitializeComponent();
        
        ClockSettings = layout.Settings.Deserialize<ClockSettings>() 
                        ?? throw new FormatException(nameof(ClockSettings));

        if (ClockSettings.Analog)
            AnalogClock.Visibility = Visibility.Visible;
        else
            DigitalClock.Visibility = Visibility.Visible;

        var timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(100) };
        timer.Tick += OnTick;
        timer.Start();

        SizeChanged += OnSizeChanged;
        
        Show();
    }

    private void OnSizeChanged(object sender, SizeChangedEventArgs e)
    {
        var small = Math.Min(Width, Height) < 100;
        Strokes.Visibility = small ? Visibility.Hidden : Visibility.Visible;
        Seconds.Visibility = ClockSettings.ShowSeconds ? Visibility.Visible : Visibility.Hidden;
        Numbers.RenderTransform = small ? new ScaleTransform(1.1, 1.1, 500, 500) : new ScaleTransform();
        foreach (TextBlock number in Numbers.Children)
        {
            number.FontFamily = (FontFamily)Application.Current.Resources[small ? "SfProLight" : "SfProMedium"];
        }
            
        DataContext = new ClockViewModel
        {
            SecondHandThickness = Math.Min(Width, Height) > 100 ? 7 : 12,
            AnalogPadding = Math.Min(Width, Height) * 0.07,
            DigitalPadding = Math.Min(Width, Height) * 0.15,
        };
    }
    
    private void OnTick(object? sender, EventArgs e)
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

            var date = now.ToString(DateTimeFormat.Date, new CultureInfo(Settings.Region.Language));
            date = char.ToUpper(date[0]) + date[1..];
            
            Time.Text = now.ToString($"{hours}{minutes}{seconds}{ampm}");
            Date.Text = date;
        }
    }
}