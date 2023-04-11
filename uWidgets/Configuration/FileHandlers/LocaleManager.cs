using System.Collections.Generic;
using System.IO;
using uWidgets.Configuration.Interfaces;

namespace uWidgets.Configuration.FileHandlers;

public class LocaleManager : FileHandler<Dictionary<string, string>>, ILocaleManager
{
    public LocaleManager(string filename) : base(Path.Combine("Configuration", "Locales", filename)) { }
}