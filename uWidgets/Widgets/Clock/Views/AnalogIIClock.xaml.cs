using Clock.ViewModels;
using Shared.Interfaces;

namespace Clock.Views;

public partial class AnalogIIClock
{
    public AnalogIIClock(IAppSettingsProvider appSettingsProvider, IWidgetSettingsProvider widgetSettingsProvider)
    {
        DataContext = new AnalogClockViewModel(appSettingsProvider, widgetSettingsProvider);
        InitializeComponent();
    }
}