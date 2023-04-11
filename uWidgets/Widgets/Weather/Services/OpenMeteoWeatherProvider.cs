using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using uWidgets.Widgets.Weather.Interfaces;
using uWidgets.Widgets.Weather.Models;

namespace uWidgets.Widgets.Weather.Services;

public class OpenMeteoWeatherProvider : IWeatherProvider
{
    public async Task<WeatherForecast> GetForecast(double latitude, double longitude)
    {
        using var httpClient = new HttpClient();

        var url = $"https://api.open-meteo.com/v1/forecast?" +
                  $"latitude={latitude.ToString("0.##", CultureInfo.InvariantCulture)}&" +
                  $"longitude={longitude.ToString("0.##", CultureInfo.InvariantCulture)}&" +
                  $"hourly=temperature_2m,weathercode&" +
                  $"daily=temperature_2m_min,temperature_2m_max,weathercode&" +
                  $"timezone=auto";

        var response = await httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode) return new WeatherForecast();
        
        var json = await response.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<OpenMeteoResponse>(json);

        if (result == null) return new WeatherForecast();

        return new WeatherForecast
        {
            Daily = result.Daily.Time.Select((time, i) => new DailyWeatherSnapshot
            {
                Min = result.Daily.TemperatureMin[i],
                Max = result.Daily.TemperatureMax[i],
                WeatherCode = result.Daily.WeatherCode[i],
                DateTime = DateTime.ParseExact(time, "yyyy-MM-dd", CultureInfo.InvariantCulture)
            }).ToList(),

            Hourly = result.Hourly.Time.Select((time, i) => new HourlyWeatherSnapshot
            {
                Temperature = result.Hourly.Temperature[i],
                WeatherCode = result.Hourly.WeatherCode[i],
                DateTime = DateTime.ParseExact(time, "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture)
            }).ToList()
        };
    }
}