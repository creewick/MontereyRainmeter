using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Shared.Models;

public class WidgetViewModel
{
    public Brush Background { get; set; }
    public CornerRadius CornerRadius { get; set; }
    public UserControl Control { get; set; }
}