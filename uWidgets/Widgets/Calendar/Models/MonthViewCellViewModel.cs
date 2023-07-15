using System.Windows;
using System.Windows.Media;

namespace Calendar.Models;

public class MonthViewCellViewModel
{
    public string Text { get; set; } = string.Empty;
    public double Opacity { get; set; } = 0;
    public SolidColorBrush Background { get; set; } = new(Colors.Transparent);
    public SolidColorBrush Foreground { get; set; } = (SolidColorBrush)Application.Current.Resources["TextFillColorPrimaryBrush"];
}