using System.IO;
using uWidgets.Settings.Models;
using uWidgets.Settings.Services;

namespace uWidgets.Settings.Repositories;

public class WidgetSettingsRepository : JsonFileParser<WidgetSettings[]>
{
    public WidgetSettingsRepository() : base(Path.Combine("Settings", "layout.json"), new WidgetSettingsConverter())
    {
    }
}