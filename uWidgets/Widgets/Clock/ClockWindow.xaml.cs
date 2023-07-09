using System.Diagnostics;
using Microsoft.Extensions.Localization;
using uWidgets.Settings.Models;

namespace uWidgets.Widgets.Clock;

public partial class ClockWindow
{
    public ClockWindow(AppSettings appSettings, ClockSettings widgetSettings, IStringLocalizer locale) 
        : base(appSettings, widgetSettings, locale)
    {
        InitializeComponent();
        DataContext = new ClockViewModel(appSettings, widgetSettings);
        
        MouseDoubleClick += (_, _) => Process.Start("explorer.exe", 
            @"shell:AppsFolder\Microsoft.WindowsAlarms_8wekyb3d8bbwe!App");
    }
}