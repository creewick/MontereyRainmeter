using Calendar.Controls;
using Microsoft.Extensions.Localization;
using Shared.Interfaces;
using Shared.Models;

namespace Calendar;

public class CalendarWidget : Widget
{
    public CalendarWidget(IAppSettingsProvider appSettingsProvider, IStringLocalizer locale) 
        : base(appSettingsProvider, locale, new MonthCalendar())
    {
    }
}