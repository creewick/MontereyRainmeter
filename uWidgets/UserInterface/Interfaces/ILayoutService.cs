using System.Windows;

namespace uWidgets.UserInterface.Interfaces;

public interface ILayoutService
{
    void OnWidgetMove(Window widget);
    void OnWidgetResize(Window window, int columns, int rows, bool animate);
    void KeepOnScreen(Window window);
    void SnapToGrid(Window window);
    void ResizeByGridUnits(Window window, int columns, int rows, bool animate);
    int GetPixelsByGridUnits(int units);
}