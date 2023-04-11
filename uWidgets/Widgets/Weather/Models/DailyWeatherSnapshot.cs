using System;

namespace uWidgets.Widgets.Weather.Models;

public class DailyWeatherSnapshot : WeatherSnapshot
{
    public double Min { get; set; }
    public double Max { get; set; }
}
