using System;
using System.Windows.Controls;
using Wpf.Ui.Common;
using MenuItem = Wpf.Ui.Controls.MenuItem;

namespace uWidgets.UserInterface.Services;

public class ContextMenuBuilder
{
    private readonly ContextMenu contextMenu;

    public ContextMenuBuilder()
    {
        contextMenu = new ContextMenu();
    }

    public ContextMenuBuilder With(object item)
    {
        contextMenu.Items.Add(item);
        return this;
    }

    public ContextMenuBuilder With(string header, Action? action, bool isEnabled = true)
    {
        var item = new MenuItem
        {
            Header = header,
            Command = action == null ? null : new RelayCommand(action),
            IsEnabled = isEnabled
        };

        return With(item);
    }

    public ContextMenu Build()
    {
        return contextMenu;
    }
}