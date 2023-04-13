using System.Collections.Generic;
using uWidgets.Configuration.Models;

namespace uWidgets.UserInterface.Models;

public class WidgetContext
{
    public AppSettings Settings { get; }
    public WidgetLayout Layout { get; }
    public Locale AppLocale { get; }
    public Dictionary<string, string> WidgetLocale { get; }

    public WidgetContext(
        AppSettings settings, 
        WidgetLayout layout, 
        Locale appLocale)
    {
        Settings = settings;
        Layout = layout;
        AppLocale = appLocale;
    }
}