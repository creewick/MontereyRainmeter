using System.Text.Json.Serialization;
using Shared.Interfaces;
using Shared.Models.AppSettings;

namespace uWidgets.DataManagers;

public class AppSettingsManager : JsonFileParser<AppSettings>, IAppSettingsManager
{
    public AppSettingsManager(string filepath, JsonConverter? jsonConverter = null) : base(filepath, jsonConverter)
    {
    }
}