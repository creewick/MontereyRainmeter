using System;
using System.Collections.Generic;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using uWidgets.Infrastructure.Files;
using uWidgets.Infrastructure.Models;
using uWidgets.Utilities;
using uWidgets.Widgets;

namespace uWidgets.Application;

public partial class App
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var serviceProvider = ConfigureServices();
        
        // Workaround to make Wpf.Ui.Appearance.Theme.Apply work
        Current.MainWindow = new Window();

        var settingsHandler = serviceProvider.GetRequiredService<IFileHandler<AppSettings>>();

        ThemeBuilder.Apply(settingsHandler.Get().Appearance);

        serviceProvider.GetRequiredService<WidgetFactory>().GetWidgets();
    }

    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddSingleton<IFileHandler<AppSettings>>(_ => new FileHandler<AppSettings>("appSettings.json"));
        services.AddSingleton<IFileHandler<AppLocale>>(_ => new FileHandler<AppLocale>("locale.json"));
        services.AddSingleton<IFileHandler<List<WidgetLayout>>>(_ => new FileHandler<List<WidgetLayout>>("layout.json"));
        services.AddSingleton<WidgetFactory>();

        return services.BuildServiceProvider();
    }
}