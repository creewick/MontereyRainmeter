using uWidgets.Settings.Models;

namespace uWidgets.Widgets.Clock;

public class ClockSettings : WidgetSettings
{
    public bool Analog { get; set; }
    public bool ShowSeconds { get; set; }
    public bool ShowAmPm { get; set; }
}