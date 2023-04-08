using System;
using System.Linq;
using System.Windows;
using uWidgets.Models;
using Wpf.Ui.Appearance;

namespace uWidgets.Themes;

public static class ThemeFactory
{
    public static ITheme GetTheme(AppearanceSettings settings)
    {
        if (settings.SystemTheme)
        {
            settings.DarkTheme = new[]
            {
                SystemThemeType.Glow,
                SystemThemeType.Dark,
                SystemThemeType.CapturedMotion
            }.Contains(Theme.GetSystemTheme());

            Application.Current.MainWindow = new Window();
            Theme.Apply(settings.DarkTheme ? ThemeType.Dark : ThemeType.Light);
        }

        return settings switch
        {
            { Transparency: false, DarkTheme: false } => new LightTheme(settings),
            { Transparency: false, DarkTheme: true } => new DarkTheme(settings),
            { Transparency: true, DarkTheme: false } => new TransparentLightTheme(settings),
            { Transparency: true, DarkTheme: true } => new TransparentDarkTheme(settings),
            _ => throw new ArgumentException(nameof(settings))
        };
    }

    public static void ApplyTheme(AppearanceSettings settings)
    {
        if (settings.SystemTheme)
        {
            settings.DarkTheme = new[]
            {
                SystemThemeType.Glow,
                SystemThemeType.Dark,
                SystemThemeType.CapturedMotion
            }.Contains(Theme.GetSystemTheme());
        }
        
        
        Application.Current.MainWindow = new Window();
        Theme.Apply(settings.DarkTheme ? ThemeType.Dark : ThemeType.Light);

        // return settings switch
        // {
        //     { Transparency: false, DarkTheme: false } => new LightTheme(settings),
        //     { Transparency: false, DarkTheme: true } => new DarkTheme(settings),
        //     { Transparency: true, DarkTheme: false } => new TransparentLightTheme(settings),
        //     { Transparency: true, DarkTheme: true } => new TransparentDarkTheme(settings),
        //     _ => throw new ArgumentException(nameof(settings))
        // };
    }
}