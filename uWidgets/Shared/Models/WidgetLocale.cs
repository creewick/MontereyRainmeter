using Microsoft.Extensions.Localization;

namespace Shared.Models;

public class WidgetLocale
{
    private readonly IStringLocalizer locale;
    private readonly string widgetName;

    public WidgetLocale(IStringLocalizer locale, string widgetName)
    {
        this.locale = locale;
        this.widgetName = widgetName;
    }
    
    public string Edit => $"{locale["Edit"]} «{widgetName}»";
    public string Size => locale["Size"];
    public string Small => locale["Small"];
    public string Medium => locale["Medium"];
    public string Large => locale["Large"];
    public string RemoveWidget => locale["Remove widget"];
    public string EditWidgets => locale["Edit widgets"];
}