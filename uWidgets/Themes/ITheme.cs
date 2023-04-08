using System.Windows.Media;
using Wpf.Ui.Appearance;

namespace uWidgets.Themes;

public interface ITheme
{ 
    Color GetBackgroundColor();
    Color GetForegroundColor();
    Color GetAccentColor();
    ThemeType GetThemeType();
}