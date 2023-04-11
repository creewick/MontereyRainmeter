using System;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using uWidgets.Configuration.Interfaces;
using uWidgets.Configuration.Models;
using uWidgets.UserInterface.Services;
using uWidgets.WidgetManagement.Interfaces;
using Wpf.Ui.Appearance;

namespace uWidgets.WidgetManagement.Models;

public abstract class Widget : Window, IWidget
{
    protected readonly ISettingsManager SettingsManager;
    protected readonly ILayoutManager LayoutManager;
    protected readonly ILocaleManager LocaleManager;
    protected readonly Guid Id;
    protected readonly WidgetLayoutService WidgetLayoutService;

    protected Widget(ISettingsManager settingsManager, ILayoutManager layoutManager, ILocaleManager localeManager, Guid id)
    {
        WidgetLayoutService = new WidgetLayoutService(settingsManager, layoutManager, id, this);
        SettingsManager = settingsManager;
        LayoutManager = layoutManager;
        LocaleManager = localeManager;
        Id = id;
        
        WidgetLayoutService.SetWindowProperties();
        ContextMenu = GetContextMenu();
        
        MouseLeftButtonDown += OnMouseLeftButtonDown;
        SourceInitialized += OnSourceInitialized;
    }
    
    private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ButtonState != MouseButtonState.Pressed) return;
        
        DragMove();
        WidgetLayoutService.OnMove();
    }

    private void OnSourceInitialized(object? sender, EventArgs e)
    {
        if (SettingsManager.Get().Appearance.Transparency) 
            ApplyTransparency();
        
        DrawBackground();
        WindowOsIntegrationService.DisableWindowSnapping(this);
        WindowOsIntegrationService.RemoveWindowFromAltTab(this);
    }

    private ContextMenu GetContextMenu()
    {
        var locale = LocaleManager.Get();
        
        return new ContextMenuBuilder()
            .With(locale["Edit"], null, false)
            .With(new Separator())
            .With(locale["Size"], null, false)
            .With(locale["Small"], () => WidgetLayoutService.OnResize(1, 1))
            .With(locale["Medium"], () => WidgetLayoutService.OnResize(2, 2))
            .With(locale["Wide"], () => WidgetLayoutService.OnResize(4, 2))
            .With(locale["Large"], () => WidgetLayoutService.OnResize(4, 4))
            .With(new Separator())
            .With(locale["RemoveWidget"], Close)
            .With(new Separator())
            .With(locale["EditWidgets"], null, false)
            .Build();
    }

    private void DrawBackground()
    {
        var appearanceSettings = SettingsManager.Get().Appearance;
        
        var isTransparent = appearanceSettings.Transparency;
        var color = (Color)Application.Current.Resources["ApplicationBackgroundColor"];
        if (isTransparent) color.A = 64;
        
        var border = new Border
        {
            Background = new SolidColorBrush(color),
            CornerRadius = new CornerRadius(isTransparent ? 0 : appearanceSettings.WidgetRadius)
        };
        
        var content = Content as UIElement;
        Content = border;
        border.Child = content;
    }

    private void ApplyTransparency()
    {
        var corners = SettingsManager.Get().Appearance.WidgetRadius switch
        {
            0 => WindowCornerPreference.DoNotRound,
            < 8 => WindowCornerPreference.RoundSmall,
            _ => WindowCornerPreference.Round
        };

        Wpf.Ui.Extensions.WindowExtensions.ApplyCorners(this, corners);
        Wpf.Ui.Appearance.Background.Apply(this, BackgroundType.Acrylic);
    }
}