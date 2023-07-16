using System.Threading.Tasks;
using Shared.Templates;

namespace uWidgets.WidgetActions;

public interface IWidgetAction
{
    public Task Run(Widget widget);
}
