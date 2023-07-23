using Clock.ViewModels;
using Shared.Interfaces;

namespace Clock.Views;

public partial class DigitalClock
{
    public DigitalClock(IAppSettingsProvider appSettingsProvider, IWidgetSettingsProvider widgetSettingsProvider)
    {
        DataContext = new DigitalClockViewModel(appSettingsProvider, widgetSettingsProvider);
        InitializeComponent();
    }
}