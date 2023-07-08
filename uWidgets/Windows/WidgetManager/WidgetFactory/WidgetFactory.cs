using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using uWidgets.Settings.Models;
using uWidgets.Windows.WindowTypes;

namespace uWidgets.Windows.WidgetManager.WidgetFactory;

public class WidgetFactory : IWidgetFactory
{
    private readonly IServiceProvider serviceProvider;

    public WidgetFactory(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }
    
    public WidgetBase CreateWidget(WidgetSettings widgetSettings)
    {
        var assembly = Assembly.GetExecutingAssembly();
        
        var type = assembly
            .GetTypes()
            .FirstOrDefault(type => 
                type.Name.Equals($"{widgetSettings.Name}Window") && 
                typeof(WidgetBase).IsAssignableFrom(type));

        if (type == null)
            throw new ArgumentException($"Widget {widgetSettings.Name} is not found");
        
        var widget = (WidgetBase) ActivatorUtilities.CreateInstance(serviceProvider, type, widgetSettings);

        return widget;
    }
}