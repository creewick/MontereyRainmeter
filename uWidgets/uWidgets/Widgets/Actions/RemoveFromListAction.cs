using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Interfaces;
using Shared.Templates;

namespace uWidgets.Widgets.Actions;

public class RemoveFromListAction : IWidgetAction
{
    private readonly List<Widget> widgets;
    private readonly ILayoutProvider layoutProvider;

    public RemoveFromListAction(List<Widget> widgets, ILayoutProvider layoutProvider)
    {
        this.widgets = widgets;
        this.layoutProvider = layoutProvider;
    }
    
    public async Task Run(Widget widget, IWidgetSettingsProvider widgetSettingsProvider)
    {
        widgets.Remove(widget);
        widget.Close();
        
        layoutProvider.Update(
            layoutProvider.Get().Where(x => x.Id != widget.Id).ToArray() 
        );
    }
}