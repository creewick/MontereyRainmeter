using System.IO;
using uWidgets.Settings.Models;
using uWidgets.Settings.Services;

namespace uWidgets.Settings.Repositories;

public class AppSettingsRepository : JsonFileParser<AppSettings>
{
    public AppSettingsRepository() : base(Path.Combine("Settings", "appSettings.json"))
    {
    }
}