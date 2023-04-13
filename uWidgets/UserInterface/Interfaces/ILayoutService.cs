using System.Windows;
using uWidgets.UserInterface.WindowTypes;

namespace uWidgets.UserInterface.Interfaces;

public interface ILayoutService
{
    void OnWidgetMove(WidgetBase widget);
    void OnWidgetResize(WidgetBase window, int columns, int rows, bool animate);
    void KeepOnScreen(WindowBase window);
    void SnapToGrid(WindowBase window, bool animate);
    void ResizeByGridUnits(WindowBase window, int columns, int rows, bool animate);
    int GetPixelsByGridUnits(int units);
}