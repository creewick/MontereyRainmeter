using Microsoft.Extensions.Localization;
using uWidgets.Settings.Models;

namespace uWidgets.Widgets.Calendar;

public partial class CalendarWindow
{
    public CalendarWindow(AppSettings appSettings, WidgetSettings widgetSettings, IStringLocalizer locale) : base(appSettings, widgetSettings, locale)
    {
    }
}