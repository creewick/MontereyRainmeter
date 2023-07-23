using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Threading;
using Shared.Interfaces;
using Shared.Models;

namespace Calendar.ViewModels;

public class MonthCalendarViewModel : INotifyPropertyChanged
{
    private readonly DispatcherTimer timer;
    private AppSettings appSettings;
    private CultureInfo cultureInfo;
    
    public event PropertyChangedEventHandler? PropertyChanged;
    public double Margin => appSettings.WidgetSize * 0.05;
    public string Month => cultureInfo.DateTimeFormat.GetMonthName(Time.Month).ToUpper();
    public IEnumerable<MonthViewCellViewModel> MonthCalendarCells => GetDaysOfWeek().Concat(GetEmptyCells()).Concat(GetDaysOfMonth());
    public GridLength MonthCalendarRows => new(Math.Ceiling(MonthCalendarCells.Count() / 7d), GridUnitType.Star);
    public DateTime Time { get; set; }
    
    public MonthCalendarViewModel(IAppSettingsProvider appSettingsProvider)
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

    public IEnumerable<MonthViewCellViewModel> GetDaysOfWeek()
    {
        return Enum.GetValues<DayOfWeek>().Select(dayOfWeek => new MonthViewCellViewModel
        {
            Text = cultureInfo.DateTimeFormat.GetShortestDayName(dayOfWeek),
            Opacity = IsWeekend(dayOfWeek) ? 0.5 : 1,
        });
    }

    public IEnumerable<MonthViewCellViewModel> GetDaysOfMonth()
    {
        var days = DateTime.DaysInMonth(Time.Year, Time.Month);
        return Enumerable.Range(1, days).Select(day => new MonthViewCellViewModel
        {
            Text = day.ToString(),
            Opacity = IsWeekend(new DateTime(Time.Year, Time.Month, day).DayOfWeek) ? 0.5 : 1,
            Circle = day == Time.Day ? Visibility.Visible : Visibility.Collapsed,
        });
    }

    public IEnumerable<MonthViewCellViewModel> GetEmptyCells()
    {
        var startOfMonth = new DateTime(Time.Year, Time.Month, 1);
        return Enumerable.Range(0, (int)startOfMonth.DayOfWeek).Select(_ => new MonthViewCellViewModel());
    }

    private static bool IsWeekend(DayOfWeek dayOfWeek) => dayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday;

    protected virtual void Update() => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
}
