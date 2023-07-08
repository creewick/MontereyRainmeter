namespace uWidgets.Settings.Models;

public abstract class WidgetSettings
{
    public string Name { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Columns { get; set; }
    public int Rows { get; set; }
}