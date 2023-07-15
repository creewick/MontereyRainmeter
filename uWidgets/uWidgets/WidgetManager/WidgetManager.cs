using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Shared.Interfaces;
using Shared.Services;
using Shared.Templates;
using uWidgets.Providers;
using uWidgets.WidgetActions;
using uWidgets.WidgetFactory;

namespace uWidgets.WidgetManager;

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

            widget.WidgetOpened += (_, args) => WidgetEventHandler(args.Widget, OnWidgetOpened);
            widget.WidgetClosed += (_, args) => WidgetEventHandler(args.Widget, OnWidgetClosed);
            widget.WidgetResized += (_, args) => WidgetEventHandler(args.Widget, OnWidgetResize);
            widget.WidgetMoved += (_, args) => WidgetEventHandler(args.Widget, OnWidgetMove);

            widgets.Add(widget);
            widget.Show();
        }
    }

    private void WidgetEventHandler(Widget widget, List<IWidgetAction> actions)
    {
        foreach (var action in actions)
        {
            action.Run(widget);
        }
        
        // layoutProvider.Update();
    }

    private List<IWidgetAction> OnWidgetOpened => new()
    {
        new KeepOnScreenAction(),
        new SnapPositionToGridAction(appSettingsProvider)
    };

    private List<IWidgetAction> OnWidgetClosed => new()
    {
        new RemoveFromListAction(widgets)
    };

    private List<IWidgetAction> OnWidgetResize => new()
    {
        new SnapSizeToGridAction(appSettingsProvider, new Size()),
        new KeepOnScreenAction(),
        new SnapPositionToGridAction(appSettingsProvider)
    };
    
    private List<IWidgetAction> OnWidgetMove => new()
    {
        new KeepOnScreenAction(),
        new SnapPositionToGridAction(appSettingsProvider),
        new UpdateSettingsAction(gridSizeConverter),
    };
}