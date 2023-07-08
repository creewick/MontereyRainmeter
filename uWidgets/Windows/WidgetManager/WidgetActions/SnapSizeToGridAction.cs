using System;
using System.Windows;
using System.Windows.Media.Animation;
using uWidgets.Animations;
using uWidgets.Settings.Models;
using uWidgets.Windows.Services;
using uWidgets.Windows.WindowTypes;

namespace uWidgets.Windows.WidgetManager.WidgetActions;

public class SnapSizeToGridAction : IWidgetAction
{
    private readonly AppSettings appSettings;
    private readonly Size newSize;
    private readonly GridSizeConverter gridSizeConverter;

    public SnapSizeToGridAction(AppSettings appSettings, Size newSize)
    {
        this.appSettings = appSettings;
        this.newSize = newSize;
        gridSizeConverter = new GridSizeConverter(appSettings);
    }
    
    public void Run(WidgetBase widget)
    {
        var oldWidth = widget.Width;
        var oldHeight = widget.Height;
        
        var columns = gridSizeConverter.GetGridSize(newSize.Width);
        var rows = gridSizeConverter.GetGridSize(newSize.Height);
        
        var newWidth = gridSizeConverter.GetPixels(columns);
        var newHeight = gridSizeConverter.GetPixels(rows);

        if (!appSettings.Battery.LowPowerMode)
        {
            new AnimationBuilder(20)
                .Add(new LinearAnimation(width => widget.Width = width, oldWidth, newWidth))
                .Add(new LinearAnimation(height => widget.Height = height, oldHeight, newHeight))
                .Animate();
        }

        // widget.Width = newWidth;
        // widget.Height = newHeight;
    }
}