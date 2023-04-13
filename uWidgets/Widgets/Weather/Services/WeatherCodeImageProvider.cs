using System;
using System.IO;
using System.Windows.Media.Imaging;
using uWidgets.Widgets.Weather.Models;

namespace uWidgets.Widgets.Weather.Services;

public static class WeatherCodeImageProvider
{
    public static BitmapImage GetImage(WeatherCode weatherCode)
    {
        var imageName = GetImageName(weatherCode);
        var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "Widgets", "Weather", "Images", $"{imageName}.png");
        var imageUri = new Uri(imagePath, UriKind.Absolute);
        var image = new BitmapImage(imageUri);
        
        return image;
    }

    private static string GetImageName(WeatherCode code)
    {
        return code switch
        {
            WeatherCode.ClearSky or 
                WeatherCode.MainlyClear => "clear",
            WeatherCode.PartlyCloudy => "partly-cloudy",
            WeatherCode.Overcast => "cloudy",
            WeatherCode.Fog or 
                WeatherCode.DepositingRimeFog => "fog",
            WeatherCode.DrizzleLightIntensity or 
                WeatherCode.DrizzleModerateIntensity or 
                WeatherCode.DrizzleDenseIntensity or 
                WeatherCode.FreezingDrizzleLightIntensity or 
                WeatherCode.FreezingDrizzleDenseIntensity => "drizzle",
            WeatherCode.RainSlightIntensity or 
                WeatherCode.RainModerateIntensity or
                WeatherCode.RainHeavyIntensity => "rain",
            WeatherCode.FreezingRainLightIntensity or 
                WeatherCode.FreezingRainHeavyIntensity => "snow-rain",
            WeatherCode.SnowFallSlightIntensity or 
                WeatherCode.SnowFallModerateIntensity or 
                WeatherCode.SnowGrains or
                WeatherCode.SnowFallHeavyIntensity => "heavy-snow",
            WeatherCode.RainShowersSlightIntensity or 
                WeatherCode.RainShowersModerateIntensity or 
                WeatherCode.RainShowersViolentIntensity => "heavy-rain",
            WeatherCode.SnowShowersSlightIntensity or 
                WeatherCode.SnowShowersHeavyIntensity => "heavy-snow",
            WeatherCode.ThunderstormSlightIntensity or 
                WeatherCode.ThunderstormWithSlightHail or 
                WeatherCode.ThunderstormWithHeavyHail => "thunder",
            _ => throw new ArgumentException(code.ToString(), nameof(WeatherCode))
        };
    }
}