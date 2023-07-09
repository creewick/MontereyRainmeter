using System;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using uWidgets.Settings.Models;

namespace uWidgets.Settings.Services;

public class WidgetSettingsConverter : JsonConverter<WidgetSettings>
{
    public override WidgetSettings Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var jsonObject = jsonDocument.RootElement;
        var widgetName = jsonObject.GetProperty(nameof(WidgetSettings.Type)).GetString();
        var assembly = Assembly.GetExecutingAssembly();

        var type = assembly
            .GetTypes()
            .FirstOrDefault(type => type.Name.Equals($"{widgetName}Settings") &&
                                    typeof(WidgetSettings).IsAssignableFrom(type));

        if (type == null)
            throw new ArgumentException($"Settings class for widget {widgetName} is not found");

        return (WidgetSettings) (JsonSerializer.Deserialize(jsonObject.GetRawText(), type, options) 
                               ?? throw new FormatException($"Cannot deserialize settings for widget {widgetName}"));
    }

    public override void Write(Utf8JsonWriter writer, WidgetSettings value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}