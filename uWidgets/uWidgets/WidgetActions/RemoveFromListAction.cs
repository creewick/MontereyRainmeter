using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Interfaces;
using Shared.Templates;
using uWidgets.Providers;

namespace uWidgets.WidgetActions;

public class RemoveFromListAction : IWidgetAction
{
    private readonly Dictionary<Widget, IWidgetSettingsProvider> widgets;

    public RemoveFromListAction(Dictionary<Widget, IWidgetSettingsProvider> widgets)
    {
        this.widgets = widgets;
    }
    
    public async Task Run(Widget widget, IWidgetSettingsProvider widgetSettingsProvider)
    {
        widgets.Remove(widget);
        // убрать из LayoutProvider
    }
}