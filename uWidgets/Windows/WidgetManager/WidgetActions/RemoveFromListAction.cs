using System.Collections.Generic;
using System.Threading.Tasks;
using uWidgets.Windows.WindowTypes;

namespace uWidgets.Windows.WidgetManager.WidgetActions;

public class RemoveFromListAction : IWidgetAction
{
    private readonly List<WidgetBase> widgets;

    public RemoveFromListAction(List<WidgetBase> widgets)
    {
        this.widgets = widgets;
    }
    
    public async Task Run(WidgetBase widget)
    {
        widgets.Remove(widget);
    }
}