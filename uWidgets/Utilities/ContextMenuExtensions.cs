using System;
using System.Windows.Controls;
using Wpf.Ui.Common;

namespace uWidgets.Models;

public static class ContextMenuExtensions
{
    public static ContextMenu With(this ContextMenu menu, params object[] items)
    {
        foreach (var item in items) 
            menu.Items.Add(item);

        return menu;
    }

    public static MenuItem With(this MenuItem item, string header, Action? action, bool isEnabled = true)
    {
        item.Header = header;
        if (action != null) item.Command = new RelayCommand(action);
        item.IsEnabled = isEnabled;

        return item;
    }
}
