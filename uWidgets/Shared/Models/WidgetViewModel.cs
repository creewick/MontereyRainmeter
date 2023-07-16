using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Microsoft.Extensions.Localization;
using Shared.Interfaces;
using Shared.Services;
using Wpf.Ui.Common;

namespace Shared.Models;

public class WidgetViewModel : INotifyPropertyChanged
{
    private readonly IStringLocalizer locale;
    private readonly GridSizeConverter gridSizeConverter;
    private readonly IAppSettingsProvider appSettingsProvider;
    private readonly IWidgetSettingsProvider widgetSettingsProvider;

    public SolidColorBrush Background => new(GetBackgroundColor(appSettingsProvider.Get()));

    public CornerRadius CornerRadius => new(appSettingsProvider.Get().Appearance.Transparency ? 0 : appSettingsProvider.Get().WidgetMargin);
    public UserControl Control { get; set; }
    public double Padding => appSettingsProvider.Get().WidgetSize * 0.1;
    public double Left => widgetSettingsProvider.Get().X;
    public double Top => widgetSettingsProvider.Get().Y;
    public double Width => gridSizeConverter.GetPixels(widgetSettingsProvider.Get().Columns);
    public double Height => gridSizeConverter.GetPixels(widgetSettingsProvider.Get().Rows);
    public WidgetLocale Locale => new(locale, widgetSettingsProvider.Get().Type);

    public RelayCommand DarkMode => new(() =>
    {
        var appSettings = appSettingsProvider.Get();
        appSettings.Appearance.DarkTheme = true;
        appSettingsProvider.Update(appSettings);
    });
    public RelayCommand LightMode => new(() =>
    {
        var appSettings = appSettingsProvider.Get();
        appSettings.Appearance.DarkTheme = false;
        appSettingsProvider.Update(appSettings);
    });
    
    public event PropertyChangedEventHandler? PropertyChanged;

    public WidgetViewModel(IAppSettingsProvider appSettingsProvider, IWidgetSettingsProvider widgetSettingsProvider, 
        IStringLocalizer locale, UserControl userControl)
    {
        Control = userControl;
        this.locale = locale;
        this.appSettingsProvider = appSettingsProvider;
        this.widgetSettingsProvider = widgetSettingsProvider;
        gridSizeConverter = new GridSizeConverter(appSettingsProvider);

        appSettingsProvider.Updated += (_, _) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
        widgetSettingsProvider.Updated += (_, _) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
    }
    
    private static Color GetBackgroundColor(AppSettings appSettings)
    {
        var color = (Color) Application.Current.Resources["ApplicationBackgroundColor"];
        color.A = (byte) (appSettings.Appearance.Transparency ? 64 : 255);

        return color;
    }
}