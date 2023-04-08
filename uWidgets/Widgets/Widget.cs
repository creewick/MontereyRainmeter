using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Effects;
using uWidgets.Models;
using Wpf.Ui.Appearance;
using Wpf.Ui.Common;
using Application = System.Windows.Application;

namespace uWidgets.Widgets;

public abstract class Widget : Window
{

    protected Widget(WidgetLayout layout, Settings settings, Locale locale)
    {
        MinWidth = settings.WidgetSize;
        MinHeight = settings.WidgetSize;
        Width = settings.WidgetSize * layout.Columns + settings.WidgetPadding * (layout.Columns - 1);
        Height = settings.WidgetSize * layout.Rows + settings.WidgetPadding * (layout.Rows - 1);
        Left = layout.X;
        Top = layout.Y;
        ShowInTaskbar = false;
        WindowStyle = WindowStyle.None;
        AllowsTransparency = true;
        Background = new SolidColorBrush(Colors.Transparent);
        ContextMenu = GetContextMenu(settings, locale);
        MouseLeftButtonDown += (_, e) => DragWidget(e, settings);
        SourceInitialized += (_, _) => DrawBackground(settings);
        SourceInitialized += (_, _) => DisableSnapping();
    }

    private ContextMenu GetContextMenu(Settings settings, Locale locale)
    {
        var menu = new ContextMenu();
        menu.Items.Add(new MenuItem { Header = locale.Edit, IsEnabled = false });
        menu.Items.Add(new Separator());
        menu.Items.Add(new MenuItem { Header = locale.Size, IsEnabled = false });
        menu.Items.Add(new MenuItem { Header = locale.Small, Command = new RelayCommand(() => ResizeGrid(1, 1, settings)) });
        menu.Items.Add(new MenuItem { Header = locale.Medium, Command = new RelayCommand(() => ResizeGrid(2, 2, settings)) });
        menu.Items.Add(new MenuItem { Header = locale.Wide, Command = new RelayCommand(() => ResizeGrid(4, 2, settings)) });
        menu.Items.Add(new MenuItem { Header = locale.Large, Command = new RelayCommand(() => ResizeGrid(4, 4, settings)) });
        menu.Items.Add(new Separator());
        menu.Items.Add(new MenuItem { Header = locale.RemoveWidget, Command = new RelayCommand(Close) });
        menu.Items.Add(new Separator());
        menu.Items.Add(new MenuItem { Header = locale.EditWidgets, IsEnabled = false });
        
        return menu;
    }

    private void ResizeGrid(int columns, int rows, Settings settings)
    {
        Width = settings.WidgetSize * columns + settings.WidgetPadding * (columns - 1);
        Height = settings.WidgetSize * rows + settings.WidgetPadding * (rows - 1);
    }

    private void DisableSnapping()
    {
        var source = PresentationSource.FromVisual(this) as HwndSource;
        source?.AddHook(DisableSnappingHook);
    }
    
    private const int WM_SYSCOMMAND = 0x112;
    private const int SC_MOVE = 0xF010;
    private const int WM_MOUSELEAVE = 0x2A2;
    
    private IntPtr DisableSnappingHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
    {
        if (msg == WM_SYSCOMMAND)
        {
            if ((wParam.ToInt32() & ~0x0F) == SC_MOVE)
                ResizeMode = ResizeMode.NoResize;
        }
        else if (msg == WM_MOUSELEAVE)
        {
            ResizeMode = ResizeMode.CanResize;
        }

        return IntPtr.Zero;
    }
    
    private void DrawBackground(Settings settings)
    {
        if (settings.Appearance.Transparency) ApplyTransparency(settings);

        var border = new Border
        {
            Background = new SolidColorBrush((Color)Application.Current.Resources["ApplicationBackgroundColor"]),
            CornerRadius = new CornerRadius(settings.Appearance.WidgetRadius)
        };
        
        var content = Content as UIElement;
        Content = border;
        border.Child = content;
    }

    private void ApplyTransparency(Settings settings)
    {
        var corners = settings.WidgetRadius switch
        {
            0 => WindowCornerPreference.DoNotRound,
            < 8 => WindowCornerPreference.RoundSmall,
            _ => WindowCornerPreference.Round
        };

        Wpf.Ui.Extensions.WindowExtensions.ApplyCorners(this, corners);
        Wpf.Ui.Appearance.Background.Apply(this, BackgroundType.Acrylic);
    }

    private void DragWidget(MouseButtonEventArgs e, Settings settings)
    {
        var screen = Screen.FromHandle(new WindowInteropHelper(this).Handle);
        
        if (e.ButtonState != MouseButtonState.Pressed) return;
        
        DragMove();
        LimitToScreenBounds(screen);

        if (settings.Appearance.GridSnap) SnapToGrid(settings, screen);
    }

    private void LimitToScreenBounds(Screen screen)
    {
        if (Top < 0) Top = 0;
        if (Left < 0) Left = 0;
        if (Top + Height > screen.Bounds.Height) Top = screen.Bounds.Height - Height;
        if (Left + Width > screen.Bounds.Width) Left = screen.Bounds.Width - Width;
    }

    private void SnapToGrid(Settings settings, Screen screen)
    {
        var gridSize = settings.WidgetSize + settings.WidgetPadding;
        
        Left = Math.Round(Left / gridSize) * gridSize + screen.Bounds.Width % gridSize - gridSize;
        Top = Math.Round(Top / gridSize) * gridSize + settings.WidgetPadding;
    }
}