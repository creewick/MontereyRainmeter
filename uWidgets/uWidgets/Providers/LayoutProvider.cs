using System;
using Shared.Interfaces;
using Shared.Models;
using Shared.Services;
using uWidgets.Services;

namespace uWidgets.Providers;

public class LayoutProvider : ILayoutProvider
{
    public event EventHandler<WidgetSettings[]>? Updated;
    
    public LayoutProvider(IClassActivator classActivator)
    {
        jsonFileParser = new JsonFileParser<WidgetSettings[]>(PathBuilder.LayoutFile, new WidgetSettingsConverter(classActivator));
    }
    
    private readonly JsonFileParser<WidgetSettings[]> jsonFileParser;

    public WidgetSettings[] Get() => jsonFileParser.Read();

    public void Update(WidgetSettings[] newData)
    {
        jsonFileParser.Write(newData);
        Updated?.Invoke(this, newData);
    }
}