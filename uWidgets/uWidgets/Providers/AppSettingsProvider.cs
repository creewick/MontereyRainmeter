using System;
using Shared.Interfaces;
using Shared.Models;
using Shared.Services;
using uWidgets.Services;

namespace uWidgets.Providers;

public class AppSettingsProvider : IAppSettingsProvider
{
    public event EventHandler<AppSettings>? Updated;
    
    private readonly JsonFileParser<AppSettings> jsonFileParser = new(PathBuilder.AppSettingsFile);

    public AppSettings Get() => jsonFileParser.Read();

    public void Update(AppSettings newData)
    {
        jsonFileParser.Write(newData);
        Updated?.Invoke(this, newData);
    }
}