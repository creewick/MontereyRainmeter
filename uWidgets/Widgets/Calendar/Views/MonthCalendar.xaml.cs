using System.Windows.Controls;
using Calendar.ViewModels;
using Shared.Interfaces;

namespace Calendar.Views;

public partial class MonthCalendar : UserControl
{
    public MonthCalendar(IAppSettingsProvider appSettingsProvider, IWidgetSettingsProvider widgetSettingsProvider)
    {
        DataContext = new MonthCalendarViewModel(appSettingsProvider);
        InitializeComponent();
    }
}