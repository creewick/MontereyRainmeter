using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Templates;

namespace uWidgets.WidgetActions;

public class RemoveFromListAction : IWidgetAction
{
    private readonly List<Widget> widgets;

    public RemoveFromListAction(List<Widget> widgets)
    {
        this.widgets = widgets;
    }
    
    public async Task Run(Widget widget)
    {
        widgets.Remove(widget);
    }
}