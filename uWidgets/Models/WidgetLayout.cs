using System.Text.Json;

namespace uWidgets.Models;

public class WidgetLayout
{
    public string Name { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Columns { get; set; }
    public int Rows { get; set; }
    public JsonElement? Settings { get; set; } 
}