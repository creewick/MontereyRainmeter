using System;
using System.Globalization;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using uWidgets.Models;

namespace uWidgets.Widgets;

public partial class Clock : Widget
{
    public Clock(WidgetLayout layout, Settings settings, Locale locale) 
        : base(layout, settings, locale)
    {
        InitializeComponent();
        
        var clockSettings = layout.Settings.Deserialize<ClockSettings>() ?? throw new FormatException(nameof(ClockSettings));

        ((UIElement)(clockSettings.Analog ? AnalogClock : DigitalClock)).Visibility = Visibility.Visible;

        var timer = new DispatcherTimer();
        timer.Interval = TimeSpan.FromMilliseconds(100);
        timer.Tick += (_,_) => OnTick(settings, clockSettings);
        timer.Start();

        SizeChanged += (_, _) =>
        {
            var small = Math.Min(Width, Height) < 100;
            Strokes.Visibility = small ? Visibility.Hidden : Visibility.Visible;
            Seconds.Visibility = clockSettings.ShowSeconds ? Visibility.Visible : Visibility.Hidden;
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
        };
        
        Show();
    }

    private void OnTick(Settings settings, ClockSettings clockSettings)
    {
        var now = DateTime.Now;
        
        if (clockSettings.Analog)
        {
            Seconds.RenderTransform = new RotateTransform((now.Second + now.Millisecond / 1000.0) * 6, 500, 500);
            Minutes.RenderTransform = new RotateTransform((now.Minute + now.Second / 60.0) * 6, 500, 500);
            Hours.RenderTransform = new RotateTransform((now.Hour + now.Minute / 60.0) * 30, 500, 500);
        }
        else
        {
            var hours = clockSettings.ShowAMPM ? "hh" : "HH";
            var seconds = clockSettings.ShowSeconds ? ":ss" : "";
            var ampm = clockSettings.ShowAMPM ? " tt" : "";
            
            Time.Text = now.ToString($"{hours}:mm{seconds}{ampm}");
            Date.Text = now.ToString("dddd, d MMMM", new CultureInfo(settings.Region.Language));
        }
    }
}