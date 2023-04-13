using System;
using System.Windows.Controls;
using System.Windows.Input;
using uWidgets.UserInterface.Models;
using uWidgets.UserInterface.Services;
using uWidgets.WindowManagement.Interfaces;
using uWidgets.Windows.WidgetOptions;

namespace uWidgets.UserInterface.WindowTypes;

public abstract class WidgetBase : WindowBase, IWidget
{
    public event IWidget.WidgetMovedHandler WidgetMoved;
    public event IWidget.WidgetResizedHandler WidgetResized;
    public event IWidget.WidgetOptionsChangedHandler WidgetOptionsChanged;
    protected WidgetContext Context { get; }

    protected WidgetBase(WidgetContext context) : base(context.Settings)
    {
        Context = context;
        ShowInTaskbar = false;
        Left = context.Layout.X;
        Top = context.Layout.Y;
        Width = context.Settings.WidgetSize;
        Height = context.Settings.WidgetSize;
        MinWidth = context.Settings.WidgetSize;
        MinHeight = context.Settings.WidgetSize;
        ContextMenu = GetContextMenu();
        
        MouseLeftButtonDown += OnMouseLeftButtonDown;
        SourceInitialized += OnSourceInitialized;
        Loaded += (_,_) => WidgetResized.Invoke(Context.Layout.Columns, Context.Layout.Rows, false);
    }
    
    private void OnSourceInitialized(object? sender, EventArgs e)
    {
        WindowOsIntegrationService.DisableWindowSnapping(this);
        WindowOsIntegrationService.RemoveWindowFromAltTab(this);
    }
    
    private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ButtonState != MouseButtonState.Pressed) return;
        
        DragMove();

        WidgetMoved.Invoke((int)Left, (int)Top);
    }
    
    private ContextMenu GetContextMenu()
    {
        return new ContextMenuBuilder()
            .With($"{Context.AppLocale["Edit"]} «{Context.Layout.Name}»", () => new WidgetOptions(Context, null))
            .With(new Separator())
            .With(Context.AppLocale["Size"], null, false)
            .With(Context.AppLocale["Small"], () => WidgetResized.Invoke(1, 1))
            .With(Context.AppLocale["Medium"], () => WidgetResized.Invoke(2, 2))
            .With(Context.AppLocale["Wide"], () => WidgetResized.Invoke(4, 2))
            .With(Context.AppLocale["Large"], () => WidgetResized.Invoke(4, 4))
            .With(new Separator())
            .With(Context.AppLocale["RemoveWidget"], Close)
            .With(new Separator())
            .With(Context.AppLocale["EditWidgets"], null, false)
            .Build();
    }
}