using Avalonia;
using Avalonia.Animation;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;
using Shared.Interfaces;
using Shared.Interfaces.DataManagers;
using Shared.Services;

namespace Shared.Templates;

public abstract partial class Widget : Window
{
    public event EventHandler? WidgetOpened;
    public event EventHandler? WidgetClosed;
    public event EventHandler? WidgetMoved;
    public event EventHandler? WidgetResized;
    
    private readonly GridSizeConverter gridSizeConverter;
    
    public Widget(IAppSettingsManager appSettingsManager, IWidgetSettingsManager widgetSettingsManager, Guid id)
    {
        InitializeComponent();
        
        gridSizeConverter = new GridSizeConverter(appSettingsManager);

        var widgetSettings = widgetSettingsManager.Get(id)!;
        Position = new PixelPoint(widgetSettings.X, widgetSettings.Y);
        Width = gridSizeConverter.GetPixels(widgetSettings.Columns);
        Height = gridSizeConverter.GetPixels(widgetSettings.Rows);

        PointerPressed += OnPointerPressed;

        #if DEBUG
        this.AttachDevTools();
        #endif
    }
    
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
        WidgetOpened?.Invoke(this, EventArgs.Empty);
    }

    private void OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        ContextMenu?.Close();

        if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed) 
            BeginMoveDrag(e);

        WidgetMoved?.Invoke(this, EventArgs.Empty);
    }

    private void SetWidgetSize(int columns, int rows)
    {
        var oldWidth = Width;
        var oldHeight = Height;
        var newWidth = gridSizeConverter.GetPixels(columns);
        var newHeight = gridSizeConverter.GetPixels(rows);

        new Animation
        {
            Duration = TimeSpan.FromMilliseconds(300),
            Children =
            {
                new KeyFrame
                {
                    Cue = default,
                    Setters =
                    {
                        new Setter(WidthProperty, oldWidth),
                        new Setter(HeightProperty, oldHeight)
                    }
                },
                new KeyFrame
                {
                    Cue = new Cue(1),
                    Setters =
                    {
                        new Setter(WidthProperty, newWidth),
                        new Setter(HeightProperty, newHeight)
                    }
                }
            }
        }
            .RunAsync(this)
            .ContinueWith(_ => WidgetResized?.Invoke(this, EventArgs.Empty));
    }

    private void SetSmallSize(object? sender, RoutedEventArgs e) => SetWidgetSize(1, 1);
    private void SetMediumSize(object? sender, RoutedEventArgs e) => SetWidgetSize(2, 2);
    private void SetWideSize(object? sender, RoutedEventArgs e) => SetWidgetSize(4, 2);
    private void SetLargeSize(object? sender, RoutedEventArgs e) => SetWidgetSize(4, 4);
    
    private void Close(object? sender, RoutedEventArgs e)
    {
        Close();
        WidgetClosed?.Invoke(this, EventArgs.Empty);
    }
}