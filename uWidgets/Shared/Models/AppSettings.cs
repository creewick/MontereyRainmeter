namespace Shared.Models;

public class AppSettings
{
    public AppearanceSettings Appearance { get; set; }
    public BatterySettings Battery { get; set; }
    public RegionSettings Region { get; set; }

    public int WidgetSize => Appearance.WidgetSize;
    public int WidgetMargin => Appearance.WidgetMargin;
    public int WidgetRadius => Appearance.WidgetRadius;
}

public class AppearanceSettings
{
    public bool DarkTheme { get; set; }
    public bool UseSystemTheme { get; set; }
    public bool Transparency { get; set; }
    public string AccentColor { get; set; }
    public bool UseSystemAccentColor { get; set; }
    public bool GridSnap { get; set; }
    public int WidgetSize { get; set; }
    public int WidgetMargin { get; set; }
    public int WidgetRadius { get; set; }
    public string FontFace { get; set; }
}

public class BatterySettings
{
    public bool LowPowerMode { get; set; }
    public bool SystemPowerMode { get; set; }
}

public class RegionSettings
{
    public string Language { get; set; }
    public string Temperature { get; set; }
}