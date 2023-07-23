using Clock.ViewModels;
using Shared.Interfaces;

namespace Clock.Views;

public partial class WorldClock
{
    public WorldClock(IAppSettingsProvider appSettingsProvider, IWidgetSettingsProvider widgetSettingsProvider)
    {
        InitializeComponent();
        DataContext = new WorldClockViewModel(appSettingsProvider);
        Clock1.Content = new AnalogIClock(appSettingsProvider, widgetSettingsProvider);
        Clock2.Content = new AnalogIClock(appSettingsProvider, widgetSettingsProvider);
        Clock3.Content = new AnalogIClock(appSettingsProvider, widgetSettingsProvider);
        Clock4.Content = new AnalogIClock(appSettingsProvider, widgetSettingsProvider);
    }
}