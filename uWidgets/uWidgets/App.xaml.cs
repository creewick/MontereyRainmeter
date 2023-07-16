using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Shared.Interfaces;
using uWidgets.Providers;
using uWidgets.Services;
using uWidgets.Themes;
using uWidgets.WidgetFactory;
using uWidgets.WidgetManager;

namespace uWidgets;

public partial class App
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var services = ConfigureServices();
        
        services.GetRequiredService<IThemeProvider>().Apply();
        services.GetRequiredService<IWidgetManager>().Run();
    }

    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddSingleton<IAppSettingsProvider, AppSettingsProvider>();
        services.AddSingleton<ILayoutProvider, LayoutProvider>();
        services.AddSingleton<IThemeProvider, WpfUiThemeProvider>();
        services.AddSingleton<IStringLocalizer>(serviceCollection =>
        {
            var appSettings = serviceCollection.GetRequiredService<IAppSettingsProvider>().Get();
            
            return new LocaleProvider(appSettings.Region.Language);
        });

        services.AddSingleton<IClassActivator, ClassActivator>();
        services.AddSingleton<IWidgetFactory, WidgetFactory.WidgetFactory>();
        services.AddSingleton<IWidgetManager, WidgetManager.WidgetManager>();

        return services.BuildServiceProvider();
    }
}