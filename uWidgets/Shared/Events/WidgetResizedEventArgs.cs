using Shared.Models;

namespace Shared.Events;

public class WidgetResizedEventArgs : WidgetEventArgs
{
    public double Width { get; }
    public double Height { get; }

    public WidgetResizedEventArgs(Widget widget, double width, double height) : base(widget)
    {
        Width = width;
        Height = height;
    }
}