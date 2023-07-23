using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;
using Shared.Interfaces;

namespace Clock.ViewModels;

public class AnalogClockViewModel : INotifyPropertyChanged
{
    public DateTime Time { get; set; }
    public double SecondsAngle => (Time.Second + Time.Millisecond / 1000.0) * 6;
    public double MinutesAngle => (Time.Minute + Time.Second / 60.0) * 6;
    public double HoursAngle => (Time.Hour + Time.Minute / 60.0) * 30;
    public Visibility SecondsVisibility => clockSettings.ShowSeconds ? Visibility.Visible : Visibility.Collapsed;
    
    private ClockSettings clockSettings;
    private readonly DispatcherTimer timer;
    public event PropertyChangedEventHandler? PropertyChanged;

    public AnalogClockViewModel(IAppSettingsProvider appSettingsProvider, IWidgetSettingsProvider widgetSettingsProvider)
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

    protected virtual void Update() => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
}