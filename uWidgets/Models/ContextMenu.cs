namespace uWidgets.Models;

public class ContextMenu : System.Windows.Controls.ContextMenu
{
    public ContextMenu(params object[] items) : base()
    {
        foreach (var item in items) Items.Add(item);
    }
}