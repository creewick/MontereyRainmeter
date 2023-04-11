using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using uWidgets.Configuration.FileHandlers;
using uWidgets.Configuration.Interfaces;
using uWidgets.Widgets.Weather.Interfaces;
using uWidgets.Widgets.Weather.Models;
using uWidgets.Widgets.Weather.Services;

namespace uWidgets.Widgets.Weather;

public partial class Weather
{
    public WeatherSettings WeatherSettings;
    public Dictionary<string, string> WeatherLocaleStrings;
    public IWeatherProvider WeatherProvider;
    public DispatcherTimer Timer;
    
    public Weather(ISettingsManager settingsManager, ILayoutManager layoutManager, ILocaleManager localeManager, IWeatherProvider weatherProvider, Guid id)
        : base(settingsManager, layoutManager, localeManager, id)
    {
        WeatherProvider = weatherProvider;

        InitializeComponent();
        OnSettingsChange();
        OnSizeChange();
        OnTick();
        
        SizeChanged += (_,_) => OnSizeChange();
        Show();
    }

    private void OnSettingsChange()
    {
        WeatherSettings = LayoutManager.Get(Id).Settings?.Deserialize<WeatherSettings>() 
                          ?? throw new FormatException(nameof(WeatherSettings));

        var language = SettingsManager.Get().Region.Language;
        
        WeatherLocaleStrings = new FileHandler<Dictionary<string, string>>(
            Path.Combine("Widgets", "Weather", "Locales", $"{language}.json")
        ).Get();

        Timer?.Stop();
        Timer = new DispatcherTimer { Interval = TimeSpan.FromMinutes(WeatherSettings.RefreshRateMinutes) };
        Timer.Tick += (_,_) => OnTick();
        Timer.Start();
    }

    private async Task OnTick()
    {
        var forecast = await WeatherProvider.GetForecast(WeatherSettings.Latitude, WeatherSettings.Longitude);

        var today = DateTime.Now.Date;
        var nowHourly = forecast.Hourly.First(x => x.DateTime == today.AddHours(DateTime.Now.Hour));
        var nowDaily = forecast.Daily.First(x => x.DateTime == today);

        var weatherCode = Enum.GetName(typeof(WeatherCode), nowHourly.WeatherCode) ?? string.Empty;

        CityNameText.Text = WeatherSettings.LocationName;
        CurrentTempText.Text = $"{nowHourly.Temperature:0}°";
        CurrentIconImage.Source = WeatherCodeImageProvider.GetImage(nowHourly.WeatherCode);
        CurrentDescriptionText.Text = WeatherLocaleStrings.TryGetValue(weatherCode, out var text) ? text : string.Empty;
        CurrentMinMaxText.Text = $"↓ {nowDaily.Min:0}° ↑ {nowDaily.Max:0}°";

        var hourly = forecast.Hourly.Skip(forecast.Hourly.IndexOf(nowHourly)).ToList();

        Hour1.Text = $"{hourly[1].DateTime.Hour:D2}";
        IconImage1.Source = WeatherCodeImageProvider.GetImage(hourly[1].WeatherCode);
        Temp1.Text = $"{hourly[1].Temperature:0}°";
        Hour2.Text = $"{hourly[2].DateTime.Hour:D2}";
        IconImage2.Source = WeatherCodeImageProvider.GetImage(hourly[2].WeatherCode);
        Temp2.Text = $"{hourly[2].Temperature:0}°";
        Hour3.Text = $"{hourly[3].DateTime.Hour:D2}";
        IconImage3.Source = WeatherCodeImageProvider.GetImage(hourly[3].WeatherCode);
        Temp3.Text = $"{hourly[3].Temperature:0}°";
        Hour4.Text = $"{hourly[4].DateTime.Hour:D2}";
        IconImage4.Source = WeatherCodeImageProvider.GetImage(hourly[4].WeatherCode);
        Temp4.Text = $"{hourly[4].Temperature:0}°";
        Hour5.Text = $"{hourly[5].DateTime.Hour:D2}";
        IconImage5.Source = WeatherCodeImageProvider.GetImage(hourly[5].WeatherCode);
        Temp5.Text = $"{hourly[5].Temperature:0}°";
        Hour6.Text = $"{hourly[6].DateTime.Hour:D2}";
        IconImage6.Source = WeatherCodeImageProvider.GetImage(hourly[6].WeatherCode);
        Temp6.Text = $"{hourly[6].Temperature:0}°";
    }
    
    private void OnSizeChange()
    {
        var settings = SettingsManager.Get();
        
        var small = Width <= settings.WidgetSize && Height <= settings.WidgetSize;
        var smallWide = Height <= settings.WidgetSize && Width > Height;
        var notWide = Width <= settings.WidgetSize * 2 + settings.WidgetPadding;
        var smallHeight = Height <= settings.WidgetSize;

        Grid.SetRowSpan(CityName, small || smallWide ? 2 : 1);
        Grid.SetColumnSpan(CityName, notWide ? 2 : 1);
        CityName.HorizontalAlignment = small ? HorizontalAlignment.Center : HorizontalAlignment.Left;
        
        Grid.SetRow(CurrentTemp, small || smallWide ? 2 : 1);
        Grid.SetRowSpan(CurrentTemp, small || smallWide ? 6 : 3);
        Grid.SetColumnSpan(CurrentTemp, notWide ? 2 : 1);
        CurrentTemp.HorizontalAlignment = small ? HorizontalAlignment.Center : HorizontalAlignment.Left;

        Grid.SetRow(CurrentIcon, notWide ? 5 : 0);
        Grid.SetColumn(CurrentIcon, notWide ? 0 : 1);
        Grid.SetRowSpan(CurrentIcon, smallWide ? 2 : 1);
        Grid.SetColumnSpan(CurrentIcon, notWide ? 2 : 1);
        CurrentIcon.HorizontalAlignment = notWide ? HorizontalAlignment.Left : HorizontalAlignment.Right;
        CurrentIcon.Visibility = small ? Visibility.Hidden : Visibility.Visible;
        
        Grid.SetRow(CurrentDescription, notWide ? 6 : smallWide ? 3 : 1);
        Grid.SetColumn(CurrentDescription, notWide ? 0 : 1);
        Grid.SetRowSpan(CurrentDescription, smallWide ? 2 : 1);
        Grid.SetColumnSpan(CurrentDescription, notWide ? 2 : 1);
        CurrentDescription.HorizontalAlignment = notWide ? HorizontalAlignment.Left : HorizontalAlignment.Right;
        CurrentDescription.Visibility = small ? Visibility.Hidden : Visibility.Visible;
        
        Grid.SetRow(CurrentMinMax, notWide ? 7 : smallWide ? 5 : 2);
        Grid.SetColumn(CurrentMinMax, notWide ? 0 : 1);
        Grid.SetRowSpan(CurrentMinMax, smallWide ? 2 : 1);
        Grid.SetColumnSpan(CurrentMinMax, notWide ? 2 : 1);
        CurrentMinMax.HorizontalAlignment = notWide ? HorizontalAlignment.Left : HorizontalAlignment.Right;
        CurrentMinMax.Visibility = small ? Visibility.Hidden : Visibility.Visible;

        HourlyTempBlock.Visibility = smallHeight || notWide ? Visibility.Hidden : Visibility.Visible;
    }
}