using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Interop;
using uWidgets.Windows.WindowTypes;

namespace uWidgets.Windows.WidgetManager.WidgetActions;

public class KeepOnScreenAction : IWidgetAction
{
    public async Task Run(WidgetBase widget)
    {
        var handle = new WindowInteropHelper(widget).Handle;
        var screen = Screen.FromHandle(handle);
        var graphics = Graphics.FromHwnd(handle);
        var dpiScale = graphics.DpiX / 96f;
            
        widget.Left = Math.Clamp(
            widget.Left,
            screen.WorkingArea.Left / dpiScale,
            screen.WorkingArea.Right / dpiScale - widget.Width);

        widget.Top = Math.Clamp(
            widget.Top,
            screen.WorkingArea.Top / dpiScale,
            screen.WorkingArea.Bottom / dpiScale - widget.Height);
    }
}