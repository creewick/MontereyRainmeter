using System;
using Wpf.Ui.Common;
using Wpf.Ui.Controls;

namespace uWidgets.UserInterface.Services;

public class ContextMenuBuilder
{
    private readonly System.Windows.Controls.ContextMenu contextMenu;
    
    public ContextMenuBuilder()
    {
        contextMenu = new System.Windows.Controls.ContextMenu();
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

        return this.With(item);
    }

    public System.Windows.Controls.ContextMenu Build() => contextMenu;
}