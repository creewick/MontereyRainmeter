using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Interop;
using uWidgets.Animations;
using uWidgets.Settings.Models;
using uWidgets.Windows.WindowTypes;

namespace uWidgets.Windows.WidgetManager.WidgetActions;

public class SnapPositionToGridAction : IWidgetAction
{
    private readonly AppSettings appSettings;

    public SnapPositionToGridAction(AppSettings appSettings)
    {
        this.appSettings = appSettings;
    }

    public void Run(WidgetBase widget)
    {
        if (!appSettings.Appearance.GridSnap) return;
        
        var handle = new WindowInteropHelper(widget).Handle;
        var screen = Screen.FromHandle(handle);
        var graphics = Graphics.FromHwnd(handle);
        var dpiScale = graphics.DpiX / 96f;
        
        var screenTop = screen.WorkingArea.Top / dpiScale;
        var screenLeft = screen.WorkingArea.Left / dpiScale;

        var span = appSettings.WidgetSize + appSettings.WidgetPadding;
        var offset = (screen.WorkingArea.Width / dpiScale) % span;

        var oldLeft = widget.Left;
        var oldTop = widget.Top;

        var newLeft = Math.Round((widget.Left - offset) / span) * span + offset + screenLeft;
        var newTop = Math.Round(widget.Top / span) * span + appSettings.WidgetPadding + screenTop;

        if (!appSettings.Battery.LowPowerMode)
        {
            new AnimationBuilder(10)
                .Add(new LinearAnimation(left => widget.Left = left, oldLeft, newLeft))
                .Add(new LinearAnimation(top => widget.Top = top, oldTop, newTop))
                .Animate();
        }
        else
        {
            widget.Left = newLeft;
            widget.Top = newTop;
        }
    }
}