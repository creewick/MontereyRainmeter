using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Threading;
using Shared.Interfaces;
using Shared.Models;

namespace Clock.Models;

public class ClockViewModel : INotifyPropertyChanged
{
    public double WorldClockMargin => appSettings.WidgetSize * 0.05;
    public DateTime Time { get; set; }
    public double SecondsAngle => (Time.Second + Time.Millisecond / 1000.0) * 6;
    public double MinutesAngle => (Time.Minute + Time.Second / 60.0) * 6;
    public double HoursAngle => (Time.Hour + Time.Minute / 60.0) * 30;
    public string TimeString => Time.ToString(GetTimeFormat(), CultureInfo.InvariantCulture);
    public Visibility SecondsVisibility => clockSettings.ShowSeconds ? Visibility.Visible : Visibility.Collapsed;
    
    private ClockSettings clockSettings;
    private AppSettings appSettings;
    private readonly DispatcherTimer timer;

    public ClockViewModel(IAppSettingsProvider appSettingsProvider, IWidgetSettingsProvider widgetSettingsProvider)
    {
        clockSettings = (ClockSettings) widgetSettingsProvider.Get();
        appSettings = appSettingsProvider.Get();

        widgetSettingsProvider.Updated += (_, widgetSettings) =>
        {
            clockSettings = (ClockSettings)widgetSettings;
            Update();
        };
        
        appSettingsProvider.Updated += (_, newAppSettings) =>
        {
            appSettings = newAppSettings;
            Update();
        };

        timer = new DispatcherTimer { Interval = GetTimerInterval() };
        timer.Tick += (_, _) =>
        {
            Time = DateTime.Now;
            Update();
        };
        timer.Start();
    }

    private TimeSpan GetTimerInterval()
    {
        if (clockSettings.Subtype == "DigitalClock")
            return TimeSpan.FromSeconds(1);

        if (clockSettings.ShowSeconds)
            return TimeSpan.FromSeconds(1d / 60);
        
        return TimeSpan.FromSeconds(1);
    }

    private string GetTimeFormat()
    {
        var hours = clockSettings.ShowAmPm ? "hh" : "HH";
        var minutes = ":mm";
        var seconds = clockSettings.ShowSeconds ? ":ss" : "";
        var amPm = clockSettings.ShowAmPm ? " tt" : "";
        
        return $"{hours}{minutes}{seconds}{amPm}";
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void Update()
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
    }
}