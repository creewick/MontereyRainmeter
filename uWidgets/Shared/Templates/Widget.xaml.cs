using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using Microsoft.Extensions.Localization;
using Shared.Events;
using Shared.Interfaces;
using Shared.Models;
using Shared.Services;
using Wpf.Ui.Appearance;
using Wpf.Ui.Common;

namespace Shared.Templates;

public partial class Widget
{
    public event EventHandler<WidgetEventArgs>? WidgetOpened;
    public event EventHandler<WidgetEventArgs>? WidgetClosed;
    public event EventHandler<WidgetMovedEventArgs>? WidgetMoved;
    public event EventHandler<WidgetResizedEventArgs>? WidgetResized;
    
    public Guid Id;

    private GridSizeConverter gridSizeConverter;
    
    public Widget(IAppSettingsProvider appSettingsProvider, IWidgetSettingsProvider widgetSettingsProvider, 
        IStringLocalizer locale, UserControl userControl)
    {
        Id = widgetSettingsProvider.Get().Id;
        gridSizeConverter = new GridSizeConverter(appSettingsProvider);
        ExtendsContentIntoTitleBar = true;
        WindowBackdropType = GetBackgroundType(appSettingsProvider);
        WindowCornerPreference = GetWindowCornerPreference(appSettingsProvider);
        DataContext = new WidgetViewModel(appSettingsProvider, widgetSettingsProvider, locale, userControl)
        {
            ContextMenu = new()
            {
                EditWidget = new RelayCommand(() => { }),
                Small = new RelayCommand(() => Resize(2, 2)),
                Medium = new RelayCommand(() => Resize(4, 2)),
                Large = new RelayCommand(() => Resize(4, 4)),
                RemoveWidget = new RelayCommand(() => WidgetClosed?.Invoke(this, new WidgetEventArgs(this))),
                EditWidgets = new RelayCommand(() => new AppSettingsWindow.AppSettingsWindow(appSettingsProvider).Show()),
                ExitApp = new RelayCommand(() => Application.Current.Shutdown())
            }
        };

        InitializeComponent();

        MouseLeftButtonDown += (_, _) => OnMouseLeftButtonDown();
        SourceInitialized += (_, _) => OnSourceInitialized(appSettingsProvider.Get());
        appSettingsProvider.Updated  += async (_, _) =>
        {
            WindowBackdropType = GetBackgroundType(appSettingsProvider);
            WindowCornerPreference = GetWindowCornerPreference(appSettingsProvider);
            
            if (!appSettingsProvider.Get().Appearance.Transparency) return;

            await Task.Delay(500);
            Activate();
            Wpf.Ui.Appearance.Background.Apply(this, BackgroundType.None);
            Wpf.Ui.Appearance.Background.Apply(this, BackgroundType.Acrylic);
        };
    }

    private void Resize(int columns, int rows)
    {
        var width = gridSizeConverter.GetPixels(columns);
        var height = gridSizeConverter.GetPixels(rows);
        WidgetResized?.Invoke(this, new(this, new Size(width, height)));
    }

    private void OnMouseLeftButtonDown()
    {
        DragMove();
        
        WidgetMoved?.Invoke(this, new WidgetMovedEventArgs(this, Left, Top));
    }
    
    private void OnSourceInitialized(AppSettings appSettings)
    {
        this.RemoveFromAltTab();
        this.ResizeEnd(() => WidgetResized?.Invoke(this, new WidgetResizedEventArgs(this, null)));

        WidgetOpened?.Invoke(this, new WidgetEventArgs(this));
    }

    private static BackgroundType GetBackgroundType(IAppSettingsProvider appSettingsProvider)
    {
        return appSettingsProvider.Get().Appearance.Transparency
            ? BackgroundType.Acrylic
            : BackgroundType.None;
    }

    private static WindowCornerPreference GetWindowCornerPreference(IAppSettingsProvider appSettingsProvider)
    {
        if (!appSettingsProvider.Get().Appearance.Transparency) return WindowCornerPreference.DoNotRound;

        return appSettingsProvider.Get().WidgetRadius switch
        {
            0 => WindowCornerPreference.DoNotRound,
            < 8 => WindowCornerPreference.RoundSmall,
            _ => WindowCornerPreference.Round,
        };
    }
}