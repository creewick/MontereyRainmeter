using Clock.ViewModels;
using Shared.Interfaces;

namespace Clock.Views;

public partial class AnalogIClock
{
    public AnalogIClock(IAppSettingsProvider appSettingsProvider, IWidgetSettingsProvider widgetSettingsProvider)
    {
        DataContext = new AnalogClockViewModel(appSettingsProvider, widgetSettingsProvider);
        InitializeComponent();
    }
}