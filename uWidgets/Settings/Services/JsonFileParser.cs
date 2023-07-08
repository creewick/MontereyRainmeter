using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using uWidgets.Settings.Repositories;

namespace uWidgets.Settings.Services;

public abstract class JsonFileParser<T> : IRepository<T>
{
    private readonly JsonConverter? jsonConverter;
    private readonly string filePath;
    private T? data;

    protected JsonFileParser(string path, JsonConverter? jsonConverter = null)
    {
        this.jsonConverter = jsonConverter;
        filePath = Path.Combine(Directory.GetCurrentDirectory(), path);
    }

    public T Get()
    {
        if (data != null) return data;

        var json = File.ReadAllText(filePath);
        
        var options = new JsonSerializerOptions();
        
        if (jsonConverter != null) options.Converters.Add(jsonConverter);

        data = JsonSerializer.Deserialize<T>(json, options)
               ?? throw new FormatException(nameof(T));

        return data;
    }

    public void Save(T newData)
    {
        data = newData;

        var json = JsonSerializer.Serialize(newData);
        
        File.WriteAllText(filePath, json);
    }
}