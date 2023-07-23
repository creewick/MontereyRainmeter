using System.Windows;

namespace Calendar.ViewModels;

public class MonthViewCellViewModel
{
    public string Text { get; set; } = string.Empty;
    public double Opacity { get; set; } = 0;
    public Visibility Circle { get; set; } = Visibility.Collapsed;
}