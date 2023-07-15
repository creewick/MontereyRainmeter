using System;
using System.ComponentModel;
using System.Windows.Controls;
using Shared.Interfaces;
using Shared.Services;
using Shared.Templates;

namespace uWidgets.WidgetFactory;

public class WidgetFactory : IWidgetFactory
{
    private readonly IClassActivator classActivator;

    public WidgetFactory(IClassActivator classActivator)
    {
        this.classActivator = classActivator;
    }
    
    public Widget CreateWidget(IWidgetSettingsProvider widgetSettingsProvider)
    {
        var widgetSettings = widgetSettingsProvider.Get();
        
        if (widgetSettings == null)
            throw new ArgumentNullException(nameof(widgetSettings));

        var assemblyPath = PathBuilder.GetWidgetFile(widgetSettings.Type);
        var controlName = widgetSettings.Subtype;

        var control = (UserControl) classActivator.Activate(assemblyPath, null, controlName);
        var viewModel = (INotifyPropertyChanged) classActivator.Activate(assemblyPath, typeof(INotifyPropertyChanged), null, widgetSettingsProvider);

        control.DataContext = viewModel;

        return (Widget) classActivator.Activate(typeof(Widget), control, widgetSettingsProvider);
    }
}