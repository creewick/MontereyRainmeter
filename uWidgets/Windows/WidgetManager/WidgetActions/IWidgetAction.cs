using System.Threading.Tasks;
using uWidgets.Windows.WindowTypes;

namespace uWidgets.Windows.WidgetManager.WidgetActions;

public interface IWidgetAction
{
    public Task Run(WidgetBase widget);
}
