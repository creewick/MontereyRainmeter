using System.IO;
using uWidgets.Configuration.Interfaces;
using uWidgets.Configuration.Models;

namespace uWidgets.Configuration.Providers;

public class SettingsProvider : FileHandler<AppSettings>, ISettingsProvider
{
    public SettingsProvider() : base(Path.Combine("Configuration", "appsettings.json")) { }
}