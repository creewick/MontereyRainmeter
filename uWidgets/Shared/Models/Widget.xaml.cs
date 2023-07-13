using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Extensions.Localization;
using Shared.Events;
using Shared.Interfaces;
using Shared.Services;
using Wpf.Ui.Appearance;
using Wpf.Ui.Extensions;

namespace Shared.Models;

public partial class Widget : Window
{
    public event EventHandler<WidgetEventArgs>? WidgetOpened;
    public event EventHandler<WidgetEventArgs>? WidgetClosed;
    public event EventHandler<WidgetMovedEventArgs>? WidgetMoved;
    public event EventHandler<WidgetResizedEventArgs>? WidgetResized;
    
    public Widget(IAppSettingsProvider appSettingsProvider, IStringLocalizer locale, UserControl userControl)
    {
        DataContext = new WidgetViewModel
        {
            Background = GetBackground(appSettingsProvider),
            CornerRadius = GetRadius(appSettingsProvider),
            Control = userControl
        };
        
        InitializeComponent();

        MouseLeftButtonDown += OnMouseLeftButtonDown;
        SourceInitialized += (_, _) => OnSourceInitialized(appSettingsProvider);
        Closed += (_, _) => WidgetClosed?.Invoke(this, new WidgetEventArgs(this));
    }

    private void OnSourceInitialized(IAppSettingsProvider appSettingsProvider)
    {
        this.RemoveFromAltTab();

        if (appSettingsProvider.Get().Appearance.Transparency)
            ApplyTransparency();

        WidgetOpened?.Invoke(this, new WidgetEventArgs(this));
    }

    private static SolidColorBrush GetBackground(IAppSettingsProvider appSettingsProvider)
    {
        var color = (Color)Application.Current.Resources["ApplicationBackgroundColor"];
        color.A = (byte)(appSettingsProvider.Get().Appearance.Transparency ? 64 : 255);

        return new SolidColorBrush(color);
    }

    private CornerRadius GetRadius(IAppSettingsProvider appSettingsProvider)
    {
        if (!appSettingsProvider.Get().Appearance.Transparency)
            return new CornerRadius(appSettingsProvider.Get().WidgetMargin);

        ApplyCorners(appSettingsProvider);
        return new CornerRadius(0);
    }

    private void ApplyCorners(IAppSettingsProvider appSettingsProvider)
    {
        var corners = appSettingsProvider.Get().Appearance.WidgetRadius switch
        {
            0 => WindowCornerPreference.DoNotRound,
            < 8 => WindowCornerPreference.RoundSmall,
            _ => WindowCornerPreference.Round
        };

        this.ApplyCorners(corners);
    }

    private void ApplyTransparency()
    {
        Wpf.Ui.Appearance.Background.Apply(this, BackgroundType.Acrylic);
    }

    private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left)
        {
            DragMove();
        }
    }
}