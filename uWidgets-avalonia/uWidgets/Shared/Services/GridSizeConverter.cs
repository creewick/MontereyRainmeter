using Shared.Interfaces;

namespace Shared.Services;

public class GridSizeConverter : IGridSizeConverter
{
    private readonly IAppSettingsManager appSettingsManager;

    public GridSizeConverter(IAppSettingsManager appSettingsManager)
    {
        this.appSettingsManager = appSettingsManager;
    }

    public int GetGridSize(double pixels)
    {
        var settings = appSettingsManager.Get().Advanced;
        return (int)Math.Round((pixels + settings.WidgetMargin) / (settings.WidgetSize + settings.WidgetMargin));
    }
    
    public double GetPixels(int gridSize)
    {
        var settings = appSettingsManager.Get().Advanced;
        return gridSize * (settings.WidgetSize + settings.WidgetMargin) - settings.WidgetMargin;
    }
}