using Shared.Models;

namespace uWidgets.WidgetFactory;

public interface IWidgetFactory
{
    public Widget CreateWidget(WidgetSettings widgetSettings);
}