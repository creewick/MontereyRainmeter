using Shared.Interfaces;
using Shared.Interfaces.DataManagers;
using Shared.Templates;

namespace uWidgets.Clock;

public partial class Clock : Widget
{
    public Clock(IAppSettingsManager appSettingsManager, IWidgetSettingsManager widgetSettingsManager, Guid id) 
        : base(appSettingsManager, widgetSettingsManager, id)
    {
        var clockSettings = widgetSettingsManager.Get(id)!;

        InitializeComponent();
    }
}