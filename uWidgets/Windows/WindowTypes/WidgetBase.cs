using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Extensions.Localization;
using uWidgets.Settings.Models;
using uWidgets.Windows.Services;

namespace uWidgets.Windows.WindowTypes;

public class WidgetBase : WindowBase
{
    private readonly AppSettings appSettings;
    public WidgetSettings WidgetSettings;
    
    private readonly IStringLocalizer locale;
    private readonly GridSizeConverter gridSizeConverter;

    public event EventHandler? WidgetMoved;
    public event WidgetResizedEventHandler? WidgetResized;

    public delegate void WidgetResizedEventHandler(Size size);

    public WidgetBase(AppSettings appSettings, WidgetSettings widgetSettings, IStringLocalizer locale) : base(appSettings)
    {
        gridSizeConverter = new GridSizeConverter(appSettings);

        this.appSettings = appSettings;
        WidgetSettings = widgetSettings;
        this.locale = locale;

        ShowInTaskbar = false;
        Left = widgetSettings.X;
        Top = widgetSettings.Y;
        Width = gridSizeConverter.GetPixels(widgetSettings.Columns);
        Height = gridSizeConverter.GetPixels(widgetSettings.Rows);
        MinWidth = appSettings.WidgetSize;
        MinHeight = appSettings.WidgetSize;
        ContextMenu = GetContextMenu();

        SourceInitialized += OnSourceInitialized;
        MouseLeftButtonDown += OnMouseLeftButtonDown;
        MouseLeftButtonUp += OnMouseLeftButtonUp;
    }

    private void OnSourceInitialized(object? sender, EventArgs e)
    {
        this.RemoveFromAltTab();
        this.ResizeEnd(() => WidgetResized?.Invoke(new Size(Width, Height)));
    }

    private void OnMouseLeftButtonDown(object? sender, MouseButtonEventArgs e)
    {
        if (ResizeMode != ResizeMode.NoResize)
        {
            ResizeMode = ResizeMode.NoResize;
        }
        
        DragMove();
        
        WidgetMoved?.Invoke(this, EventArgs.Empty);
    }

    private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        if (ResizeMode == ResizeMode.NoResize)
        {
            ResizeMode = ResizeMode.CanResizeWithGrip;
        }
    }

    private ContextMenu GetContextMenu() => new ContextMenuBuilder()
        .With($"{locale["Edit"]} «{locale[WidgetSettings.Name]}»", null)
        .With(new Separator())
        .With(locale["Size"], null, false)
        .With(locale["Small"], () => Resize(2, 2))
        .With(locale["Medium"], () => Resize(4, 2))
        .With(locale["Large"], () => Resize(4, 4))
        .With(new Separator())
        .With(locale["Remove widget"], Close)
        .With(new Separator())
        .With(locale["Edit widgets"], null)
        .Build();


    private void Resize(int columns, int rows)
    {
        WidgetResized?.Invoke(new Size(
            gridSizeConverter.GetPixels(columns),
            gridSizeConverter.GetPixels(rows)    
        ));
    }
}