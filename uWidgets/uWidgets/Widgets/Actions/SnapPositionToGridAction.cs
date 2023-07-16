using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Windows.Media.Animation;
using Shared.Interfaces;
using Shared.Templates;
using uWidgets.Services;

namespace uWidgets.Widgets.Actions;

public class SnapPositionToGridAction : IWidgetAction
{
    private readonly IAppSettingsProvider appSettingsProvider;

    public SnapPositionToGridAction(IAppSettingsProvider appSettingsProvider)
    {
        this.appSettingsProvider = appSettingsProvider;
    }

    public async Task Run(Widget widget, IWidgetSettingsProvider widgetSettingsProvider)
    {
        var appSettings = appSettingsProvider.Get();
        
        if (!appSettings.Appearance.GridSnap) return;
        
        var handle = new WindowInteropHelper(widget).Handle;
        var screen = Screen.FromHandle(handle);
        var graphics = Graphics.FromHwnd(handle);
        var dpiScale = graphics.DpiX / 96f;
        
        var screenTop = screen.WorkingArea.Top / dpiScale;
        var screenLeft = screen.WorkingArea.Left / dpiScale;

        var span = appSettings.WidgetSize + appSettings.WidgetMargin;
        var offset = (screen.WorkingArea.Width / dpiScale) % span;

        var oldLeft = widget.Left;
        var oldTop = widget.Top;

        var newLeft = Math.Round((widget.Left - offset) / span) * span + offset + screenLeft;
        var newTop = Math.Round(widget.Top / span) * span + appSettings.WidgetMargin + screenTop;
        
        if (appSettings.Battery.LowPowerMode)
        {      
            widget.Left = newLeft;
            widget.Top = newTop;
            return;
        }

        var leftAnimation = new DoubleAnimation
        {
            From = oldLeft,
            To = newLeft,
            Duration = new Duration(TimeSpan.FromSeconds(0.25))
        };

        var topAnimation = new DoubleAnimation
        {
            From = oldTop,
            To = newTop,
            Duration = new Duration(TimeSpan.FromSeconds(0.25))
        };

        var storyboard = new Storyboard();

        storyboard.Children.Add(leftAnimation);
        storyboard.Children.Add(topAnimation);

        Storyboard.SetTarget(leftAnimation, widget);
        Storyboard.SetTarget(topAnimation, widget);

        Storyboard.SetTargetProperty(leftAnimation, new PropertyPath(Window.LeftProperty));
        Storyboard.SetTargetProperty(topAnimation, new PropertyPath(Window.TopProperty));

        await storyboard.BeginAsync();
    }
}