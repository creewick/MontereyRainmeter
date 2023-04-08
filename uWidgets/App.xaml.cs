using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using uWidgets.Models;
using uWidgets.Utilities;
using uWidgets.Widgets;
using Localization = uWidgets.Models.Localization;

namespace uWidgets;

public partial class App : Application
{
    private const string SettingsFileName = "appsettings.json";
    private const string LayoutFileName = "layout.json";
    private const string LocaleFileName = "locale.json";

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        
        // Workaround to make Wpf.Ui.Appearance.Theme.Apply work
        Current.MainWindow = new Window();
        
        var settingsJson = ReadAllText(SettingsFileName);
        var settings = JsonSerializer.Deserialize<Settings>(settingsJson) ?? throw new FileFormatException();
        ThemeBuilder.Apply(settings.Appearance);

        var layoutJson = ReadAllText(LayoutFileName);
        var layout = JsonSerializer.Deserialize<IEnumerable<WidgetLayout>>(layoutJson) ?? throw new FileFormatException();

        var localeJson = ReadAllText(LocaleFileName);
        var localization = JsonSerializer.Deserialize<Localization>(localeJson) ?? throw new FileFormatException();
        var locale = localization.Locale[settings.Region.Language] ?? throw new ArgumentException(nameof(settings.Region.Language));

        var widgets = layout.Select(widgetLayout => WidgetFactory.GetWidget(widgetLayout, settings, locale)).ToList();
    }
    
    private static string ReadAllText(string fileName)
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), fileName);
        return File.ReadAllText(path);
    }
}