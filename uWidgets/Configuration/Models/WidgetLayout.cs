using System;
using System.Text.Json;

namespace uWidgets.Configuration.Models;

public class WidgetLayout
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Columns { get; set; }
    public int Rows { get; set; }
    public JsonElement? Options { get; set; }
}