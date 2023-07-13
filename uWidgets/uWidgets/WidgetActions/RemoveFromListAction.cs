using System.Collections.Generic;
using System.Threading.Tasks;

namespace uWidgets.WidgetActions;

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