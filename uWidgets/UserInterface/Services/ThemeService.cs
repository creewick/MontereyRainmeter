using System.Linq;
using System.Windows;
using System.Windows.Media;
using uWidgets.Configuration.Models;
using uWidgets.UserInterface.Interfaces;
using Wpf.Ui.Appearance;

namespace uWidgets.UserInterface.Services;

public class ThemeService : IThemeService
{
    private AppearanceSettings Settings { get; }

    public ThemeService(AppSettings settings)
    {
        Settings = settings.Appearance;
    }
    
    private static readonly SystemThemeType[] DarkThemes = {
        SystemThemeType.Glow,
        SystemThemeType.Dark,
        SystemThemeType.CapturedMotion
    };

    public void Apply()
    {
        if (Settings.SystemTheme) 
            Settings.DarkTheme = DarkThemes.Contains(Theme.GetSystemTheme());

        var themeType = Settings.DarkTheme ? ThemeType.Dark : ThemeType.Light;
        var accentColor = (Color)ColorConverter.ConvertFromString(Settings.AccentColor);

        Application.Current.MainWindow = new Window();
        Theme.Apply(themeType);
        
        if (Settings.SystemAccentColor)
            Accent.ApplySystemAccent();
        else
            Accent.Apply(accentColor, themeType);
    }
}