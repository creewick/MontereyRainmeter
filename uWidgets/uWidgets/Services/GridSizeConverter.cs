using System;
using Shared.Models;

namespace uWidgets.Services;

public class GridSizeConverter
{
    private readonly AppSettings appSettings;

    public GridSizeConverter(AppSettings appSettings)
    {
        this.appSettings = appSettings;
    }

    public int GetGridSize(double pixels)
    {
        return (int)Math.Round((pixels + appSettings.WidgetMargin) / (appSettings.WidgetSize + appSettings.WidgetMargin));
    }
    
    public double GetPixels(int gridSize)
    {
        return gridSize * (appSettings.WidgetSize + appSettings.WidgetMargin) - appSettings.WidgetMargin;
    }
}