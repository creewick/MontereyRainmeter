using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Shared.Interfaces.DataManagers;
using Shared.Models;

namespace uWidgets.DataManagers;

public class WidgetSettingsManager : JsonFileParser<IEnumerable<WidgetSettings>>, IWidgetSettingsManager
{
    public WidgetSettingsManager(string filepath, JsonConverter? jsonConverter = null) : base(filepath, jsonConverter) { }
    
    public WidgetSettings? Get(Guid id) => Get().FirstOrDefault(widgetSettings => widgetSettings.Id == id);

    public void Update(WidgetSettings widgetSettings)
    {
        var newData = Get()
            .Where(oldSettings => oldSettings.Id != widgetSettings.Id)
            .Append(widgetSettings);
        
        Update(newData);
    }
}