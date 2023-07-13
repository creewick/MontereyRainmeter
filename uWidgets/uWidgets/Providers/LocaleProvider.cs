using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Localization;
using Shared.Services;
using uWidgets.Services;

namespace uWidgets.Providers;

public class LocaleProvider : IStringLocalizer
{
    private readonly JsonFileParser<Dictionary<string, string>> jsonFileParser;

    public LocaleProvider(string languageCode)
    {
        var path = PathBuilder.GetLocaleFile(languageCode);
        jsonFileParser = new JsonFileParser<Dictionary<string, string>>(path);
    }
    
    public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
    {
        return jsonFileParser.Read().Select(pair => new LocalizedString(pair.Key, pair.Value));
    }

    public LocalizedString this[string name] => jsonFileParser.Read().TryGetValue(name, out var value)
        ? new LocalizedString(name, value)
        : new LocalizedString(name, name, true);

    public LocalizedString this[string name, params object[] arguments] => this[name];
}