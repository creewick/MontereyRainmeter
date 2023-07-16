using Shared.Interfaces;
using Shared.Templates;

namespace uWidgets.Widgets.Factory;

public interface IWidgetFactory
{
    public Widget CreateWidget(IWidgetSettingsProvider widgetSettingsProvider);
}