using System.Windows.Controls;
using Shared.Interfaces;

namespace Shared.AppSettingsWindow.Pages;

public partial class AppearancePage : IAppSettingsPage
{
    public IAppSettingsProvider AppSettingsProvider { get; set; }
    public TextBlock CurrentTheme { get; set; } 
    
    public AppearancePage()
    {
        InitializeComponent();
        
        ThemeSelector.SelectionChanged += ChangeTheme;
    }
    
    public void SetDataContext(IAppSettingsProvider appSettingsProvider)
    {
        DataContext = this;
        AppSettingsProvider = appSettingsProvider;
        CurrentTheme = appSettingsProvider.Get().Appearance.UseSystemTheme
            ? SystemTheme
            : appSettingsProvider.Get().Appearance.DarkTheme
                ? DarkTheme
                : LightTheme;
    }

    public void ChangeTheme(object? sender, SelectionChangedEventArgs e)
    {
        if (e.RemovedItems.Count == 0) return;

        if (e.AddedItems[0] is not TextBlock newTheme) return;
        
        var settings = AppSettingsProvider.Get();

        settings.Appearance.UseSystemTheme = newTheme.Name == "SystemTheme";
        settings.Appearance.DarkTheme = newTheme.Name == "DarkTheme";

        AppSettingsProvider.Update(settings);
    }
}