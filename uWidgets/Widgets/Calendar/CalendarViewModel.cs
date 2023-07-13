using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using Shared.Models;
using Shared.Services;

namespace Calendar;

public class CalendarViewModel
{
    private readonly CalendarSettings calendarSettings;
    private readonly AppSettings appSettings;
    private readonly DispatcherTimer timer;
    private readonly CultureInfo cultureInfo;

    public double Margin => appSettings.WidgetSize * 0.1;
    public double MonthCalendarMargin => appSettings.WidgetSize * 0.05;
    public Visibility TodayCalendar => calendarSettings.Subtype == "TodayCalendar" ? Visibility.Visible : Visibility.Collapsed;
    public Visibility MonthCalendar => calendarSettings.Subtype == "MonthCalendar" ? Visibility.Visible : Visibility.Collapsed;
    public string DayOfMonth => Time.Day.ToString();
    public string DayOfWeekShort => cultureInfo.DateTimeFormat.GetAbbreviatedDayName(Time.DayOfWeek).Replace(".", "").Capitalize();
    public string MonthShort => cultureInfo.DateTimeFormat.GetAbbreviatedMonthName(Time.Month).Capitalize();
    public string Month => cultureInfo.DateTimeFormat.GetMonthName(Time.Month).ToUpper();

    public List<DayOfWeek> Weekends => new() { DayOfWeek.Saturday, DayOfWeek.Sunday };
    public List<DayViewModel> DaysOfWeek => new(Enumerable.Range(0, 7).Select(x => new DayViewModel
    {
        Text = cultureInfo.DateTimeFormat.GetShortestDayName((DayOfWeek)x),
        Opacity = Weekends.Contains((DayOfWeek)x) ? 0.5 : 1,
    }));
    
    public List<DayViewModel> DaysInMonth => new(
        Enumerable.Range(0, (int)new DateTime(Time.Year, Time.Month, 1).DayOfWeek).Select(x => new DayViewModel())
        .Concat(Enumerable.Range(1, DateTime.DaysInMonth(Time.Year, Time.Month)).Select(x => new DayViewModel
        {
            Text = x.ToString(),
            Opacity = Weekends.Contains(new DateTime(Time.Year, Time.Month, x).DayOfWeek) ? 0.5 : 1,
            Background = x == Time.Day ? (SolidColorBrush)Application.Current.Resources["AccentFillColorDefaultBrush"] : new(Colors.Transparent),
            Foreground = x == Time.Day ? new SolidColorBrush(Colors.White) : (SolidColorBrush)Application.Current.Resources["TextFillColorPrimaryBrush"],
        })));

    public List<DayViewModel> MonthCalendarCells => DaysOfWeek.Concat(DaysInMonth).ToList();
    public GridLength MonthCalendarRows => new(Math.Ceiling(MonthCalendarCells.Count / 7d), GridUnitType.Star);
    public DateTime Time { get; set; }
    
    public CalendarViewModel(CalendarSettings calendarSettings, AppSettings appSettings, CultureInfo cultureInfo)
    {
        this.calendarSettings = calendarSettings;
        this.appSettings = appSettings;
        this.cultureInfo = cultureInfo;
        
        timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
        timer.Tick += (_, _) => { Time = DateTime.Now; };
        timer.Start();
    }

    public class DayViewModel
    {
        public string Text { get; set; } = string.Empty;
        public double Opacity { get; set; } = 0;
        public SolidColorBrush Background { get; set; } = new(Colors.Transparent);
        public SolidColorBrush Foreground { get; set; } = (SolidColorBrush)Application.Current.Resources["TextFillColorPrimaryBrush"];
    }
}
