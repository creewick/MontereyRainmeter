using Avalonia;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Shared.Interfaces;
using Shared.Interfaces.DataManagers;
using Shared.Services;
using uWidgets.DataManagers;
using uWidgets.Services;

namespace uWidgets;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var services = new ServiceCollection()
            .AddSingleton<IWidgetFactory, WidgetFactory>()
            .AddSingleton<IAppSettingsManager>(_ => new AppSettingsManager("appSettings.json"))
            .AddSingleton<IWidgetSettingsManager>(_ => new WidgetSettingsManager("widgets.json", new WidgetSettingsConverter()))
            .AddSingleton<IGridSizeConverter, GridSizeConverter>()
            .BuildServiceProvider();
        
        var appSettingsManager = services.GetRequiredService<IAppSettingsManager>();
        var widgetSettingsManager = services.GetRequiredService<IWidgetSettingsManager>();
        var widgetFactory = services.GetRequiredService<IWidgetFactory>();

        var widgets = widgetFactory.CreateWidgets(widgetSettingsManager.Get());
        widgets.ForEach(widget => widget.Show());

        base.OnFrameworkInitializationCompleted();
    }
}