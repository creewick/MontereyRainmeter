using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;
using uWidgets.Configuration.Models;
using uWidgets.UserInterface.Animations;
using uWidgets.UserInterface.Interfaces;

namespace uWidgets.UserInterface.Services;

public class LayoutService : ILayoutService
{
    private AppSettings Settings { get; }

    public LayoutService(AppSettings settings)
    {
        Settings = settings;
    }
    
    public void OnWidgetMove(Window widget)
    {
        KeepOnScreen(widget);

        if (Settings.Appearance.GridSnap)
            SnapToGrid(widget);
    }

    public void OnWidgetResize(Window widget, int columns, int rows, bool animate = true)
    {
        ResizeByGridUnits(widget, columns, rows, animate);
        OnWidgetMove(widget);
    }
    
    public void KeepOnScreen(Window window)
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

    public void SnapToGrid(Window window)
    {
        var screen = Screen.FromHandle(new WindowInteropHelper(window).Handle);

        var span = Settings.WidgetSize + Settings.WidgetPadding;
        var offset = screen.WorkingArea.Width % span;
        
        var oldLeft = window.Left;
        var oldTop = window.Top;
        
        var newLeft = Math.Round((window.Left - offset) / span) * span + offset + screen.WorkingArea.Left;
        var newTop = Math.Round(window.Top / span) * span + Settings.WidgetPadding + screen.WorkingArea.Top;
        
        new AnimationBuilder(10)
            .Add(new LinearAnimation(left => window.Left = left, oldLeft, newLeft))
            .Add(new LinearAnimation(top => window.Top = top, oldTop, newTop))
            .Animate();
    }

    public void ResizeByGridUnits(Window window, int columns, int rows, bool animate = true)
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