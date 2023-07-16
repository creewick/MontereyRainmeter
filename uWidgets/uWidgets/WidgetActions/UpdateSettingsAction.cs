using System.Threading.Tasks;
using Shared.Interfaces;
using Shared.Services;
using Shared.Templates;

namespace uWidgets.WidgetActions;

public class UpdateSettingsAction : IWidgetAction
{
    private readonly GridSizeConverter gridSizeConverter;

    public UpdateSettingsAction(GridSizeConverter gridSizeConverter)
    {
        this.gridSizeConverter = gridSizeConverter;
    }
    
    public async Task Run(Widget widget, IWidgetSettingsProvider widgetSettingsProvider)
    {
        var widgetSettings = widgetSettingsProvider.Get();
        widgetSettings.X = (int) widget.Left;
        widgetSettings.Y = (int) widget.Top;
        widgetSettings.Columns = gridSizeConverter.GetGridSize(widget.Width);
        widgetSettings.Rows = gridSizeConverter.GetGridSize(widget.Height);

        widgetSettingsProvider.Update(widgetSettings);
    }
}