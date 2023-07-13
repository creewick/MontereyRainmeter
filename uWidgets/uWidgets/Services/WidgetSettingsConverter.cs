using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Shared.Interfaces;
using Shared.Models;
using Shared.Services;

namespace uWidgets.Services;

public class WidgetSettingsConverter : JsonConverter<WidgetSettings>
{
    private readonly IClassActivator classActivator;
    public WidgetSettingsConverter(IClassActivator classActivator)
    {
        this.classActivator = classActivator;
    }
    
    public override WidgetSettings Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var jsonObject = jsonDocument.RootElement;
        var widgetName = jsonObject.GetProperty(nameof(WidgetSettings.Type)).GetString();
        var assemblyPath = PathBuilder.GetWidgetFile(widgetName ?? string.Empty);
        var type = classActivator.GetType(assemblyPath, typeof(WidgetSettings));

        return (WidgetSettings) (JsonSerializer.Deserialize(jsonObject.GetRawText(), type, options) 
                                 ?? throw new FormatException($"Cannot deserialize settings for widget {widgetName}"));
    }

    public override void Write(Utf8JsonWriter writer, WidgetSettings value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}