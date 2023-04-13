using System;
using System.Diagnostics;
using System.Text.Json;
using uWidgets.UserInterface.Models;
using uWidgets.Widgets.Clock.Controls;

namespace uWidgets.Widgets.Clock;

public partial class Clock
{
    public Clock(WidgetContext context) : base(context)
    {
        InitializeComponent();
        
        var clockSettings = Context.Layout.Options?.Deserialize<ClockSettings>() 
                            ?? throw new FormatException(nameof(ClockSettings));

        SourceInitialized += (_, _) =>
        {
            BackgroundElement.Child = clockSettings.Analog
                ? new AnalogClock(clockSettings, context.Settings)
                : new DigitalClock(clockSettings, context.Settings);
        };

        MouseDoubleClick += (_,_) => Process.Start("explorer.exe", @"shell:AppsFolder\Microsoft.WindowsAlarms_8wekyb3d8bbwe!App");
    }
}