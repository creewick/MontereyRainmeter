using System.Collections.Generic;
using System.Linq;
using Shared.Interfaces;
using Shared.Models;
using uWidgets.WidgetFactory;

namespace uWidgets.WidgetManager;

public class WidgetManager : IWidgetManager
{
    private readonly IWidgetFactory widgetFactory;
    private readonly ILayoutProvider layoutProvider;
    private readonly IAppSettingsProvider appSettingsProvider;

    private readonly List<Widget> widgets = new();

    public WidgetManager(IWidgetFactory widgetFactory, ILayoutProvider layoutProvider,
        IAppSettingsProvider appSettingsProvider)
    {
        this.widgetFactory = widgetFactory;
        this.layoutProvider = layoutProvider;
        this.appSettingsProvider = appSettingsProvider;
    }
    
    public void Run()
    {
        foreach (var layout in layoutProvider.Get().OrderBy(layout => layout.Y))
        {
            var widget = widgetFactory.CreateWidget(layout);

            widgets.Add(widget);
            widget.Show();
        }
    }
}