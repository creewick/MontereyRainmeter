using System;
using Shared.Models;

namespace Shared.Events;

public class WidgetEventArgs : EventArgs
{
    public Widget Widget { get; }

    public WidgetEventArgs(Widget widget)
    {
        Widget = widget;
    }
}