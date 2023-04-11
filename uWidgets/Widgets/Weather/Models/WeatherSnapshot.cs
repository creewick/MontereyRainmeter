using System;

namespace uWidgets.Widgets.Weather.Models;

public class WeatherSnapshot
{
    public DateTime DateTime { get; set; }
    public WeatherCode WeatherCode { get; set; }
}