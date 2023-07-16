using System.Linq;
using System.Windows;
using System.Windows.Media;
using Shared.Interfaces;
using Wpf.Ui.Appearance;
using Wpf.Ui.Markup;

namespace uWidgets.Providers;

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
        Application.Current.MainWindow = new Window();
        
        this.appSettingsProvider = appSettingsProvider;
        this.appSettingsProvider.Updated += (_, _) => Apply();
    }
    
    public void Apply()
    {
        var newDict = new ThemesDictionary { Theme = GetDarkTheme() ? ThemeType.Dark : ThemeType.Light };

        var oldDict = Application.Current.Resources.MergedDictionaries
            .FirstOrDefault(d => d is ThemesDictionary);

        if (oldDict != null)
        {
            Application.Current.Resources.MergedDictionaries.Remove(oldDict);
        }
        Application.Current.Resources.MergedDictionaries.Add(newDict);
    }

    private bool GetDarkTheme()
    {
        return appSettingsProvider.Get().Appearance.UseSystemTheme 
            ? DarkThemes.Contains(Theme.GetSystemTheme()) 
            : appSettingsProvider.Get().Appearance.DarkTheme;
    }

    private Color GetAccentColor()
    {
        return appSettingsProvider.Get().Appearance.UseSystemAccentColor
            ? Accent.GetColorizationColor()
            : (Color)ColorConverter.ConvertFromString(appSettingsProvider.Get().Appearance.AccentColor);
    }
}