using Clock.ViewModels;
using Shared.Interfaces;

namespace Clock.Views;

public partial class AnalogIIIClock
{
    public AnalogIIIClock(IAppSettingsProvider appSettingsProvider, IWidgetSettingsProvider widgetSettingsProvider)
    {
        DataContext = new AnalogClockViewModel(appSettingsProvider, widgetSettingsProvider);
        InitializeComponent();
    }
}