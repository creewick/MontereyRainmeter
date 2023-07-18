using Shared.Interfaces;
using Wpf.Ui.Appearance;

namespace Shared.Windows;

public partial class AppSettingsWindow
{
    private readonly IAppSettingsProvider settingsProvider;

    public AppSettingsWindow(IAppSettingsProvider settingsProvider)
    {
        this.settingsProvider = settingsProvider;
        InitializeComponent();
        Wpf.Ui.Appearance.Background.Apply(this, BackgroundType.Acrylic);
        RootNavigation.Loaded += (_, _) => RootNavigation.Navigate(0);

        Deactivated += (_, _) => Wpf.Ui.Appearance.Background.Remove(this);
        Activated += (_, _) => Wpf.Ui.Appearance.Background.Apply(this, BackgroundType.Acrylic);
    }
}