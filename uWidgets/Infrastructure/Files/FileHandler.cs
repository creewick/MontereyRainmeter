using System;
using System.IO;
using System.Text.Json;

namespace uWidgets.Infrastructure.Files;

public class FileHandler<T> : IFileHandler<T>
{
    private readonly string path;
    private T? data;

    public FileHandler(string filename)
    {
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