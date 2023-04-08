using System;
using uWidgets.Models;

namespace uWidgets.Widgets;

public static class WidgetFactory
{
    public static Widget GetWidget(WidgetLayout layout, Settings settings, Locale locale)
    {
        return layout.Name switch
        {
            "Clock" => new Clock(layout, settings, locale),
            "Calendar" => new Calendar(layout, settings, locale),
            _ => throw new ArgumentException(nameof(layout.Name))
        };
    }
}