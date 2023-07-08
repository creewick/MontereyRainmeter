using uWidgets.Settings.Models;
using uWidgets.Windows.WindowTypes;

namespace uWidgets.Windows.WidgetManager.WidgetFactory;

public interface IWidgetFactory
{
    public WidgetBase CreateWidget(WidgetSettings widgetSettings);
}