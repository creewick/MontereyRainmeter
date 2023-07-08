using System.Collections.Generic;
using uWidgets.Windows.WindowTypes;

namespace uWidgets.Windows.WidgetManager.WidgetActions;

public class RemoveFromListAction : IWidgetAction
{
    private readonly List<WidgetBase> widgets;

    public RemoveFromListAction(List<WidgetBase> widgets)
    {
        this.widgets = widgets;
    }
    
    public void Run(WidgetBase widget)
    {
        widgets.Remove(widget);
    }
}