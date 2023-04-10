namespace uWidgets.Infrastructure.Models;

public class AppSettings
{
    public AppearanceSettings Appearance { get; set; }
    public BatterySettings Battery { get; set; }
    public RegionSettings Region { get; set; }

    public int WidgetSize => Appearance.WidgetSize;
    public int WidgetPadding => Appearance.WidgetPadding;
    public int WidgetRadius => Appearance.WidgetRadius;
}


public class AppearanceSettings
{
    public bool DarkTheme { get; set; }
    public bool SystemTheme { get; set; }
    public bool Transparency { get; set; }
    public string AccentColor { get; set; }
    public bool SystemAccentColor { get; set; }
    public bool GridSnap { get; set; }
    public int WidgetSize { get; set; }
    public int WidgetPadding { get; set; }
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