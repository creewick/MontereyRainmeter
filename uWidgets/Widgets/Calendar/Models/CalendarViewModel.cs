using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using Shared.Interfaces;
using Shared.Models;
using Shared.Services;

namespace Calendar.Models;

public class CalendarViewModel : INotifyPropertyChanged
{
    private readonly DispatcherTimer timer;
    private CalendarSettings calendarSettings;
    private AppSettings appSettings;
    private CultureInfo cultureInfo;
    
    public event PropertyChangedEventHandler? PropertyChanged;
    public double Margin => appSettings.WidgetSize * 0.1;
    public double MonthCalendarMargin => appSettings.WidgetSize * 0.05;
    public string DayOfMonth => Time.Day.ToString();
    public string DayOfWeekShort => cultureInfo.DateTimeFormat.GetAbbreviatedDayName(Time.DayOfWeek).Replace(".", "").Capitalize();
    public string MonthShort => cultureInfo.DateTimeFormat.GetAbbreviatedMonthName(Time.Month).Capitalize();
    public string Month => cultureInfo.DateTimeFormat.GetMonthName(Time.Month).ToUpper();

    public List<DayOfWeek> Weekends => new() { DayOfWeek.Saturday, DayOfWeek.Sunday };
    public List<MonthViewCellViewModel> DaysOfWeek => new(Enumerable.Range(0, 7).Select(x => new MonthViewCellViewModel
    {
        Text = cultureInfo.DateTimeFormat.GetShortestDayName((DayOfWeek)x),
        Opacity = Weekends.Contains((DayOfWeek)x) ? 0.5 : 1,
    }));
    
    public List<MonthViewCellViewModel> DaysInMonth => new(
        Enumerable.Range(0, (int)new DateTime(Time.Year, Time.Month, 1).DayOfWeek).Select(x => new MonthViewCellViewModel())
        .Concat(Enumerable.Range(1, DateTime.DaysInMonth(Time.Year, Time.Month)).Select(x => new MonthViewCellViewModel
        {
            Text = x.ToString(),
            Opacity = Weekends.Contains(new DateTime(Time.Year, Time.Month, x).DayOfWeek) ? 0.5 : 1,
            Background = x == Time.Day ? (SolidColorBrush)Application.Current.Resources["AccentFillColorDefaultBrush"] : new(Colors.Transparent),
            Foreground = x == Time.Day ? new SolidColorBrush(Colors.White) : (SolidColorBrush)Application.Current.Resources["TextFillColorPrimaryBrush"],
        })));

    public List<MonthViewCellViewModel> MonthCalendarCells => DaysOfWeek.Concat(DaysInMonth).ToList();
    public GridLength MonthCalendarRows => new(Math.Ceiling(MonthCalendarCells.Count / 7d), GridUnitType.Star);
    public DateTime Time { get; set; }
    
    public CalendarViewModel(IAppSettingsProvider appSettingsProvider, IWidgetSettingsProvider widgetSettingsProvider)
    {
        calendarSettings = (CalendarSettings) widgetSettingsProvider.Get();
        appSettings = appSettingsProvider.Get();
        cultureInfo = new CultureInfo(appSettings.Region.Language);

        widgetSettingsProvider.Updated += (_, widgetSettings) =>
        {
            calendarSettings = (CalendarSettings) widgetSettings;
            Update();
        };
        
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

    protected virtual void Update()
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
    }
}
