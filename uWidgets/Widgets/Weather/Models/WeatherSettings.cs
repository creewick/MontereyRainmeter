namespace uWidgets.Widgets.Weather.Models;

public class WeatherSettings
{
    public int RefreshRateMinutes { get; set; }
    public string LocationName { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}