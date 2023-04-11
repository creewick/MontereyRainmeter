using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace uWidgets.Widgets.Weather.Models;

public class OpenMeteoResponse
{
    [JsonPropertyName("hourly")]
    public OpenMeteoHourlyForecast Hourly { get; set; }
    [JsonPropertyName("daily")]
    public OpenMeteoDailyForecast Daily { get; set; }
}

public class OpenMeteoDailyForecast
{
    [JsonPropertyName("time")]
    public List<string> Time { get; set; }
    [JsonPropertyName("temperature_2m_min")]
    public List<double> TemperatureMin { get; set; }
    [JsonPropertyName("temperature_2m_max")]
    public List<double> TemperatureMax { get; set; }
    [JsonPropertyName("weathercode")]
    public List<WeatherCode> WeatherCode { get; set; }
}

public class OpenMeteoHourlyForecast
{
    [JsonPropertyName("time")]
    public List<string> Time { get; set; }
    [JsonPropertyName("temperature_2m")]
    public List<double> Temperature { get; set; }
    [JsonPropertyName("weathercode")]
    public List<WeatherCode> WeatherCode { get; set; }
}
