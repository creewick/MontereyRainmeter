using System.Threading.Tasks;
using Shared.Models;

namespace uWidgets.WidgetActions;

public interface IWidgetAction
{
    public Task Run(Widget widget);
}
