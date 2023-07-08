using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using uWidgets.Settings.Models;
using Wpf.Ui.Appearance;
using Wpf.Ui.Extensions;

namespace uWidgets.Windows.WindowTypes;

public class WindowBase : Window
{
    private readonly AppSettings appSettings;

    public WindowBase(AppSettings appSettings)
    {
        this.appSettings = appSettings;
        
        WindowStyle = WindowStyle.None;
        AllowsTransparency = true;
        Background = new SolidColorBrush(Colors.Transparent);
        
        SourceInitialized += OnSourceInitialized;
    }

    private void OnSourceInitialized(object? sender, EventArgs e)
    {
        if (appSettings.Appearance.Transparency)
            ApplyTransparency();

        DrawBackground();
    }
    
    private void DrawBackground()
    {
        var isTransparent = appSettings.Appearance.Transparency;
        var color = (Color) Application.Current.Resources["ApplicationBackgroundColor"];
        if (isTransparent) color.A = 64;

        var border = new Border
        {
            Background = new SolidColorBrush(color),
            CornerRadius = new CornerRadius(isTransparent ? 0 : appSettings.WidgetRadius)
        };

        var content = Content as UIElement;
        Content = border;
        border.Child = content;
    }

    private void ApplyTransparency()
    {
        var corners = appSettings.Appearance.WidgetRadius switch
        {
            0 => WindowCornerPreference.DoNotRound,
            < 8 => WindowCornerPreference.RoundSmall,
            _ => WindowCornerPreference.Round
        };

        this.ApplyCorners(corners);
        Wpf.Ui.Appearance.Background.Apply(this, BackgroundType.Acrylic);
    }
}