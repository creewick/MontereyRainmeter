using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Threading;
using Shared.Interfaces;
using Shared.Models;
using Shared.Services;

namespace Calendar.ViewModels;

public class TodayCalendarViewModel : INotifyPropertyChanged
{
    private readonly DispatcherTimer timer;
    private AppSettings appSettings;
    private CultureInfo cultureInfo;
    
    public event PropertyChangedEventHandler? PropertyChanged;
    public string DayOfMonth => Time.Day.ToString();
    public string DayOfWeekShort => cultureInfo.DateTimeFormat.GetAbbreviatedDayName(Time.DayOfWeek).Replace(".", "").Capitalize();
    public string MonthShort => cultureInfo.DateTimeFormat.GetAbbreviatedMonthName(Time.Month).Capitalize();
    public DateTime Time { get; set; }
    
    public TodayCalendarViewModel(IAppSettingsProvider appSettingsProvider)
    {
        appSettings = appSettingsProvider.Get();
        cultureInfo = new CultureInfo(appSettings.Region.Language);

        appSettingsProvider.Updated += (_, newAppSettings) =>
        {
            appSettings = newAppSettings;
            cultureInfo = new CultureInfo(appSettings.Region.Language);
            Update();
        };
        
        timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
        timer.Tick += (_, _) =>
        {
            Time = DateTime.Now;
            Update();
        };
        timer.Start();
    }

    protected virtual void Update() => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
}
