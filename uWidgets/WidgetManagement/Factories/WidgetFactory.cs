using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using uWidgets.Configuration.Interfaces;
using uWidgets.Configuration.Models;
using uWidgets.WidgetManagement.Interfaces;

namespace uWidgets.WidgetManagement.Factories;

public class WidgetFactory : IWidgetFactory
{
    private readonly ILayoutManager layoutManager;
    private readonly IServiceProvider serviceProvider;

    public WidgetFactory(ILayoutManager layoutManager, IServiceProvider serviceProvider)
    {
        this.layoutManager = layoutManager;
        this.serviceProvider = serviceProvider;
    }

    public List<IWidget> GetWidgets()
    {
        return layoutManager
            .Get()
            .Select(CreateWidget)
            .ToList();
    }

    private IWidget CreateWidget(WidgetLayout widgetLayout)
    {
        var assembly = Assembly.GetExecutingAssembly();

        var widgetType = assembly
            .GetTypes()
            .FirstOrDefault(type => type.Name.Equals(widgetLayout.Name, StringComparison.OrdinalIgnoreCase) &&
                                    typeof(IWidget).IsAssignableFrom(type));

        if (widgetType == null) 
            throw new ArgumentException($"Widget {widgetLayout.Name} not found");

        return (IWidget)ActivatorUtilities.CreateInstance(serviceProvider, widgetType, widgetLayout.Id);
    }
}