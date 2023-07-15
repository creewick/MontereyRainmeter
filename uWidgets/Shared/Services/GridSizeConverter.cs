using System;
using Shared.Interfaces;

namespace Shared.Services;

public class GridSizeConverter
{
    private readonly IAppSettingsProvider appSettingsProvider;

    public GridSizeConverter(IAppSettingsProvider appSettingsProvider)
    {
        this.appSettingsProvider = appSettingsProvider;
    }

    public int GetGridSize(double pixels)
    {
        var settings = appSettingsProvider.Get();
        return (int)Math.Round((pixels + settings.WidgetMargin) / (settings.WidgetSize + settings.WidgetMargin));
    }
    
    public double GetPixels(int gridSize)
    {
        var settings = appSettingsProvider.Get();
        return gridSize * (settings.WidgetSize + settings.WidgetMargin) - settings.WidgetMargin;
    }
}