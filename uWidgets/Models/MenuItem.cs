using System;
using Wpf.Ui.Common;

namespace uWidgets.Models;

public class MenuItem : System.Windows.Controls.MenuItem
{
    public MenuItem(string header, Action? action, bool isEnabled = true) : base()
    {
        Header = header;
        if (action != null) Command = new RelayCommand(action);
        IsEnabled = isEnabled;
    }
}