using System.Linq;
using System.Windows;
using System.Windows.Media;
using Shared.Interfaces;
using Wpf.Ui.Appearance;

namespace Shared.Themes;

public class WpfUiThemeProvider : IThemeProvider
{
    private readonly IAppSettingsProvider appSettingsProvider;

    private static readonly SystemThemeType[] DarkThemes =
    {
        SystemThemeType.Glow,
        SystemThemeType.Dark,
        SystemThemeType.CapturedMotion
    };
    
    public WpfUiThemeProvider(IAppSettingsProvider appSettingsProvider)
    {
        this.appSettingsProvider = appSettingsProvider;
    }
    
    public void Apply()
    {
        Application.Current.MainWindow = new Window();
        
        Theme.Apply(GetThemeType());
        Accent.Apply(GetAccentColor());
    }

    private ThemeType GetThemeType()
    {
        var darkTheme = appSettingsProvider.Get().Appearance.UseSystemTheme
            ? DarkThemes.Contains(Theme.GetSystemTheme())
            : appSettingsProvider.Get().Appearance.DarkTheme;

        return darkTheme
            ? ThemeType.Dark
            : ThemeType.Light;
    }

    private Color GetAccentColor()
    {
        if (appSettingsProvider.Get().Appearance.UseSystemAccentColor)
            return Accent.GetColorizationColor();
        
        return (Color)ColorConverter.ConvertFromString(appSettingsProvider.Get().Appearance.AccentColor);
    }
}