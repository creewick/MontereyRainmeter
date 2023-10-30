using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Shared.Interfaces;
using Shared.Interfaces.DataManagers;
using Shared.Models;
using Shared.Templates;
using uWidgets.Clock;

namespace uWidgets.Services;

public class WidgetFactory : IWidgetFactory
{
    private readonly IServiceProvider serviceProvider;

    public WidgetFactory(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }
    
    public List<Widget> CreateWidgets(IEnumerable<WidgetSettings> widgets)
    {
        return widgets
            .Select(widgetSettings => CreateWidget(widgetSettings.Type, widgetSettings.Id))
            .ToList();
    }

    public Widget CreateWidget(string widgetType, Guid widgetId)
    {
        var type = GetWidgetType(widgetType);
        var widget = (Widget) ActivatorUtilities.CreateInstance(serviceProvider, type, widgetId);

        return widget;
    }

    public static Type GetWidgetType(string widgetType)
    {
        return widgetType switch
        {
            "Clock" => typeof(Clock.Clock),
            _ => throw new KeyNotFoundException()
        };
    }
    
    public static Type GetWidgetSettingsType(string widgetType)
    {
        return widgetType switch
        {
            "Clock" => typeof(ClockSettings),
            _ => typeof(WidgetSettings)
        };
    }
}