using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
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
        
        var timer = new DispatcherTimer { Interval = TimeSpan.FromMinutes(1) };
        timer.Tick += OnTick;
        timer.Start();
        OnTick(null, null);
        
        SizeChanged += OnSizeChanged;
        MouseDoubleClick += (_,_) => Process.Start("explorer.exe", @"shell:AppsFolder\microsoft.windowscommunicationsapps_8wekyb3d8bbwe!microsoft.windowslive.calendar");

        Show();
    }

    private void OnSizeChanged(object sender, SizeChangedEventArgs e)
    {
        var small = Math.Min(Width, Height) < 100;
        MonthCalendar.Visibility = small ? Visibility.Hidden : Visibility.Visible;
        TodaySmall.Visibility = small ? Visibility.Visible : Visibility.Hidden;
    }

    private void OnTick(object? sender, EventArgs? e)
    {
        var now = DateTime.Now.Date;
        var weekDays = GetWeekDays().ToList();
        
        ClearMonthCalendar();
        UpdateSmallView(now);
        FillMonthName(now);
        FillWeekDays(weekDays);
        FillDays(now, weekDays);
    }

    private void UpdateSmallView(DateTime now)
    {
        var weekDay = cultureInfo.DateTimeFormat.GetDayName(now.DayOfWeek);
        if (weekDay.Length > 10) 
            weekDay = cultureInfo.DateTimeFormat.GetAbbreviatedDayName(now.DayOfWeek);
        
        WeekDay.Text = char.ToUpper(weekDay[0]) + weekDay[1..];
        DayNumber.Text = now.Day.ToString();
    }

    private void ClearMonthCalendar()
    {
        MonthCalendar.Children
            .Cast<UIElement>()
            .Where(x => Grid.GetRow(x) > 0)
            .ToList()
            .ForEach(x => MonthCalendar.Children.Remove(x));
        
        MonthCalendar.RowDefinitions
            .Cast<RowDefinition>()
            .ToList()
            .ForEach(x => MonthCalendar.RowDefinitions.Remove(x));
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
            var name = cultureInfo.DateTimeFormat.GetShortestDayName(weekDays[i]).ToUpper();
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
        var viewBox = new Viewbox
        {
            Child = new Canvas
            {
                Width = 100,
                Height = 100,
                Children =
                {
                    new Ellipse
                    {
                        Fill = (Brush)Application.Current.Resources["AccentFillColorDefaultBrush"],
                        Width = 100,
                        Height = 100
                    }
                }
            }
        };
        
        MonthCalendar.Children.Add(viewBox);
                
        Grid.SetColumn(viewBox, column);
        Grid.SetRow(viewBox, row);
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