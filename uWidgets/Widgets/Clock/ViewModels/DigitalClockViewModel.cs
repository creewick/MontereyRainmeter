using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Threading;
using Shared.Interfaces;

namespace Clock.ViewModels;

public class DigitalClockViewModel : INotifyPropertyChanged
{
    public DateTime Time { get; set; }
    public string TimeString => Time.ToString(GetTimeFormat(), CultureInfo.InvariantCulture);
    public Visibility SecondsVisibility => clockSettings.ShowSeconds ? Visibility.Visible : Visibility.Collapsed;
    
    private ClockSettings clockSettings;
    private readonly DispatcherTimer timer;
    public event PropertyChangedEventHandler? PropertyChanged;

    public DigitalClockViewModel(IAppSettingsProvider appSettingsProvider, IWidgetSettingsProvider widgetSettingsProvider)
    {
        clockSettings = (ClockSettings) widgetSettingsProvider.Get();

        widgetSettingsProvider.Updated += (_, widgetSettings) =>
        {
            clockSettings = (ClockSettings)widgetSettings;
            Update();
        };
        
        appSettingsProvider.Updated += (_, _) =>
        {
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
            return TimeSpan.FromSeconds(1d / 10);
        
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

    protected virtual void Update() => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
}