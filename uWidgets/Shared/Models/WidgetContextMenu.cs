using Wpf.Ui.Common;

namespace Shared.Models;

public class WidgetContextMenu
{
    public RelayCommand EditWidget { get; set; }
    public RelayCommand Small { get; set; }
    public RelayCommand Medium { get; set; }
    public RelayCommand Large { get; set; }
    public RelayCommand RemoveWidget { get; set; }
    public RelayCommand EditWidgets { get; set; }
    public RelayCommand DarkMode { get; set; }
    public RelayCommand LightMode { get; set; }
}