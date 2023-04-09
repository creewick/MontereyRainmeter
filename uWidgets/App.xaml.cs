using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;
using uWidgets.Models;
using uWidgets.Utilities;
using uWidgets.Widgets;

namespace uWidgets;

public partial class App
{
    private const string SettingsFileName = "appsettings.json";
    private const string LayoutFileName = "layout.json";
    private const string LocaleFileName = "locale.json";

    private List<Widget> widgets;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        
        // Workaround to make Wpf.Ui.Appearance.Theme.Apply work
        Current.MainWindow = new Window();

        var settings = DeserializeFromFile<Settings>(SettingsFileName);

        ThemeBuilder.Apply(settings.Appearance);

        var layout = DeserializeFromFile<List<WidgetLayout>>(LayoutFileName);
        var locale = DeserializeFromFile<Locale>(LocaleFileName);
        var localeStrings = locale.LocaleStrings[settings.Region.Language];

        widgets = layout
            .Select(widgetLayout => WidgetFactory.GetWidget(widgetLayout, settings, localeStrings))
            .ToList();
        
        widgets.ForEach(widget => widget.UpdateLayoutEvent += UpdateLayout);
    }

    private static T DeserializeFromFile<T>(string fileName)
    {
        var path = Path.Combine(
            Directory.GetCurrentDirectory(),
            fileName
        );

        var file = File.ReadAllText(path);

        return JsonSerializer.Deserialize<T>(file) 
               ?? throw new FileFormatException();
    }

    private void UpdateLayout()
    {
        var widgetsLayout = widgets.Select(widget => widget.Layout).ToList();
        var json = JsonSerializer.Serialize(widgetsLayout);
        var path = Path.Combine(
            Directory.GetCurrentDirectory(),
            LayoutFileName
        );
        
        File.WriteAllText(path, json);
    }
}