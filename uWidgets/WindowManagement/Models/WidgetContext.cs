using System.Collections.Generic;
using uWidgets.Configuration.Models;

namespace uWidgets.WindowManagement.Models;

public class WidgetContext
{
    public WidgetContext(
        AppSettings settings,
        WidgetLayout layout,
        Locale appLocale)
    {
        Settings = settings;
        Layout = layout;
        AppLocale = appLocale;
    }

    public AppSettings Settings { get; }
    public WidgetLayout Layout { get; }
    public Locale AppLocale { get; }
    public Dictionary<string, string> WidgetLocale { get; }
}