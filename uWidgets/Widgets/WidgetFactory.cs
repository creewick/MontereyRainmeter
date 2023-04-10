using System;
using System.Collections.Generic;
using System.Linq;
using uWidgets.Infrastructure.Files;
using uWidgets.Infrastructure.Models;

namespace uWidgets.Widgets;

public class WidgetFactory : IWidgetFactory
{
    private readonly IFileHandler<AppSettings> settingsManager;
    private readonly IFileHandler<List<WidgetLayout>> layoutManager;
    private readonly IFileHandler<AppLocale> localeManager;

    public WidgetFactory(IFileHandler<AppSettings> settingsManager, IFileHandler<List<WidgetLayout>> layoutManager, IFileHandler<AppLocale> localeManager)
    {
        this.settingsManager = settingsManager;
        this.layoutManager = layoutManager;
        this.localeManager = localeManager;
    }

    public List<Widget> GetWidgets()
    {
        var appSettings = settingsManager.Get();
        var localeStrings = localeManager.Get().LocaleStrings[appSettings.Region.Language];
        
        return layoutManager
            .Get()
            .Select(layout => CreateWidget(appSettings, layout, localeStrings))
            .ToList();
    }

    private static Widget CreateWidget(AppSettings appSettings, WidgetLayout widgetLayout, LocaleStrings localeStrings)
    {
        return widgetLayout.Name switch
        {
            "Clock" => new Clock.Clock(widgetLayout, appSettings, localeStrings),
            "Calendar" => new Calendar.Calendar(widgetLayout, appSettings, localeStrings),
            "Weather" => new Weather.Weather(widgetLayout, appSettings, localeStrings),
            _ => throw new ArgumentException(nameof(widgetLayout.Name))
        };
    }
}