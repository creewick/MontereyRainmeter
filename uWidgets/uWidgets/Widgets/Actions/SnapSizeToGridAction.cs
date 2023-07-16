using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using Shared.Interfaces;
using Shared.Services;
using Shared.Templates;
using uWidgets.Services;

namespace uWidgets.Widgets.Actions;

public class SnapSizeToGridAction : IWidgetAction
{
    private readonly IAppSettingsProvider appSettingsProvider;
    private readonly Size? newSize;
    private readonly GridSizeConverter gridSizeConverter;

    public SnapSizeToGridAction(IAppSettingsProvider appSettingsProvider, Size? newSize)
    {
        this.appSettingsProvider = appSettingsProvider;
        this.newSize = newSize;
        gridSizeConverter = new GridSizeConverter(appSettingsProvider);
    }
    
    public async Task Run(Widget widget, IWidgetSettingsProvider widgetSettingsProvider)
    {
        var oldWidth = widget.Width;
        var oldHeight = widget.Height;
        
        var columns = gridSizeConverter.GetGridSize(newSize?.Width ?? widget.Width);
        var rows = gridSizeConverter.GetGridSize(newSize?.Height ?? widget.Height);
        
        var newWidth = gridSizeConverter.GetPixels(columns);
        var newHeight = gridSizeConverter.GetPixels(rows);

        if (appSettingsProvider.Get().Battery.LowPowerMode)
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