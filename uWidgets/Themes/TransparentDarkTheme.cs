using System.Windows.Media;
using uWidgets.Models;
using Wpf.Ui.Appearance;

namespace uWidgets.Themes;

public class TransparentDarkTheme : ITheme
{
    private Color Accent { get; set; }
    
    public TransparentDarkTheme(AppearanceSettings settings)
    {
        Accent = (Color)ColorConverter.ConvertFromString(settings.AccentColor);
    }
    
    public Color GetBackgroundColor() => Color.FromArgb(1, 30, 30, 30);

    public Color GetForegroundColor() => Color.FromArgb(255, 255, 255, 255);
    public Color GetAccentColor() => Accent;
    public ThemeType GetThemeType() => ThemeType.Dark;
}