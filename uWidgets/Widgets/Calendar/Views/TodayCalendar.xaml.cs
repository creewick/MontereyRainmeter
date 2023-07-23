using System.Windows.Controls;
using Calendar.ViewModels;
using Shared.Interfaces;

namespace Calendar.Views;

public partial class TodayCalendar : UserControl
{
    public TodayCalendar(IAppSettingsProvider appSettingsProvider, IWidgetSettingsProvider widgetSettingsProvider)
    {
        DataContext = new TodayCalendarViewModel(appSettingsProvider);
        InitializeComponent();
    }
}