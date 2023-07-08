using System.Diagnostics;
using Microsoft.Extensions.Localization;
using uWidgets.Settings.Models;
using uWidgets.Windows.Services;

namespace uWidgets.Widgets.Clock;

public partial class ClockWindow
{
    public ClockWindow(AppSettings appSettings, ClockSettings widgetSettings, IStringLocalizer locale) 
        : base(appSettings, widgetSettings, locale)
    {
        InitializeComponent();
        
        MouseDoubleClick += (_, _) => Process.Start("explorer.exe", 
            @"shell:AppsFolder\Microsoft.WindowsAlarms_8wekyb3d8bbwe!App");
    }
}