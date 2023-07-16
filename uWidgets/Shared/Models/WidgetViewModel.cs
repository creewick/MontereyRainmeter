using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
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
    public event PropertyChangedEventHandler? PropertyChanged;
    
    public Brush Background => GetBackground(appSettingsProvider.Get());
    public CornerRadius CornerRadius => new(appSettingsProvider.Get().Appearance.Transparency ? 0 : appSettingsProvider.Get().WidgetMargin);
    public UserControl Control { get; set; }
    public double MinSize => appSettingsProvider.Get().WidgetSize;
    public double Padding => appSettingsProvider.Get().WidgetSize * 0.1;
    public double Left => widgetSettingsProvider.Get().X;
    public double Top => widgetSettingsProvider.Get().Y;
    public double Width => gridSizeConverter.GetPixels(widgetSettingsProvider.Get().Columns);
    public double Height => gridSizeConverter.GetPixels(widgetSettingsProvider.Get().Rows);
    public WidgetLocale Locale => new(locale, widgetSettingsProvider.Get().Type);
    public WidgetContextMenu ContextMenu { get; set; }

    public WidgetViewModel(IAppSettingsProvider appSettingsProvider, IWidgetSettingsProvider widgetSettingsProvider, 
        IStringLocalizer locale, UserControl userControl)
    {
        Control = userControl;
        this.locale = locale;
        this.appSettingsProvider = appSettingsProvider;
        this.widgetSettingsProvider = widgetSettingsProvider;
        gridSizeConverter = new GridSizeConverter(appSettingsProvider);

        appSettingsProvider.Updated += (_, _) => Update();
        widgetSettingsProvider.Updated += (_, _) => Update();
    }

    private static SolidColorBrush GetBackground(AppSettings appSettings)
    {
        var color = (Color)Application.Current.Resources["ApplicationBackgroundColor"];
        color.A = (byte)(appSettings.Appearance.Transparency ? 64 : 255);

        return new SolidColorBrush(color);
    }

    private void Update() => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
}