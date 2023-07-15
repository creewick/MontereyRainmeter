using Shared.Models;

namespace Clock.Models;

public class ClockSettings : WidgetSettings
{
    public bool ShowSeconds { get; set; }
    public bool ShowAmPm { get; set; }
}