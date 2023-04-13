using System.IO;
using uWidgets.Configuration.Interfaces;
using uWidgets.Configuration.Models;

namespace uWidgets.Configuration.Providers;

public class LocaleProvider : FileHandler<Locale>, ILocaleProvider
{
    public LocaleProvider(string language) : base(Path.Combine("Configuration", "Locales", language + ".json")) { }
    public LocaleProvider(string widgetName, string language) : base(Path.Combine("Widgets", widgetName, "Locales", language + ".json")) { }
}