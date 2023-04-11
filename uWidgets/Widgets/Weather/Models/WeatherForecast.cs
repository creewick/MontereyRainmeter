using System.Collections.Generic;

namespace uWidgets.Widgets.Weather.Models;

public class WeatherForecast
{
    public List<DailyWeatherSnapshot> Daily { get; set; }
    public List<HourlyWeatherSnapshot> Hourly { get; set; }
}