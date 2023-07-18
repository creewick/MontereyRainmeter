using System.Windows.Controls;
using System.Windows.Navigation;
using Shared.AppSettingsWindow.Pages;
using Shared.Interfaces;
using Wpf.Ui.Appearance;

namespace Shared.AppSettingsWindow;

public partial class AppSettingsWindow
{
    public AppSettingsWindow(IAppSettingsProvider settingsProvider)
    {
        InitializeComponent();
        
        Wpf.Ui.Appearance.Background.Apply(this, BackgroundType.Acrylic);
        
        RootNavigation.Loaded += (_, _) => RootNavigation.Navigate(0);
        Frame.Navigated += (_, e) => ((IAppSettingsPage)e.Content).SetDataContext(settingsProvider);
        Deactivated += (_, _) => Wpf.Ui.Appearance.Background.Remove(this);
        Activated += (_, _) => Wpf.Ui.Appearance.Background.Apply(this, BackgroundType.Acrylic);
    }
}