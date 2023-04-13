using System;
using System.Windows.Forms;
using System.Windows.Interop;
using uWidgets.Configuration.Interfaces;
using uWidgets.Configuration.Models;
using uWidgets.UserInterface.Animations;
using uWidgets.UserInterface.Interfaces;
using uWidgets.WindowManagement.WindowTypes;

namespace uWidgets.UserInterface.Services;

public class LayoutService : ILayoutService
{
    public LayoutService(AppSettings settings, ILayoutProvider layoutProvider)
    {
        Settings = settings;
        LayoutProvider = layoutProvider;
    }

    private AppSettings Settings { get; }
    private ILayoutProvider LayoutProvider { get; }

    public void OnWidgetMove(WidgetBase widget)
    {
        KeepOnScreen(widget);

        if (Settings.Appearance.GridSnap)
            SnapToGrid(widget);

        LayoutProvider.Save(new WidgetLayout
        {
            Id = widget.Context.Layout.Id,
            Name = widget.Context.Layout.Name,
            X = (int)widget.Left,
            Y = (int)widget.Top,
            Columns = widget.Context.Layout.Columns,
            Rows = widget.Context.Layout.Rows,
            Options = widget.Context.Layout.Options
        });
    }

    public void OnWidgetResize(WidgetBase widget, int columns, int rows, bool animate = true)
    {
        ResizeByGridUnits(widget, columns, rows, animate);
        KeepOnScreen(widget);

        if (Settings.Appearance.GridSnap)
            SnapToGrid(widget, animate);

        LayoutProvider.Save(new WidgetLayout
        {
            Id = widget.Context.Layout.Id,
            Name = widget.Context.Layout.Name,
            X = (int)widget.Left,
            Y = (int)widget.Top,
            Columns = columns,
            Rows = rows,
            Options = widget.Context.Layout.Options
        });
    }

    public void KeepOnScreen(WindowBase window)
    {
        var screen = Screen.FromHandle(new WindowInteropHelper(window).Handle);

        window.Left = Math.Clamp(
            window.Left,
            screen.WorkingArea.Top,
            screen.WorkingArea.Right - window.Width);

        window.Top = Math.Clamp(
            window.Top,
            screen.WorkingArea.Top,
            screen.WorkingArea.Bottom - window.Height);
    }

    public void SnapToGrid(WindowBase window, bool animate = true)
    {
        var screen = Screen.FromHandle(new WindowInteropHelper(window).Handle);

        var span = Settings.WidgetSize + Settings.WidgetPadding;
        var offset = screen.WorkingArea.Width % span;

        var oldLeft = window.Left;
        var oldTop = window.Top;

        var newLeft = Math.Round((window.Left - offset) / span) * span + offset + screen.WorkingArea.Left;
        var newTop = Math.Round(window.Top / span) * span + Settings.WidgetPadding + screen.WorkingArea.Top;

        if (animate)
        {
            new AnimationBuilder(10)
                .Add(new LinearAnimation(left => window.Left = left, oldLeft, newLeft))
                .Add(new LinearAnimation(top => window.Top = top, oldTop, newTop))
                .Animate();
        }
        else
        {
            window.Left = newLeft;
            window.Top = newTop;
        }
    }

    public void ResizeByGridUnits(WindowBase window, int columns, int rows, bool animate = true)
    {
        var oldWidth = window.Width;
        var oldHeight = window.Height;

        var newWidth = GetPixelsByGridUnits(columns);
        var newHeight = GetPixelsByGridUnits(rows);

        if (animate)
        {
            new AnimationBuilder(20)
                .Add(new LinearAnimation(width => window.Width = width, oldWidth, newWidth))
                .Add(new LinearAnimation(height => window.Height = height, oldHeight, newHeight))
                .Animate();
        }
        else
        {
            window.Width = newWidth;
            window.Height = newHeight;
        }
    }

    public int GetPixelsByGridUnits(int units)
    {
        return Settings.WidgetSize * units +
               Settings.WidgetPadding * (units - 1);
    }
}