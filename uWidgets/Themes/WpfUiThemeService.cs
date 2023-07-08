using System.Linq;
using System.Windows;
using System.Windows.Media;
using uWidgets.Settings.Models;
using Wpf.Ui.Appearance;

namespace uWidgets.Themes;

public class WpfUiThemeService : IThemeService
{
    private readonly AppSettings settings;

    private static readonly SystemThemeType[] DarkThemes =
    {
        SystemThemeType.Glow,
        SystemThemeType.Dark,
        SystemThemeType.CapturedMotion
    };
    
    public WpfUiThemeService(AppSettings settings)
    {
        this.settings = settings;
    }
    
    public void Apply()
    {
        Application.Current.MainWindow = new Window();
        
        Theme.Apply(GetThemeType());
        Accent.Apply(GetAccentColor());
    }

    private ThemeType GetThemeType()
    {
        var darkTheme = settings.Appearance.UseSystemTheme
            ? DarkThemes.Contains(Theme.GetSystemTheme())
            : settings.Appearance.DarkTheme;

        return darkTheme
            ? ThemeType.Dark
            : ThemeType.Light;
    }

    private Color GetAccentColor()
    {
        if (settings.Appearance.UseSystemAccentColor)
            return Accent.GetColorizationColor();
        
        return (Color)ColorConverter.ConvertFromString(settings.Appearance.AccentColor);
    }
}