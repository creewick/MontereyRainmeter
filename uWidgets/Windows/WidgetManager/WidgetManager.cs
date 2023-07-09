using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using uWidgets.Settings.Models;
using uWidgets.Settings.Repositories;
using uWidgets.Windows.Services;
using uWidgets.Windows.WidgetManager.WidgetActions;
using uWidgets.Windows.WidgetManager.WidgetFactory;
using uWidgets.Windows.WindowTypes;

namespace uWidgets.Windows.WidgetManager;

public class WidgetManager : IWidgetManager
{
    private readonly IWidgetFactory widgetFactory;
    private readonly WidgetSettings[] widgetLayouts;
    private readonly AppSettings appSettings;
    private readonly IRepository<WidgetSettings[]> widgetSettingsRepository;
    private readonly GridSizeConverter gridSizeConverter;

    private readonly List<WidgetBase> widgets;

    public WidgetManager(IWidgetFactory widgetFactory, WidgetSettings[] widgetLayouts, AppSettings appSettings,
        IRepository<WidgetSettings[]> widgetSettingsRepository, GridSizeConverter gridSizeConverter)
    {
        this.widgetFactory = widgetFactory;
        this.widgetLayouts = widgetLayouts;
        this.appSettings = appSettings;
        this.widgetSettingsRepository = widgetSettingsRepository;
        this.gridSizeConverter = gridSizeConverter;

        widgets = new List<WidgetBase>();
    }

    public void Run()
    {
        foreach (var widgetLayout in widgetLayouts.OrderBy(widgetLayout => widgetLayout.Y))
        {
            var widget = widgetFactory.CreateWidget(widgetLayout);

            widget.Loaded += (_, _) => HandleEvent(WidgetLoadedActions(), widget);
            widget.WidgetMoved += (_, _) => HandleEvent(WidgetMovedActions(), widget);
            widget.WidgetResized += (size) => HandleEvent(WidgetResizedActions(size), widget);
            widget.Closed += (_, _) => HandleEvent(WidgetClosedActions(), widget);

            widgets.Add(widget);
            widget.Show();
        }
    }
    
    private async Task HandleEvent(IEnumerable<IWidgetAction> actions, WidgetBase widget)
    {
        foreach (var action in actions) 
            await action.Run(widget);
        
        var widgetSettings = widgets
            .Select(w => w.WidgetSettings)
            .ToArray();
        
        widgetSettingsRepository.Save(widgetSettings);
    }

    private IEnumerable<IWidgetAction> WidgetLoadedActions()
    {
        yield return new KeepOnScreenAction();
        yield return new SnapPositionToGridAction(appSettings);
    }

    private IEnumerable<IWidgetAction> WidgetMovedActions()
    {
        yield return new KeepOnScreenAction();
        yield return new SnapPositionToGridAction(appSettings);
        yield return new UpdateSettingsAction(gridSizeConverter);
    }

    private IEnumerable<IWidgetAction> WidgetResizedActions(Size newSize)
    {
        yield return new SnapSizeToGridAction(appSettings, newSize);
        yield return new KeepOnScreenAction();
        yield return new SnapPositionToGridAction(appSettings);
        yield return new UpdateSettingsAction(gridSizeConverter);
    }

    private IEnumerable<IWidgetAction> WidgetClosedActions()
    {
        yield return new RemoveFromListAction(widgets);
    }
}