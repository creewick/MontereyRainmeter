using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Shared.Interfaces;

namespace uWidgets.DataManagers;

public class JsonFileParser<T> : IDataManager<T>
{
    private readonly JsonSerializerOptions options;
    private readonly string filepath;
    private T? data;

    public JsonFileParser(string filepath, JsonConverter? jsonConverter = null)
    {
        this.filepath = filepath;
        
        options = new JsonSerializerOptions();
        if (jsonConverter != null) options.Converters.Add(jsonConverter);
    }
    
    public event EventHandler<T>? Updated;
    
    public T Get()
    {
        if (data != null) return data;
        
        //TODO potential ArgumentNullException
        var json = File.ReadAllText(filepath);
        
        data = JsonSerializer.Deserialize<T>(json, options) 
               ?? throw new FormatException(nameof(T));

        return data;
    }

    public void Update(T newData)
    {
        data = newData;
        
        var json = JsonSerializer.Serialize(newData, options);
        
        File.WriteAllText(filepath, json);
        
        Updated?.Invoke(this, newData);
    }
}