using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Extensions.Localization;
using Wpf.Ui.Appearance;
using Wpf.Ui.Extensions;

namespace WidgetContracts.Widget;

public partial class Widget
{
    public Widget(AppSettings appSettings, UserControl userControl, IStringLocalizer locale)
    {
        InitializeComponent();

        DataContext = new WidgetViewModel
        {
            Content = userControl,
            Background = GetBackground(appSettings),
            Radius = GetRadius(appSettings),
            
        };
        
        SourceInitialized += (_,_) => OnSourceInitialized(appSettings);
    }
    
    private void OnSourceInitialized(AppSettings appSettings)
    {
        this.RemoveFromAltTab();
        
        if (appSettings.Appearance.Transparency)
            ApplyTransparency(appSettings);
    }

    private static SolidColorBrush GetBackground(AppSettings appSettings)
    {
        var color = Colors.White;
        color.A = (byte) (appSettings.Appearance.Transparency ? 64 : 255);
        
        return new SolidColorBrush(color);
    }
    
    private static CornerRadius GetRadius(AppSettings appSettings)
    {
        return appSettings.Appearance.Transparency 
            ? new CornerRadius(0) 
            : new CornerRadius(appSettings.WidgetRadius);
    }
    
    private void ApplyTransparency(AppSettings appSettings)
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