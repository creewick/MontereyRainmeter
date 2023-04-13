using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using uWidgets.Configuration.Models;
using Wpf.Ui.Appearance;
using Wpf.Ui.Extensions;

namespace uWidgets.WindowManagement.WindowTypes;

public abstract class WindowBase : Window
{
    protected WindowBase(AppSettings settings)
    {
        Settings = settings;

        WindowStyle = WindowStyle.None;
        AllowsTransparency = true;
        Background = new SolidColorBrush(Colors.Transparent);

        SourceInitialized += OnSourceInitialized;
    }

    protected AppSettings Settings { get; }
    public Border BackgroundElement { get; set; }

    private void OnSourceInitialized(object? sender, EventArgs e)
    {
        if (Settings.Appearance.Transparency)
            ApplyTransparency();

        DrawBackground();
    }

    private void DrawBackground()
    {
        var isTransparent = Settings.Appearance.Transparency;
        var color = (Color)Application.Current.Resources["ApplicationBackgroundColor"];
        if (isTransparent) color.A = 64;

        BackgroundElement = new Border
        {
            Background = new SolidColorBrush(color),
            CornerRadius = new CornerRadius(isTransparent ? 0 : Settings.WidgetRadius)
        };

        var content = Content as UIElement;
        Content = BackgroundElement;
        BackgroundElement.Child = content;
    }

    private void ApplyTransparency()
    {
        var corners = Settings.Appearance.WidgetRadius switch
        {
            0 => WindowCornerPreference.DoNotRound,
            < 8 => WindowCornerPreference.RoundSmall,
            _ => WindowCornerPreference.Round
        };

        WindowExtensions.ApplyCorners(this, corners);
        Wpf.Ui.Appearance.Background.Apply(this, BackgroundType.Acrylic);
    }
}