using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using uWidgets.Locales.Repositories;
using uWidgets.Settings.Models;
using uWidgets.Settings.Repositories;
using uWidgets.Themes;
using uWidgets.Windows.Services;
using uWidgets.Windows.WidgetManager;
using uWidgets.Windows.WidgetManager.WidgetFactory;

namespace uWidgets;

public partial class App
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var serviceProvider = ConfigureServices();
        
        serviceProvider.GetRequiredService<IThemeService>().Apply();
        serviceProvider.GetRequiredService<IWidgetManager>().Run();
    }

    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddSingleton<IRepository<AppSettings>, AppSettingsRepository>();
        services.AddSingleton<AppSettings>(provider => 
            provider.GetRequiredService<IRepository<AppSettings>>().Get());
        
        services.AddSingleton<IRepository<WidgetSettings[]>, WidgetSettingsRepository>();
        services.AddSingleton<WidgetSettings[]>(provider => 
            provider.GetRequiredService<IRepository<WidgetSettings[]>>().Get());

        services.AddSingleton<IStringLocalizer>(provider => 
            new LocaleRepository(provider
                .GetRequiredService<AppSettings>()
                .Region.Language));
        
        services.AddSingleton<IThemeService, WpfUiThemeService>();
        services.AddSingleton<IWidgetFactory, WidgetFactory>();
        services.AddSingleton<IWidgetManager, WidgetManager>();

        services.AddSingleton<GridSizeConverter>();

        return services.BuildServiceProvider();
    }
}