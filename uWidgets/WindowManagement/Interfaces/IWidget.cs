namespace uWidgets.WindowManagement.Interfaces;

public interface IWidget
{
    public delegate void WidgetMovedHandler(int left, int top);
    public delegate void WidgetResizedHandler(int columns, int rows, bool animate = true);
    public delegate void WidgetOptionsChangedHandler(object settings);
    
    public event WidgetMovedHandler WidgetMoved;
    public event WidgetResizedHandler WidgetResized;
    public event WidgetOptionsChangedHandler WidgetOptionsChanged;
}