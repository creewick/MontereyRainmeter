using System;
using uWidgets.Models;

namespace uWidgets.Widgets;

public static class WidgetFactory
{
    public static Widget GetWidget(WidgetLayout layout, Settings settings, LocaleStrings localeStrings)
    {
        return layout.Name switch
        {
            "Clock" => new Clock(layout, settings, localeStrings),
            "Calendar" => new Calendar(layout, settings, localeStrings),
            _ => throw new ArgumentException(nameof(layout.Name))
        };
    }
}