using System;
using uWidgets.Settings.Models;

namespace uWidgets.Windows.Services;

public class GridSizeConverter
{
    private readonly AppSettings appSettings;

    public GridSizeConverter(AppSettings appSettings)
    {
        this.appSettings = appSettings;
    }

    public int GetGridSize(double pixels)
    {
        return (int)Math.Round((pixels + appSettings.WidgetPadding) / (appSettings.WidgetSize + appSettings.WidgetPadding));
    }
    
    public double GetPixels(int gridSize)
    {
        return gridSize * (appSettings.WidgetSize + appSettings.WidgetPadding) - appSettings.WidgetPadding;
    }
}