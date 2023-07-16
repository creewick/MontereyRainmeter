using System.Windows;
using Shared.Templates;

namespace Shared.Events;

public class WidgetResizedEventArgs : WidgetEventArgs
{
    public Size? Size { get; }

    public WidgetResizedEventArgs(Widget widget, Size? size) : base(widget)
    {
        this.Size = size;
    }
}