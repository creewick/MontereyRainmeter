using System.Linq;
using System.Windows.Media;
using uWidgets.Infrastructure.Models;
using Wpf.Ui.Appearance;

namespace uWidgets.Utilities;

public static class ThemeBuilder
{
    private static readonly SystemThemeType[] DarkThemes = {
        SystemThemeType.Glow,
        SystemThemeType.Dark,
        SystemThemeType.CapturedMotion
    };

    public static void Apply(AppearanceSettings settings)
    {
        if (settings.SystemTheme) 
            settings.DarkTheme = DarkThemes.Contains(Theme.GetSystemTheme());

        var themeType = settings.DarkTheme ? ThemeType.Dark : ThemeType.Light;
        var accentColor = (Color)ColorConverter.ConvertFromString(settings.AccentColor);

        Theme.Apply(themeType);
        
        if (settings.SystemAccentColor)
            Accent.ApplySystemAccent();
        else
            Accent.Apply(accentColor, themeType);

    }
}