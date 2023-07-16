using System.Threading.Tasks;
using Shared.Interfaces;
using Shared.Templates;

namespace uWidgets.Widgets.Actions;

public interface IWidgetAction
{
    public Task Run(Widget widget, IWidgetSettingsProvider widgetSettingsProvider);
}
