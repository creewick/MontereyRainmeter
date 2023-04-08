using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using uWidgets.Models;

namespace uWidgets.Widgets;

public partial class Calendar
{
    private readonly CultureInfo cultureInfo;
    
    public Calendar(WidgetLayout layout, Settings settings, LocaleStrings localeStrings) 
        : base(layout, settings,localeStrings)
    {
        cultureInfo = new CultureInfo(Settings.Region.Language);
        InitializeComponent();
        FillMonthCalendar(DateTime.Now.Date);
        Show();
    }

    private void FillMonthCalendar(DateTime now)
    {
        var weekDays = GetWeekDays().ToList();
        FillMonthName(now);
        FillWeekDays(weekDays);
        FillDays(now, weekDays);
    }

    private void FillMonthName(DateTime now)
    {
        MonthCalendar.RowDefinitions.Add(new RowDefinition());
        MonthName.Text = now.ToString("MMMM", new CultureInfo(Settings.Region.Language)).ToUpper();
    }

    private void FillWeekDays(List<DayOfWeek> weekDays)
    {
        MonthCalendar.RowDefinitions.Add(new RowDefinition());

        for (var i = 0; i < weekDays.Count; i++)
        {
            var name = cultureInfo.DateTimeFormat.GetDayName(weekDays[i]).ToUpper()[..1];
            var element = GetViewBox(name, IsWeekend(weekDays[i]));

            MonthCalendar.Children.Add(element);
            
            Grid.SetRow(element, 1);
            Grid.SetColumn(element, i);
        }
    }

    private void FillDays(DateTime now, List<DayOfWeek> weekDays)
    {
        var daysCount = DateTime.DaysInMonth(now.Year, now.Month);
        
        for (var day = 1; day <= daysCount; day++)
        {
            var date = new DateTime(now.Year, now.Month, day);
            var column = weekDays.IndexOf(date.DayOfWeek);
        
            if (column == 0 || day == 1) 
                MonthCalendar.RowDefinitions.Add(new RowDefinition());

            var row = MonthCalendar.RowDefinitions.Count - 1;

            if (day == now.Day)
                FillTodayCircle(column, row);

            var element = GetViewBox(day.ToString(), IsWeekend(date.DayOfWeek), day == now.Day);

            MonthCalendar.Children.Add(element);
            
            Grid.SetColumn(element, column);
            Grid.SetRow(element, row);
        }
    }

    private void FillTodayCircle(int column, int row)
    {
        var ellipse = new Ellipse
        {
            Fill = (Brush)Application.Current.Resources["AccentFillColorDefaultBrush"]
        };

        MonthCalendar.Children.Add(ellipse);
                
        Grid.SetColumn(ellipse, column);
        Grid.SetRow(ellipse, row);
    }

    private IEnumerable<DayOfWeek> GetWeekDays()
    {
        var firstDayOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek;
        var daysOfWeek = Enum.GetValues<DayOfWeek>().ToList();
        var firstDayOfWeekIndex = daysOfWeek.IndexOf(firstDayOfWeek);

        return daysOfWeek
            .Skip(firstDayOfWeekIndex)
            .Concat(daysOfWeek.Take(firstDayOfWeekIndex));
    }

    private static bool IsWeekend(DayOfWeek dayOfWeek) => dayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday;

    private static Viewbox GetViewBox(string text, bool isWeekend, bool today = false) => new()
    {
        Child = new TextBlock
        {
            Text = text,
            Opacity = isWeekend && !today ? 0.5 : 1,
            Foreground = today 
                ? new SolidColorBrush(Colors.White) 
                : (Brush)Application.Current.Resources["TextFillColorPrimaryBrush"]
        }
    };
}