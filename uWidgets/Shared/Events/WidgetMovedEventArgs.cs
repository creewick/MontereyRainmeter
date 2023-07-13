using Shared.Models;

namespace Shared.Events;

public class WidgetMovedEventArgs : WidgetEventArgs
{
    public double Left { get; }
    public double Top { get; }

    public WidgetMovedEventArgs(Widget widget, double left, double top) : base(widget)
    {
        Left = left;
        Top = top;
    }
}