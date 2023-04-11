using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using uWidgets.Configuration.FileHandlers;
using uWidgets.Configuration.Interfaces;
using uWidgets.UserInterface.Services;
using uWidgets.WidgetManagement.Factories;
using uWidgets.Widgets.Weather.Interfaces;
using uWidgets.Widgets.Weather.Services;

namespace uWidgets;

public partial class App
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var serviceProvider = ConfigureServices();
        
        // Workaround to make Wpf.Ui.Appearance.Theme.Apply work
        Current.MainWindow = new Window();

        var settings = serviceProvider.GetRequiredService<ISettingsManager>();

        ThemeBuilder.Apply(settings.Get().Appearance);

        serviceProvider.GetRequiredService<WidgetFactory>().GetWidgets();
    }

    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddSingleton<ISettingsManager, SettingsManager>();
        services.AddSingleton<ILayoutManager, LayoutManager>();
        services.AddSingleton<ILocaleManager>(provider =>
        {
            var language = provider.GetRequiredService<ISettingsManager>().Get().Region.Language;

            return new LocaleManager($"{language}.json");
        });
        services.AddSingleton<IWeatherProvider, OpenMeteoWeatherProvider>();
        services.AddSingleton<WidgetFactory>();

        return services.BuildServiceProvider();
    }
}