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
        
        settingsProvider.Updated += (_, _) =>
        {
            Activate();
            Wpf.Ui.Appearance.Background.Remove(this);
            Wpf.Ui.Appearance.Background.Apply(this, BackgroundType.Acrylic);
        };
        
        RootNavigation.Loaded += (_, _) => RootNavigation.Navigate(0);
        Frame.Navigated += (_, e) => ((IPage)e.Content).SetDataContext(settingsProvider);
    }
}