using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using uWidgets.Models;
using uWidgets.Themes;
using uWidgets.Utilities;

namespace uWidgets.Widgets;

public partial class Calendar : Widget
{
    public Calendar(WidgetLayout layout, Settings settings, ITheme theme, Locale locale) 
        : base(layout, settings, theme, locale)
    {
        InitializeComponent();
        FillMonthCalendar(theme);
        Show();
    }

    private void FillMonthCalendar(ITheme theme)
    {
        
        var now = DateTime.Now.Date;
        var daysCount = DateTime.DaysInMonth(now.Year, now.Month);
        var font = (FontFamily)Application.Current.Resources["SfProMedium"];
        var row = 1;

        MonthCalendar.RowDefinitions.Add(new RowDefinition());
        MonthName.Text = now.ToString("MMMM").ToUpper();
        MonthName.Foreground = new SolidColorBrush(theme.GetAccentColor());
        
        MonthCalendar.RowDefinitions.Add(new RowDefinition());

        for (var weekDay = 0; weekDay < 7; weekDay++)
        {
            MonthCalendar.With(new Viewbox
            {
                Child = new TextBlock
                {
                    Text = weekDay.ToString(),
                    FontFamily = font,
                    Foreground = new SolidColorBrush(theme.GetForegroundColor()),
                    Opacity = weekDay < 5 ? 1 : 0.5
                }
            }, weekDay, 1);
        }

        for (var day = 1; day <= daysCount; day++)
        {
            var column = ((int)new DateTime(now.Year, now.Month, day).DayOfWeek + 6) % 7;

            if (column == 0 || day == 1)
            {
                MonthCalendar.RowDefinitions.Add(new RowDefinition());
                row++;
            }

            MonthCalendar.With(new Viewbox
            {
                Child = new TextBlock
                {
                    Text = day.ToString(),
                    FontFamily = font,
                    Foreground = new SolidColorBrush(theme.GetForegroundColor()),
                    Opacity = column < 5 ? 1 : 0.5,
                }
            }, column, row);
        }
    }
}