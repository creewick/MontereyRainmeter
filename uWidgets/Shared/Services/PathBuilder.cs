using System.IO;

namespace Shared.Services;

public static class PathBuilder
{
    private static string WidgetsFolderName => "Widgets";
    private static string ResourcesFolderName => "Resources";
    private static string LocalesFolderName => "Locales";
    private static string AppSettingsFileName => "appSettings.json";
    private static string LayoutFileName => "layout.json";
    

    public static string CurrentFolder = Directory.GetCurrentDirectory();
    public static string WidgetsFolder = Path.Combine(CurrentFolder, WidgetsFolderName);
    public static string ResourcesFolder = Path.Combine(CurrentFolder, ResourcesFolderName);
    public static string LocalesFolder = Path.Combine(ResourcesFolder, LocalesFolderName);
    public static string AppSettingsFile = Path.Combine(CurrentFolder, AppSettingsFileName);
    public static string LayoutFile = Path.Combine(CurrentFolder, LayoutFileName);
    
    public static string GetWidgetFile(string widgetName) => Path.Combine(WidgetsFolder, widgetName + ".dll");
    public static string GetLocaleFile(string language) => Path.Combine(LocalesFolder, language + ".json");
}