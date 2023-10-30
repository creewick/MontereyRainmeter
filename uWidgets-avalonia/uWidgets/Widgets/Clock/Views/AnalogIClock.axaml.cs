using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace uWidgets.Clock.Views;

public partial class AnalogIClock : UserControl
{
    public AnalogIClock()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}