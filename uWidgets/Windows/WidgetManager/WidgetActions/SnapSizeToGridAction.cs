using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using uWidgets.Settings.Models;
using uWidgets.Windows.Services;
using uWidgets.Windows.WindowTypes;

namespace uWidgets.Windows.WidgetManager.WidgetActions;

public class SnapSizeToGridAction : IWidgetAction
{
    private readonly AppSettings appSettings;
    private readonly Size? newSize;
    private readonly GridSizeConverter gridSizeConverter;

    public SnapSizeToGridAction(AppSettings appSettings, Size? newSize)
    {
        this.appSettings = appSettings;
        this.newSize = newSize;
        gridSizeConverter = new GridSizeConverter(appSettings);
    }
    
    public async Task Run(WidgetBase widget)
    {
        var oldWidth = widget.Width;
        var oldHeight = widget.Height;
        
        var columns = gridSizeConverter.GetGridSize(newSize?.Width ?? widget.Width);
        var rows = gridSizeConverter.GetGridSize(newSize?.Height ?? widget.Width);
        
        var newWidth = gridSizeConverter.GetPixels(columns);
        var newHeight = gridSizeConverter.GetPixels(rows);

        if (appSettings.Battery.LowPowerMode)
        {      
            widget.Width = newWidth;
            widget.Height = newHeight;
            return;
        }

        var widthAnimation = new DoubleAnimation
        {
            From = oldWidth,
            To = newWidth,
            Duration = new Duration(TimeSpan.FromSeconds(0.25))
        };

        var heightAnimation = new DoubleAnimation
        {
            From = oldHeight,
            To = newHeight,
            Duration = new Duration(TimeSpan.FromSeconds(0.25)),
            BeginTime = TimeSpan.FromSeconds(0.25)
        };

        var storyboard = new Storyboard();

        storyboard.Children.Add(widthAnimation);
        storyboard.Children.Add(heightAnimation);

        Storyboard.SetTarget(widthAnimation, widget);
        Storyboard.SetTarget(heightAnimation, widget);

        Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(Window.WidthProperty));
        Storyboard.SetTargetProperty(heightAnimation, new PropertyPath(Window.HeightProperty));

        await storyboard.BeginAsync();
    }
}