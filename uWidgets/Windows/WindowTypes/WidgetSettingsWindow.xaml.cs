using uWidgets.Settings.Models;

namespace uWidgets.Windows.WindowTypes;

public partial class WidgetSettingsWindow
{
    public WidgetSettingsWindow(AppSettings appSettings) : base(appSettings)
    {
        InitializeComponent();
    }
}