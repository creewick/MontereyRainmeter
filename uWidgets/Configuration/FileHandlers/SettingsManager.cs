using System.IO;
using uWidgets.Configuration.Interfaces;
using uWidgets.Configuration.Models;

namespace uWidgets.Configuration.FileHandlers;

public class SettingsManager : FileHandler<AppSettings>, ISettingsManager
{
    public SettingsManager() : base(Path.Combine("Configuration", "appsettings.json")) { }
}