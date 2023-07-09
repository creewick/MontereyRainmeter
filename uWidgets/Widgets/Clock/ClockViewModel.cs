using System;
using System.Globalization;
using System.Windows;
using System.Windows.Threading;
using PropertyChanged;
using uWidgets.Settings.Models;

namespace uWidgets.Widgets.Clock;

[AddINotifyPropertyChangedInterface]
public class ClockViewModel
{
    public double Margin => appSettings.WidgetSize * 0.1;
    public double WorldClockMargin => appSettings.WidgetSize * 0.05;
    public DateTime Time { get; set; }
    public double SecondsAngle => (Time.Second + Time.Millisecond / 1000.0) * 6;
    public double MinutesAngle => (Time.Minute + Time.Second / 60.0) * 6;
    public double HoursAngle => (Time.Hour + Time.Minute / 60.0) * 30;
    public string TimeString => Time.ToString(GetTimeFormat(), CultureInfo.InvariantCulture);
    public Visibility SecondsVisibility => clockSettings.ShowSeconds ? Visibility.Visible : Visibility.Collapsed;
    public Visibility AnalogIClock => clockSettings.Subtype == "AnalogIClock" ? Visibility.Visible : Visibility.Collapsed;
    public Visibility AnalogIIClock => clockSettings.Subtype == "AnalogIIClock" ? Visibility.Visible : Visibility.Collapsed;
    public Visibility AnalogIIIClock => clockSettings.Subtype == "AnalogIIIClock" ? Visibility.Visible : Visibility.Collapsed;
    public Visibility DigitalClock => clockSettings.Subtype == "DigitalClock" ? Visibility.Visible : Visibility.Collapsed;
    public Visibility WorldClock => clockSettings.Subtype == "WorldClock" ? Visibility.Visible : Visibility.Collapsed;
    
    private readonly AppSettings appSettings;
    private readonly ClockSettings clockSettings;
    private readonly DispatcherTimer timer;
    
    public ClockViewModel(AppSettings appSettings, ClockSettings clockSettings)
    {
        this.appSettings = appSettings;
        this.clockSettings = clockSettings;
        
        timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1.0/60) };
        timer.Tick += (_, _) => { Time = DateTime.Now; };
        timer.Start();
    }

    private string GetTimeFormat()
    {
        var hours = clockSettings.ShowAmPm ? "hh" : "HH";
        var minutes = ":mm";
        var seconds = clockSettings.ShowSeconds ? ":ss" : "";
        var amPm = clockSettings.ShowAmPm ? " tt" : "";
        
        return $"{hours}{minutes}{seconds}{amPm}";
    }
}