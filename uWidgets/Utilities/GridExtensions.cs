using System.Windows;
using System.Windows.Controls;

namespace uWidgets.Utilities;

public static class GridExtensions
{
    public static Grid With(this Grid grid, UIElement element, int column = 0, int row = 0, int columnSpan = 1, int rowSpan = 1)
    {
        grid.Children.Add(element);
        
        Grid.SetColumn(element, column);
        Grid.SetRow(element, row);
        Grid.SetColumnSpan(element, columnSpan);
        Grid.SetRowSpan(element, rowSpan);

        return grid;
    } 
}