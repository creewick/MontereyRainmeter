using uWidgets.Windows.WindowTypes;

namespace uWidgets.Windows.WidgetManager.WidgetActions;

public interface IWidgetAction
{
    public void Run(WidgetBase widget);
}
