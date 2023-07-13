using Shared.Models;

namespace Clock;

public class ClockSettings : WidgetSettings
{
    public bool ShowSeconds { get; set; }
    public bool ShowAmPm { get; set; }
}