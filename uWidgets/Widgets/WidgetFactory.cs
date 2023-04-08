using System;
using uWidgets.Models;
using uWidgets.Themes;

namespace uWidgets.Widgets;

public static class WidgetFactory
{
    public static Widget GetWidget(WidgetLayout layout, Settings settings, ITheme theme, Locale locale)
    {
        return layout.Name switch
        {
            "Clock" => new Clock(layout, settings, theme, locale),
            "Calendar" => new Calendar(layout, settings, theme, locale),
            _ => throw new ArgumentException(nameof(layout.Name))
        };
    }
}