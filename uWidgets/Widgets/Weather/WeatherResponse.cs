using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json.Serialization;

namespace uWidgets.Widgets.Weather;

public class WeatherResponse
{
    [JsonPropertyName("hourly")]
    public WeatherForecast Hourly { get; set; }
    [JsonPropertyName("daily")]
    public WeatherForecast Daily { get; set; }
}

public class WeatherForecast
{
    [JsonPropertyName("time")]
    public List<string> Time { get; set; }
    [JsonPropertyName("temperature_2m")]
    public List<double>? Temperature { get; set; }
    [JsonPropertyName("temperature_2m_min")]
    public List<double>? TemperatureMin { get; set; }
    [JsonPropertyName("temperature_2m_max")]
    public List<double>? TemperatureMax { get; set; }
    [JsonPropertyName("weathercode")]
    public List<WeatherCode> WeatherCode { get; set; }

    public List<WeatherSnapshot> Snapshots => Time
        .Select(time => DateTime.ParseExact(time, new[] {"yyyy-MM-ddTHH:mm", "yyyy-MM-dd"}, CultureInfo.InvariantCulture))
        .Select((dateTime, index) => new WeatherSnapshot
        {
            DateTime = dateTime,
            Temperature = Temperature?[index],
            Min = TemperatureMin?[index],
            Max = TemperatureMax?[index],
            WeatherCode = WeatherCode[index]
        })
        .ToList();
}

public class WeatherSnapshot
{
    public DateTime DateTime { get; set; }
    public double? Temperature { get; set; }
    public double? Min { get; set; }
    public double? Max { get; set; }
    public WeatherCode WeatherCode { get; set; }
}