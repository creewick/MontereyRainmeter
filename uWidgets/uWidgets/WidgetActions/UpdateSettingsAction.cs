using System.Threading.Tasks;
using uWidgets.Services;

namespace uWidgets.WidgetActions;

public class UpdateSettingsAction : IWidgetAction
{
    private readonly GridSizeConverter gridSizeConverter;

    public UpdateSettingsAction(GridSizeConverter gridSizeConverter)
    {
        this.gridSizeConverter = gridSizeConverter;
    }
    
    public async Task Run(WidgetBase widget)
    {
        widget.WidgetSettings.X = (int)widget.Left;
        widget.WidgetSettings.Y = (int)widget.Top;
        widget.WidgetSettings.Columns = gridSizeConverter.GetGridSize(widget.Width);
        widget.WidgetSettings.Rows = gridSizeConverter.GetGridSize(widget.Height);
    }
}