using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using uWidgets.Infrastructure.Models;

namespace uWidgets.Widgets.Weather;

public partial class Weather
{
    public WeatherSettings WeatherSettings;
    public Dictionary<string, string> WeatherLocaleStrings;
    
    public Weather(WidgetLayout widgetLayout, AppSettings appSettings, LocaleStrings localeStrings) 
        : base(widgetLayout, appSettings, localeStrings)
    {
        InitializeComponent();

        WeatherSettings = widgetLayout.Settings?.Deserialize<WeatherSettings>() 
                          ?? throw new FormatException(nameof(WeatherSettings));
        
        // WeatherLocaleStrings = App.DeserializeFromFile<Dictionary<string, Dictionary<string, string>>>("Widgets/Weather/WeatherLocale.json")[appSettings.Region.Language];
        
        var timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromMinutes(WeatherSettings.RefreshRateMinutes)
        };
        timer.Tick += (_,_) => OnTick();
        timer.Start();
        OnTick();

        SizeChanged += OnSizeChange;
        Show();
    }

    private async Task OnTick()
    {
        using var httpClient = new HttpClient();

        var latitude = WeatherSettings.Latitude.ToString("0.##", CultureInfo.InvariantCulture);
        var longitude = WeatherSettings.Longitude.ToString("0.##", CultureInfo.InvariantCulture);
        
        var url = $"https://api.open-meteo.com/v1/forecast?" +
                  $"latitude={latitude}&" +
                  $"longitude={longitude}&" +
                  $"hourly=temperature_2m,weathercode&" +
                  $"daily=temperature_2m_min,temperature_2m_max,weathercode&" +
                  $"timezone=auto";

        
        var response = await httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode) return;
        
        var json = await response.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<WeatherResponse>(json);

        if (result == null) return;

        var hourly = result.Hourly.Snapshots.First(x => x.DateTime == DateTime.Now.Date.AddHours(DateTime.Now.Hour));
        var daily = result.Daily.Snapshots.First(x => x.DateTime == DateTime.Now.Date);

        (CityName.Child as TextBlock)!.Text = WeatherSettings.LocationName;
        (CurrentTemp.Child as TextBlock)!.Text = $"{hourly.Temperature:0}°";
        (CurrentDescription.Child as TextBlock)!.Text = WeatherLocaleStrings[Enum.GetName(typeof(WeatherCode), hourly.WeatherCode)];
        (CurrentMinMax.Child as TextBlock)!.Text = $"↓ {daily.Min:0}° ↑ {daily.Max:0}°";
    }


    private void OnSizeChange(object sender, SizeChangedEventArgs e)
    {
        var small = Width <= AppSettings.WidgetSize && Height <= AppSettings.WidgetSize;
        var smallWide = Height <= AppSettings.WidgetSize && Width > Height;
        var notWide = Width <= AppSettings.WidgetSize * 2 + AppSettings.WidgetPadding;
        var smallHeight = Height <= AppSettings.WidgetSize;

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