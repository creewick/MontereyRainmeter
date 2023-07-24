using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Shared.Interfaces;
using Shared.Services;
using Shared.Templates;
using uWidgets.Providers;
using uWidgets.Widgets.Actions;
using uWidgets.Widgets.Factory;

namespace uWidgets.Widgets.Manager;

public class WidgetManager : IWidgetManager
{
    private readonly IWidgetFactory widgetFactory;
    private readonly ILayoutProvider layoutProvider;
    private readonly GridSizeConverter gridSizeConverter;
    private readonly IAppSettingsProvider appSettingsProvider;

    private readonly List<Widget> widgets = new();

    public WidgetManager(IWidgetFactory widgetFactory, ILayoutProvider layoutProvider,
        IAppSettingsProvider appSettingsProvider)
    {
        this.widgetFactory = widgetFactory;
        this.layoutProvider = layoutProvider;
        this.appSettingsProvider = appSettingsProvider;

        gridSizeConverter = new GridSizeConverter(appSettingsProvider);
    }
    
    public void Run()
    {
        foreach (var layout in layoutProvider.Get().OrderBy(layout => layout.Y))
        {
            var widgetSettingsProvider = new WidgetSettingsProvider(layoutProvider, layout.Id);
            
            var widget = widgetFactory.CreateWidget(widgetSettingsProvider);

            widget.WidgetOpened += (_, _) => WidgetEventHandler(widget, widgetSettingsProvider, OnWidgetOpened);
            widget.WidgetClosed += (_, _) => WidgetEventHandler(widget, widgetSettingsProvider, OnWidgetClosed);
            widget.WidgetResized += (_, args) => WidgetEventHandler(widget, widgetSettingsProvider, OnWidgetResize(args.Size));
            widget.WidgetMoved += (_, _) => WidgetEventHandler(widget, widgetSettingsProvider, OnWidgetMoved);
            appSettingsProvider.Updated += (_, _) => WidgetEventHandler(widget, widgetSettingsProvider, OnAppSettingsChanged);

            widgets.Add(widget);
        }

        foreach (var widget in widgets)
        {
            widget.Show();
        }
    }

    private void WidgetEventHandler(Widget widget, IWidgetSettingsProvider widgetSettingsProvider, List<IWidgetAction> actions)
    {
        actions.ForEach(action => action.Run(widget, widgetSettingsProvider));
    }

    private List<IWidgetAction> OnWidgetOpened => new()
    {
        new KeepOnScreenAction(),
        new SnapPositionToGridAction(appSettingsProvider)
    };

    private List<IWidgetAction> OnWidgetClosed => new()
    {
        new RemoveFromListAction(widgets, layoutProvider)
    };

    private List<IWidgetAction> OnWidgetResize(Size? size) => new()
    {
        new SnapSizeToGridAction(appSettingsProvider, size),
        new KeepOnScreenAction(),
        new SnapPositionToGridAction(appSettingsProvider),
        new UpdateSettingsAction(gridSizeConverter),
    };
    
    private List<IWidgetAction> OnWidgetMoved => new()
    {
        new KeepOnScreenAction(),
        new SnapPositionToGridAction(appSettingsProvider),
        new UpdateSettingsAction(gridSizeConverter),
    };

    private List<IWidgetAction> OnAppSettingsChanged => new()
    {
        new SnapSizeToGridAction(appSettingsProvider, null),
        new KeepOnScreenAction(),
        new SnapPositionToGridAction(appSettingsProvider),
        new UpdateSettingsAction(gridSizeConverter),
    };
}