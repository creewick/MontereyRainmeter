using System;
using System.Windows;
using System.Windows.Controls;
using Shared.Interfaces;
using Shared.Models;
using Shared.Services;

namespace uWidgets.WidgetFactory;

public class WidgetFactory : IWidgetFactory
{
    private readonly IClassActivator classActivator;

    public WidgetFactory(IClassActivator classActivator)
    {
        this.classActivator = classActivator;
    }
    
    public Widget CreateWidget(WidgetSettings widgetSettings)
    {
        if (widgetSettings == null)
            throw new ArgumentNullException(nameof(widgetSettings));

        var assemblyPath = PathBuilder.GetWidgetFile(widgetSettings.Type);
        var controlName = widgetSettings.Subtype;

        var control = (UserControl) classActivator.Activate(assemblyPath, null, controlName);

        return (Widget) classActivator.Activate(typeof(Widget), control);
    }
}