using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using uWidgets.Configuration.Interfaces;
using uWidgets.Configuration.Models;
using uWidgets.Configuration.Providers;
using uWidgets.UserInterface.Interfaces;
using uWidgets.UserInterface.Services;
using uWidgets.UserInterface.WindowTypes;
using uWidgets.Widgets.Weather.Interfaces;
using uWidgets.Widgets.Weather.Services;
using uWidgets.WindowManagement.Factories;
using uWidgets.WindowManagement.Interfaces;

namespace uWidgets;

public partial class App
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var serviceProvider = ConfigureServices();

        serviceProvider.GetRequiredService<IThemeService>().Apply();
        serviceProvider.GetRequiredService<IWidgetFactory>().GetWidgets();
    }

    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddSingleton<ISettingsProvider, SettingsProvider>();
        services.AddSingleton<AppSettings>(provider => provider.GetRequiredService<ISettingsProvider>().Get());
        services.AddSingleton<ILayoutProvider, LayoutProvider>();
        services.AddSingleton<List<WidgetLayout>>(provider => provider.GetRequiredService<ILayoutProvider>().Get());
        services.AddSingleton<ILocaleProvider>(provider => 
            new LocaleProvider(provider
                .GetRequiredService<ISettingsProvider>()
                .Get().Region.Language));
        services.AddSingleton<Locale>(provider => provider.GetRequiredService<ILocaleProvider>().Get());
        services.AddSingleton<IThemeService, ThemeService>();
        services.AddSingleton<ILayoutService, LayoutService>();
        services.AddSingleton<IWeatherProvider, OpenMeteoWeatherProvider>();
        services.AddSingleton<IWidgetFactory, WidgetFactory>();

        return services.BuildServiceProvider();
    }
}