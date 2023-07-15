using Shared.Interfaces;
using Shared.Templates;

namespace uWidgets.WidgetFactory;

public interface IWidgetFactory
{
    public Widget CreateWidget(IWidgetSettingsProvider widgetSettingsProvider);
}