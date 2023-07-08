using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Localization;
using uWidgets.Locales.Models;
using uWidgets.Settings.Services;

namespace uWidgets.Locales.Repositories;

public class LocaleRepository : JsonFileParser<Locale>, IStringLocalizer
{
    public LocaleRepository(string languageCode) : base(Path.Combine("Locales", languageCode + ".json"))
    {
    }

    public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
    {
        return Get().Select(pair => new LocalizedString(pair.Key, pair.Value));
    }

    public LocalizedString this[string name] => Get().TryGetValue(name, out var value) 
        ? new LocalizedString(name, value) 
        : new LocalizedString(name, name, true);

    public LocalizedString this[string name, params object[] arguments] => this[name];
}