using System.Windows.Media;
using uWidgets.Models;
using Wpf.Ui.Appearance;

namespace uWidgets.Themes;

public class TransparentLightTheme : ITheme
{
    private Color Accent { get; set; }
    
    public TransparentLightTheme(AppearanceSettings settings)
    {
        Accent = (Color)ColorConverter.ConvertFromString(settings.AccentColor);
    }

    public Color GetBackgroundColor() => Color.FromArgb(1, 255, 255, 255);

    public Color GetForegroundColor() => Color.FromArgb(255, 0, 0, 0);
    
    public Color GetAccentColor() => Accent;
    
    public ThemeType GetThemeType() => ThemeType.Light;
}