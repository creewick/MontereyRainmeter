using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WidgetContracts.Widget;

public class WidgetViewModel
{
    public UserControl Content { get; set; }
    public Brush Background { get; set; }
    public CornerRadius Radius { get; set; }
    public string Edit { get; set; }
    public string Size { get; set; }
    public string Small { get; set; }
    public string Medium { get; set; }
    public string Large { get; set; }
    public string RemoveWidget { get; set; }
    public string EditWidgets { get; set; }
}