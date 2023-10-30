using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Shared.Models;
using uWidgets.Services;

namespace uWidgets.DataManagers;

public class WidgetSettingsConverter : JsonConverter<WidgetSettings>
{
    public override WidgetSettings? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var jsonObject = jsonDocument.RootElement;
        var widgetType = jsonObject.GetProperty(nameof(WidgetSettings.Type)).GetString() ?? "";
        var widgetSettingsType = WidgetFactory.GetWidgetSettingsType(widgetType);

        return (WidgetSettings) (JsonSerializer.Deserialize(jsonObject.GetRawText(), widgetSettingsType, options) 
                                 ?? throw new FormatException($"Cannot deserialize settings for widget {widgetType}"));
    }

    public override void Write(Utf8JsonWriter writer, WidgetSettings value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}