using System;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Windows.Media;
using uWidgets.Configuration.Interfaces;
using uWidgets.Configuration.Models;
using uWidgets.UserInterface.Animations;
using uWidgets.UserInterface.Models;
using uWidgets.WidgetManagement.Models;

namespace uWidgets.UserInterface.Services;

public class WidgetLayoutService
{
    private readonly ISettingsManager settingsManager;
    private readonly ILayoutManager layoutManager;
    private readonly Guid widgetId;
    private readonly Widget widget;

    public WidgetLayoutService(ISettingsManager settingsManager, ILayoutManager layoutManager, Guid widgetId, Widget widget)
    {
        this.settingsManager = settingsManager;
        this.layoutManager = layoutManager;
        this.widgetId = widgetId;
        this.widget = widget;
    }

    public void SetWindowProperties()
    {
        var layout = layoutManager.Get(widgetId);
        var settings = settingsManager.Get();
        
        widget.WindowStyle = WindowStyle.None;
        widget.AllowsTransparency = true;
        widget.ShowInTaskbar = false;
        widget.Background = new SolidColorBrush(Colors.Transparent);
        
        widget.Left = layout.X;
        widget.Top = layout.Y;
        widget.MinWidth = settings.WidgetSize;
        widget.MinHeight = settings.WidgetSize;
        widget.Width = CalculateSize(layout.Columns);
        widget.Height = CalculateSize(layout.Rows);
    }

    public void OnResize(int columns, int rows)
    {
        var oldWidth = widget.Width;
        var oldHeight = widget.Height;
        var newWidth = CalculateSize(columns);
        var newHeight = CalculateSize(rows);

        new AnimationBuilder(20)
            .Add(new LinearAnimation(width => widget.Width = width, oldWidth, newWidth))
            .Add(new LinearAnimation(height => widget.Height = height, oldHeight, newHeight))
            .Animate();

        ChangeLayout(layout =>
        {
            layout.Columns = columns;
            layout.Rows = rows;
        });
        
        OnMove();
    }

    public void OnMove()
    {
        var screen = Screen.FromHandle(new WindowInteropHelper(widget).Handle);

        LimitToScreenBounds(screen);

        if (settingsManager.Get().Appearance.GridSnap) 
            SnapToGrid(screen);
        
        ChangeLayout(layout =>
        {
            layout.X = (int)widget.Left;
            layout.Y = (int)widget.Top;
        });
    }

    public void LimitToScreenBounds(Screen screen)
    {
        widget.Left = Math.Clamp(widget.Left, screen.WorkingArea.Top, screen.WorkingArea.Right - widget.Width);
        widget.Top = Math.Clamp(widget.Top, screen.WorkingArea.Top, screen.WorkingArea.Bottom - widget.Height);
    }

    public void SnapToGrid(Screen screen)
    {
        var settings = settingsManager.Get();
        var span = settings.WidgetSize + settings.WidgetPadding;

        var oldLeft = widget.Left;
        var oldTop = widget.Top;

        var offset = screen.WorkingArea.Width % span;

        var newLeft = Math.Round((widget.Left - offset) / span) * span + offset + screen.WorkingArea.Left;
        var newTop = Math.Round(widget.Top / span) * span + settings.WidgetPadding + screen.WorkingArea.Top;

        new AnimationBuilder(10)
            .Add(new LinearAnimation(left => widget.Left = left, oldLeft, newLeft))
            .Add(new LinearAnimation(top => widget.Top = top, oldTop, newTop))
            .Animate();
    }

    public int CalculateSize(int span)
    {
        var settings = settingsManager.Get();
        return settings.WidgetSize * span + settings.WidgetPadding * (span - 1);
    }
    
    private void ChangeLayout(Action<WidgetLayout> action)
    {
        var layouts = layoutManager.Get();

        var layout = layoutManager.Get(widgetId);
        action(layout);
        
        layoutManager.Save(layouts);
    }
}