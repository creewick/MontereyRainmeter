using PropertyChanged;

namespace uWidgets.Widgets.Calendar;


[AddINotifyPropertyChangedInterface]
public class CalendarViewModel
{
    private readonly CalendarSettings calendarSettings;
    
    public CalendarViewModel(CalendarSettings calendarSettings)
    {
        this.calendarSettings = calendarSettings;
    }
}