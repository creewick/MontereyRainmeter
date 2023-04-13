using System.Threading.Tasks;
using uWidgets.Widgets.Weather.Models;

namespace uWidgets.Widgets.Weather.Interfaces;

public interface IWeatherProvider
{
    public Task<WeatherForecast?> GetForecast(double latitude, double longitude);
}