using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace uWidgets.Services;

public class JsonFileParser<T>
{
    private readonly JsonConverter? jsonConverter;
    private readonly string filePath;
    private T? data;

    public JsonFileParser(string path, JsonConverter? jsonConverter = null)
    {
        this.jsonConverter = jsonConverter;
        filePath = path;
    }

    public T Read()
    {
        if (data != null) return data;

        var json = File.ReadAllText(filePath);
        
        var options = new JsonSerializerOptions();
        
        if (jsonConverter != null) options.Converters.Add(jsonConverter);

        data = JsonSerializer.Deserialize<T>(json, options)
               ?? throw new FormatException(nameof(T));

        return data;
    }

    public void Write(T newData)
    {
        data = newData;
        
        var options = new JsonSerializerOptions();
        
        if (jsonConverter != null) options.Converters.Add(jsonConverter);

        var json = JsonSerializer.Serialize(newData, options);
        
        File.WriteAllText(filePath, json);
    }
}