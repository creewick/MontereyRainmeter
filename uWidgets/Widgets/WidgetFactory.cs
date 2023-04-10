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
        return layoutManager
            .Get()
            .Select(layout => CreateWidget(settingsManager, layoutManager, localeManager, layout))
            .ToList();
    }

    private static Widget CreateWidget(
        IFileHandler<AppSettings> settingsManager, 
        IFileHandler<List<WidgetLayout>> layoutManager, 
        IFileHandler<AppLocale> localeManager, 
        WidgetLayout widgetLayout) 
    {
        return widgetLayout.Name switch
        {
            "Clock" => new Clock.Clock(settingsManager, layoutManager, localeManager, widgetLayout.Id),
            "Calendar" => new Calendar.Calendar(settingsManager, layoutManager, localeManager, widgetLayout.Id),
            "Weather" => new Weather.Weather(settingsManager, layoutManager, localeManager, widgetLayout.Id),
            _ => throw new ArgumentException(nameof(widgetLayout.Name))
        };
    }
}