using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;
using uWidgets.UserInterface.Models;
using uWidgets.UserInterface.Services;
using uWidgets.WindowManagement.Models;
using uWidgets.WindowManagement.WindowTypes;

namespace uWidgets.Windows.WidgetOptions;

public partial class WidgetOptions : WindowBase
{
    private bool isClosing;

    public WidgetOptions(WidgetContext context, UIElement control) : base(context.Settings)
    {
        InitializeComponent();

        ShowInTaskbar = false;
        MinWidth = 0;
        MinHeight = 0;
        Left = context.Layout.X;
        Top = context.Layout.Y;
        // Width = CalculateSize(4);
        // Height = CalculateSize(4);
        LimitToScreenBounds();

        WidgetName.Text = context.Layout.Name;

        SourceInitialized += OnSourceInitialized;
        Deactivated += (_, _) => TryClose();

        Show();

        var oldLeft = Left;

        // new AnimationBuilder(20)
        //     .Add(new LinearAnimation(width => Width = width, 0, CalculateSize(4)))
        //     .Add(new LinearAnimation(left => Left = left, oldLeft + CalculateSize(2), oldLeft))
        //     .Animate();
    }

    private void OnSourceInitialized(object? sender, EventArgs e)
    {
        WindowOsIntegrationService.DisableWindowSnapping(this);
        WindowOsIntegrationService.RemoveWindowFromAltTab(this);
    }

    private void LimitToScreenBounds()
    {
        var screen = Screen.FromHandle(new WindowInteropHelper(this).Handle);

        Left = Math.Clamp(Left, screen.WorkingArea.Top, screen.WorkingArea.Right - Width);
        Top = Math.Clamp(Top, screen.WorkingArea.Top, screen.WorkingArea.Bottom - Height);
    }

    private void TryClose()
    {
        if (isClosing) return;

        isClosing = true;

        var oldLeft = Left;
        // new AnimationBuilder(20)
        //     .Add(new LinearAnimation(width => Width = width, CalculateSize(4), 0))
        //     .Add(new LinearAnimation(left => Left = left, oldLeft, oldLeft + CalculateSize(2)))
        //     .Animate();

        Close();
    }

    private void Done_OnClick(object sender, RoutedEventArgs e)
    {
        TryClose();
    }
}