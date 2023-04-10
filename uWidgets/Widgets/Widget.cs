using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using uWidgets.Infrastructure.Models;
using uWidgets.UI.ContextMenu;
using uWidgets.Utilities;
using Wpf.Ui.Appearance;

namespace uWidgets.Widgets;

public abstract class Widget : Window
{
    protected WidgetLayout WidgetLayout { get; }
    protected AppSettings AppSettings { get; }
    protected LocaleStrings LocaleStrings { get; }
    public event Events.UpdateLayoutHandler UpdateLayoutEvent;

    protected Widget(WidgetLayout widgetLayout, AppSettings appSettings, LocaleStrings localeStrings)
    {
        WidgetLayout = widgetLayout;
        AppSettings = appSettings;
        LocaleStrings = localeStrings;
        
        Left = widgetLayout.X;
        Top = widgetLayout.Y;
        MinWidth = appSettings.WidgetSize;
        MinHeight = appSettings.WidgetSize;
        Width = appSettings.WidgetSize * widgetLayout.Columns + appSettings.WidgetPadding * (widgetLayout.Columns - 1);
        Height = appSettings.WidgetSize * widgetLayout.Rows + appSettings.WidgetPadding * (widgetLayout.Rows - 1);
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
        if (e.ButtonState != MouseButtonState.Pressed) return;
        
        DragMove();
        AfterMoveChecks();
        
        UpdateLayoutEvent.Invoke();
    }

    private void AfterMoveChecks()
    {
        LimitToScreenBounds();

        if (AppSettings.Appearance.GridSnap) 
            SnapToGrid();

        WidgetLayout.X = (int)Left;
        WidgetLayout.Y = (int)Top;
    }

    private void OnSourceInitialized(object? sender, EventArgs e)
    {
        if (AppSettings.Appearance.Transparency) 
            ApplyTransparency();
        
        DrawBackground();
        this.DisableSnapping();
        this.RemoveFromAltTab();
    }

    private ContextMenu GetContextMenu()
    {
        return new ContextMenuBuilder()
            .With(LocaleStrings.Edit, null, false)
            .With(new Separator())
            .With(LocaleStrings.Size, null, false)
            .With(LocaleStrings.Small, () => ResizeGrid(1, 1))
            .With(LocaleStrings.Medium, () => ResizeGrid(2, 2))
            .With(LocaleStrings.Wide, () => ResizeGrid(4, 2))
            .With(LocaleStrings.Large, () => ResizeGrid(4, 4))
            .With(new Separator())
            .With(LocaleStrings.RemoveWidget, Close)
            .With(new Separator())
            .With(LocaleStrings.EditWidgets, null, false)
            .Build();
    }

    private void ResizeGrid(int columns, int rows)
    {
        var oldWidth = Width;
        var oldHeight = Height;
        var newWidth = AppSettings.WidgetSize * columns + AppSettings.WidgetPadding * (columns - 1);
        var newHeight = AppSettings.WidgetSize * rows + AppSettings.WidgetPadding * (rows - 1);
        var steps = 20;
        
        for (var i = 0; i <= steps; i++)
        {
            Width = oldWidth + (newWidth - oldWidth) * i / steps;
            Height = oldHeight + (newHeight - oldHeight) * i / steps;
            Thread.Sleep(1);
        }

        Width = newWidth;
        Height = newHeight;

        WidgetLayout.Columns = columns;
        WidgetLayout.Rows = rows;
        
        AfterMoveChecks();
        
        UpdateLayoutEvent.Invoke();
    }
    
    private void DrawBackground()
    {
        var transparent = AppSettings.Appearance.Transparency;
        var color = (Color)System.Windows.Application.Current.Resources["ApplicationBackgroundColor"];
        if (transparent) color.A = 64;
        
        var border = new Border
        {
            Background = new SolidColorBrush(color),
            CornerRadius = new CornerRadius(transparent ? 0 : AppSettings.Appearance.WidgetRadius)
        };
        
        var content = Content as UIElement;
        Content = border;
        border.Child = content;
    }

    private void ApplyTransparency()
    {
        var corners = AppSettings.WidgetRadius switch
        {
            0 => WindowCornerPreference.DoNotRound,
            < 8 => WindowCornerPreference.RoundSmall,
            _ => WindowCornerPreference.Round
        };

        Wpf.Ui.Extensions.WindowExtensions.ApplyCorners(this, corners);
        Wpf.Ui.Appearance.Background.Apply(this, BackgroundType.Acrylic);
    }

    private void LimitToScreenBounds()
    {
        var screen = this.GetCurrentScreen();
        
        if (Top < 0) Top = 0;
        if (Left < 0) Left = 0;
        if (Top + Height > screen.Bounds.Height) Top = screen.Bounds.Height - Height;
        if (Left + Width > screen.Bounds.Width) Left = screen.Bounds.Width - Width;
    }

    private void SnapToGrid()
    {
        var screen = this.GetCurrentScreen();
        var gridSize = AppSettings.WidgetSize + AppSettings.WidgetPadding;
        
        var oldLeft = Left;
        var oldTop = Top;
        var newLeft = Math.Round(Left / gridSize) * gridSize + screen.Bounds.Width % gridSize - gridSize;
        var newTop = Math.Round(Top / gridSize) * gridSize + AppSettings.WidgetPadding;
        const int steps = 10;
        
        for (var i = 0; i <= steps; i++)
        {
            Left = oldLeft + (newLeft - oldLeft) * i / steps;
            Top = oldTop + (newTop - oldTop) * i / steps;
            Thread.Sleep(5);
        }

        Left = newLeft;
        Top = newTop;
    }
}