using System;
using System.IO;
using System.Text.Json;
using uWidgets.Configuration.Interfaces;

namespace uWidgets.Configuration.FileHandlers;

public class FileHandler<T> : IFileHandler<T>
{
    private readonly string filename;
    private readonly string path;
    private T? data;
    
    public FileHandler(string filename)
    {
        this.filename = filename;
        path = Path.Combine(Directory.GetCurrentDirectory(), filename);
    }

    public T Get()
    {
        if (data != null) return data;

        var json = File.ReadAllText(path);

        data = JsonSerializer.Deserialize<T>(json)
               ?? throw new FormatException(nameof(T));

        return data;
    }

    public void Save(T newData)
    {
        data = newData;

        var json = JsonSerializer.Serialize(data);

        File.WriteAllText(path, json);
    }
}