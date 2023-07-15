using System;
using System.Linq;
using Shared.Interfaces;
using Shared.Models;

namespace uWidgets.Providers;

public class WidgetSettingsProvider : IWidgetSettingsProvider
{
    public event EventHandler<WidgetSettings>? Updated;
    
    private readonly ILayoutProvider layoutProvider;
    private readonly Guid id;
    private WidgetSettings widgetSettings;

    public WidgetSettingsProvider(ILayoutProvider layoutProvider, Guid id)
    {
        this.layoutProvider = layoutProvider;
        this.id = id;
        
        widgetSettings = layoutProvider.Get().First(x => x.Id == id);
        layoutProvider.Updated += LayoutUpdated;
    }

    public WidgetSettings Get() => widgetSettings;

    public void Update(WidgetSettings newData)
    {
        widgetSettings = newData;

        var layoutData = layoutProvider.Get();
        var newLayoutData = layoutData
            .Select(x => x.Id != newData.Id ? x : newData)
            .ToArray();

        layoutProvider.Update(newLayoutData);
    }

    private void LayoutUpdated(object? _, WidgetSettings[] updated)
    {
        widgetSettings = updated.First(x => x.Id == id);
        Updated?.Invoke(this, widgetSettings);
    }
}