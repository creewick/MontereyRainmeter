using System.Threading.Tasks;

namespace uWidgets.WidgetActions;

public interface IWidgetAction
{
    public Task Run(WidgetBase widget);
}
