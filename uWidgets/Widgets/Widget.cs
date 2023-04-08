using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using uWidgets.Models;
using Wpf.Ui.Appearance;
using Application = System.Windows.Application;

namespace uWidgets.Widgets;

public abstract class Widget : Window
{
    public WidgetLayout Layout { get; }
    public Settings Settings { get; }
    public LocaleStrings LocaleStrings { get; }

    protected Widget(WidgetLayout layout, Settings settings, LocaleStrings localeStrings)
    {
        Layout = layout;
        Settings = settings;
        LocaleStrings = localeStrings;
        
        Left = layout.X;
        Top = layout.Y;
        MinWidth = settings.WidgetSize;
        MinHeight = settings.WidgetSize;
        Width = settings.WidgetSize * layout.Columns + settings.WidgetPadding * (layout.Columns - 1);
        Height = settings.WidgetSize * layout.Rows + settings.WidgetPadding * (layout.Rows - 1);
        WindowStyle = WindowStyle.None;
        AllowsTransparency = true;
        ShowInTaskbar = false;
        Background = new SolidColorBrush(Colors.Transparent);
        ContextMenu = GetContextMenu();
        
        MouseLeftButtonDown += OnMouseLeftButtonDown;
        SourceInitialized += OnSourceInitialized;
    }

    private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        var screen = Screen.FromHandle(new WindowInteropHelper(this).Handle);
        
        if (e.ButtonState != MouseButtonState.Pressed) return;
        
        DragMove();
        LimitToScreenBounds(screen);

        if (Settings.Appearance.GridSnap)
        {
            SnapToGrid(Settings, screen);
        }
    }

    private void OnSourceInitialized(object? sender, EventArgs e)
    {
        if (Settings.Appearance.Transparency)
        {
            ApplyTransparency();
        }
        DrawBackground();
        DisableSnapping();
    }
    
    private ContextMenu GetContextMenu() => new ContextMenu().With(
        new MenuItem().With(LocaleStrings.Edit, null, false),
        new Separator(),
        new MenuItem().With(LocaleStrings.Size, null, false),
        new MenuItem().With(LocaleStrings.Small, () => ResizeGrid(1, 1)),
        new MenuItem().With(LocaleStrings.Medium, () => ResizeGrid(2, 2)),
        new MenuItem().With(LocaleStrings.Wide, () => ResizeGrid(4, 2)),
        new MenuItem().With(LocaleStrings.Large, () => ResizeGrid(4, 4)),
        new Separator(),
        new MenuItem().With(LocaleStrings.RemoveWidget, Close),
        new Separator(),
        new MenuItem().With(LocaleStrings.EditWidgets, null, false)
    );

    private void ResizeGrid(int columns, int rows)
    {
        Width = Settings.WidgetSize * columns + Settings.WidgetPadding * (columns - 1);
        Height = Settings.WidgetSize * rows + Settings.WidgetPadding * (rows - 1);
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
    
    private void DrawBackground()
    {
        var border = new Border
        {
            Background = new SolidColorBrush((Color)Application.Current.Resources["ApplicationBackgroundColor"]),
            CornerRadius = new CornerRadius(Settings.Appearance.WidgetRadius)
        };
        
        var content = Content as UIElement;
        Content = border;
        border.Child = content;
    }

    private void ApplyTransparency()
    {
        var corners = Settings.WidgetRadius switch
        {
            0 => WindowCornerPreference.DoNotRound,
            < 8 => WindowCornerPreference.RoundSmall,
            _ => WindowCornerPreference.Round
        };

        Wpf.Ui.Extensions.WindowExtensions.ApplyCorners(this, corners);
        Wpf.Ui.Appearance.Background.Apply(this, BackgroundType.Acrylic);
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