using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Shared.Interfaces;
using Wpf.Ui.Controls;

namespace Shared.AppSettingsWindow.Pages;

public partial class AppearancePage : IPage, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    public IAppSettingsProvider AppSettingsProvider { get; set; }
    public TextBlock CurrentTheme { get; set; } 
    public TextBlock CurrentAccentType { get; set; }
    public Visibility ShowTemplateColors { get; set; }
    public bool Transparency { get; set; }
    public bool GridSnap { get; set; }
    public double WidgetSize { get; set; }
    public double WidgetMargin { get; set; }
    public double WidgetRadius { get; set; }

    public List<string> Colors => new() { "#3478F6", "#8B4291", "#E55C9C", "#CE4744", "#E8883A", "#F6C94E", "#78B856", "#989898" };

    public AppearancePage()
    {
        InitializeComponent();
        
        ThemeSelector.SelectionChanged += ChangeTheme;
        AccentTypeSelector.SelectionChanged += ChangeAccentType;
        AccentColorSelector.SelectionChanged += ChangeAccentColor;
        TransparencySelector.Click += ChangeTransparency;
        GridSnapSelector.Click += ChangeGridSnap;
        WidgetSizeSelector.SelectionChanged += ChangeWidgetSize;
        WidgetMarginSelector.SelectionChanged += ChangeWidgetMargin;
        WidgetRadiusSelector.SelectionChanged += ChangeWidgetRadius;
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
        CurrentAccentType = appSettingsProvider.Get().Appearance.UseSystemTheme
            ? SystemColor
            : TemplateColor;
        ShowTemplateColors = CurrentAccentType == TemplateColor ? Visibility.Visible : Visibility.Collapsed;
        Transparency = appSettingsProvider.Get().Appearance.Transparency;
        GridSnap = appSettingsProvider.Get().Appearance.GridSnap;
        WidgetSize = appSettingsProvider.Get().Appearance.WidgetSize;
        WidgetMargin = appSettingsProvider.Get().Appearance.WidgetMargin;
        WidgetRadius = appSettingsProvider.Get().Appearance.WidgetRadius;
    }

    public void ChangeTheme(object? sender, SelectionChangedEventArgs e)
    {
        if (e.RemovedItems.Count == 0) return;
        if (e.AddedItems[0] is not TextBlock newTheme) return;
        
        var settings = AppSettingsProvider.Get();

        settings.Appearance.UseSystemTheme = newTheme.Name == "SystemTheme";
        settings.Appearance.DarkTheme = newTheme.Name == "DarkTheme";

        AppSettingsProvider.Update(settings);
        Update();
    }

    public void ChangeAccentType(object? sender, SelectionChangedEventArgs e)
    {
        if (e.RemovedItems.Count == 0) return;
        if (e.AddedItems[0] is not TextBlock newAccentType) return;

        CurrentAccentType = newAccentType;
        ShowTemplateColors = CurrentAccentType == TemplateColor ? Visibility.Visible : Visibility.Collapsed;

        var settings = AppSettingsProvider.Get();
        settings.Appearance.UseSystemAccentColor = newAccentType == SystemColor;
        AppSettingsProvider.Update(settings);
        Update();
    }
    
    public void ChangeAccentColor(object? sender, SelectionChangedEventArgs e)
    {
        if (e.AddedItems[0] is not string color) return;
        
        var settings = AppSettingsProvider.Get();

        settings.Appearance.UseSystemAccentColor = false;
        settings.Appearance.AccentColor = color;

        AppSettingsProvider.Update(settings);
        Update();
    }

    public void ChangeTransparency(object? sender, RoutedEventArgs e)
    {
        var settings = AppSettingsProvider.Get();

        settings.Appearance.Transparency = Transparency;
        
        AppSettingsProvider.Update(settings);
        Update();
    }
    
    public void ChangeGridSnap(object? sender, RoutedEventArgs e)
    {
        var settings = AppSettingsProvider.Get();

        settings.Appearance.GridSnap = GridSnap;
        
        AppSettingsProvider.Update(settings);
        Update();
    }
    
    public void ChangeWidgetSize(object? sender, RoutedEventArgs e)
    {
        var settings = AppSettingsProvider.Get();

        if (WidgetSizeSelector.Value < 10) return;

        settings.Appearance.WidgetSize = (int) WidgetSizeSelector.Value;
        
        AppSettingsProvider.Update(settings);
        Update();
    }
    
    public void ChangeWidgetMargin(object? sender, RoutedEventArgs e)
    {
        var settings = AppSettingsProvider.Get();

        if (WidgetMarginSelector.Value < 0) return;

        settings.Appearance.WidgetMargin = (int) WidgetMarginSelector.Value;
        
        AppSettingsProvider.Update(settings);
        Update();
    }
    
    public void ChangeWidgetRadius(object? sender, RoutedEventArgs e)
    {
        var settings = AppSettingsProvider.Get();

        if (WidgetRadiusSelector.Value < 0) return;

        settings.Appearance.WidgetRadius = (int) WidgetRadiusSelector.Value;
        
        AppSettingsProvider.Update(settings);
        Update();
    }

    private void Update() => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
}