using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.Localization;
using Shared.Events;
using Shared.Interfaces;
using Shared.Models;
using Shared.Services;
using Wpf.Ui.Appearance;
using Wpf.Ui.Extensions;

namespace Shared.Templates;

public partial class Widget : Window
{
    public event EventHandler<WidgetEventArgs>? WidgetOpened;
    public event EventHandler<WidgetEventArgs>? WidgetClosed;
    public event EventHandler<WidgetMovedEventArgs>? WidgetMoved;
    public event EventHandler<WidgetResizedEventArgs>? WidgetResized;
    public Guid Id;
    
    public Widget(IAppSettingsProvider appSettingsProvider, IWidgetSettingsProvider widgetSettingsProvider, 
        IStringLocalizer locale, UserControl userControl)
    {
        DataContext = new WidgetViewModel(appSettingsProvider, widgetSettingsProvider, locale, userControl);
        Id = widgetSettingsProvider.Get().Id;

        appSettingsProvider.Updated += (_, appSettings) => ApplyTransparency(appSettings);

        InitializeComponent();

        MouseLeftButtonDown += (_, _) => OnMouseLeftButtonDown();
        MouseLeftButtonUp += (_, _) => OnMouseLeftButtonUp();
        SourceInitialized += (_, _) => OnSourceInitialized(appSettingsProvider.Get());
        Closed += (_, _) => WidgetClosed?.Invoke(this, new WidgetEventArgs(this));
    }

    private void OnMouseLeftButtonDown()
    {
        if (ResizeMode != ResizeMode.NoResize)
        {
            ResizeMode = ResizeMode.NoResize;
        }
        
        DragMove();
        
        WidgetMoved?.Invoke(this, new WidgetMovedEventArgs(this, Left, Top));
    }
    
    private void OnMouseLeftButtonUp()
    {
        if (ResizeMode == ResizeMode.NoResize)
        {
            ResizeMode = ResizeMode.CanResizeWithGrip;
        }
    }


    private void OnSourceInitialized(AppSettings appSettings)
    {
        this.RemoveFromAltTab();
        this.ResizeEnd(() => WidgetResized?.Invoke(this, new WidgetResizedEventArgs(this, null)));

        if (appSettings.Appearance.Transparency) ApplyTransparency(appSettings);

        WidgetOpened?.Invoke(this, new WidgetEventArgs(this));
    }
    

    private void ApplyTransparency(AppSettings appSettings)
    {
        Activate();
        Wpf.Ui.Appearance.Background.Remove(this);
        Wpf.Ui.Appearance.Background.Apply(this, BackgroundType.Acrylic, true);
        
        this.ApplyCorners(appSettings.Appearance.WidgetRadius switch
        {
            0 => WindowCornerPreference.DoNotRound,
            < 8 => WindowCornerPreference.RoundSmall,
            _ => WindowCornerPreference.Round
        });
    }
}