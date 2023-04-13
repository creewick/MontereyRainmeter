using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using uWidgets.Configuration.Models;
using uWidgets.UserInterface.Interfaces;
using uWidgets.UserInterface.Models;
using uWidgets.WindowManagement.Interfaces;
using uWidgets.WindowManagement.Models;
using uWidgets.WindowManagement.WindowTypes;

namespace uWidgets.WindowManagement.Factories;

public class WidgetFactory : IWidgetFactory
{
    public WidgetFactory(IServiceProvider serviceProvider, List<WidgetLayout> widgetLayouts,
        ILayoutService layoutService)
    {
        ServiceProvider = serviceProvider;
        WidgetLayouts = widgetLayouts;
        LayoutService = layoutService;
    }

    public IServiceProvider ServiceProvider { get; }
    public List<WidgetLayout> WidgetLayouts { get; }
    public ILayoutService LayoutService { get; }

    public List<WidgetBase> GetWidgets()
    {
        return WidgetLayouts
            .Select(CreateWidget)
            .ToList();
    }

    private WidgetBase CreateWidget(WidgetLayout widgetLayout)
    {
        var assembly = Assembly.GetExecutingAssembly();

        var widgetType = assembly
            .GetTypes()
            .FirstOrDefault(type => type.Name.Equals(widgetLayout.Name) &&
                                    typeof(WidgetBase).IsAssignableFrom(type));

        if (widgetType == null)
            throw new ArgumentException($"Widget {widgetLayout.Name} not found");

        var widgetContext =
            (WidgetContext)ActivatorUtilities.CreateInstance(ServiceProvider, typeof(WidgetContext), widgetLayout);

        var widget = (WidgetBase)ActivatorUtilities.CreateInstance(ServiceProvider, widgetType, widgetContext);

        widget.WidgetMoved += (_, _) => LayoutService.OnWidgetMove(widget);
        widget.WidgetResized +=
            (columns, rows, animate) => LayoutService.OnWidgetResize(widget, columns, rows, animate);
        widget.Show();

        return widget;
    }
}