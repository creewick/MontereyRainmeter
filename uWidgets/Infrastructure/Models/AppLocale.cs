using System.Collections.Generic;

namespace uWidgets.Infrastructure.Models;

public class AppLocale
{
    public List<Language> Languages { get; set; }
    public Dictionary<string, LocaleStrings> LocaleStrings { get; set; }   
}

public class Language
{
    public string Code { get; set; }
    public string Name { get; set; }
}

public class LocaleStrings
{
    public string Edit { get; set; }
    public string Size { get; set; }
    public string Small { get; set; }
    public string Medium { get; set; }
    public string Wide { get; set; }
    public string Large { get; set; }
    public string RemoveWidget { get; set; }
    public string EditWidgets { get; set; }
}