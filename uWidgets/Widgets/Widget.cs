using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using uWidgets.Infrastructure.Files;
using uWidgets.Infrastructure.Models;
using uWidgets.UI.ContextMenu;
using uWidgets.Utilities;
using Wpf.Ui.Appearance;

namespace uWidgets.Widgets;

public abstract class Widget : Window
{
    protected readonly IFileHandler<AppSettings> SettingsManager;
    protected readonly IFileHandler<List<WidgetLayout>> LayoutManager;
    protected readonly IFileHandler<AppLocale> LocaleManager;
    protected readonly Guid Id;
    
    protected WidgetLayout WidgetLayout => LayoutManager.Get().First(x => x.Id == Id);

    protected Widget(IFileHandler<AppSettings> settingsManager, 
        IFileHandler<List<WidgetLayout>> layoutManager, 
        IFileHandler<AppLocale> localeManager, 
        Guid id)
    {
        SettingsManager = settingsManager;
        LayoutManager = layoutManager;
        LocaleManager = localeManager;
        Id = id;

        SetWindowStyle();
        SetWindowPositionAndSize();
        
        ContextMenu = GetContextMenu();
        
        MouseLeftButtonDown += OnMouseLeftButtonDown;
        SourceInitialized += OnSourceInitialized;
    }

    private void SetWindowStyle()
    {
        WindowStyle = WindowStyle.None;
        AllowsTransparency = true;
        ShowInTaskbar = false;
        Background = new SolidColorBrush(Colors.Transparent);
    }

    private void SetWindowPositionAndSize()
    {
        Left = WidgetLayout.X;
        Top = WidgetLayout.Y;
        MinWidth = SettingsManager.Get().WidgetSize;
        MinHeight = SettingsManager.Get().WidgetSize;
        Width = CalculateSize(WidgetLayout.Columns);
        Height = CalculateSize(WidgetLayout.Rows);
    }

    private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ButtonState != MouseButtonState.Pressed) return;
        
        DragMove();
        AfterMoveChecks();
        
        ChangeLayout(layout =>
        {
            layout.X = (int)Left;
            layout.Y = (int)Top;
        });
    }

    private void AfterMoveChecks()
    {
        LimitToScreenBounds();

        if (SettingsManager.Get().Appearance.GridSnap) 
            SnapToGrid();
    }

    private void OnSourceInitialized(object? sender, EventArgs e)
    {
        if (SettingsManager.Get().Appearance.Transparency) 
            ApplyTransparency();
        
        DrawBackground();
        this.DisableSnapping();
        this.RemoveFromAltTab();
    }

    private ContextMenu GetContextMenu()
    {
        var locale = LocaleManager.Get().LocaleStrings[SettingsManager.Get().Region.Language];
        
        return new ContextMenuBuilder()
            .With(locale.Edit, null, false)
            .With(new Separator())
            .With(locale.Size, null, false)
            .With(locale.Small, () => Resize(1, 1))
            .With(locale.Medium, () => Resize(2, 2))
            .With(locale.Wide, () => Resize(4, 2))
            .With(locale.Large, () => Resize(4, 4))
            .With(new Separator())
            .With(locale.RemoveWidget, Close)
            .With(new Separator())
            .With(locale.EditWidgets, null, false)
            .Build();
    }

    private void Resize(int columns, int rows)
    {
        var oldWidth = Width;
        var oldHeight = Height;
        var newWidth = CalculateSize(columns);
        var newHeight = CalculateSize(rows);
        
        Animate(20, (step, allSteps) =>
        {
            Width = oldWidth + (newWidth - oldWidth) * step / allSteps;
            Height = oldHeight + (newHeight - oldHeight) * step / allSteps;
        });

        Width = newWidth;
        Height = newHeight;
        
        AfterMoveChecks();
        
        ChangeLayout(layout =>
        {
            layout.Columns = columns;
            layout.Rows = rows;
            layout.X = (int)Left;
            layout.Y = (int)Top;
        });
    }
    
    private void DrawBackground()
    {
        var appearanceSettings = SettingsManager.Get().Appearance;
        
        var isTransparent = appearanceSettings.Transparency;
        var color = (Color)System.Windows.Application.Current.Resources["ApplicationBackgroundColor"];
        if (isTransparent) color.A = 64;
        
        var border = new Border
        {
            Background = new SolidColorBrush(color),
            CornerRadius = new CornerRadius(isTransparent ? 0 : appearanceSettings.WidgetRadius)
        };
        
        var content = Content as UIElement;
        Content = border;
        border.Child = content;
    }

    private void ApplyTransparency()
    {
        var corners = SettingsManager.Get().Appearance.WidgetRadius switch
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
        var settings = SettingsManager.Get();
        var screen = this.GetCurrentScreen();
        var gridSize = settings.WidgetSize + settings.WidgetPadding;
        
        var oldLeft = Left;
        var oldTop = Top;
        var newLeft = Math.Round(Left / gridSize) * gridSize + screen.Bounds.Width % gridSize - gridSize;
        var newTop = Math.Round(Top / gridSize) * gridSize + settings.WidgetPadding;

        Animate(10, (step, allSteps) =>
        {
            Left = oldLeft + (newLeft - oldLeft) * step / allSteps;
            Top = oldTop + (newTop - oldTop) * step / allSteps;
        });

        Left = newLeft;
        Top = newTop;
    }

    private static void Animate(int steps, Action<int, int> action)
    {
        Enumerable.Range(0, steps).ToList().ForEach(i =>
        {
            action(i, steps);
            Thread.Sleep(1);
        });
    }

    protected int CalculateSize(int gridSize) => SettingsManager.Get().WidgetSize * gridSize + SettingsManager.Get().WidgetPadding * (gridSize - 1);

    protected void ChangeLayout(Action<WidgetLayout> action)
    {
        var layouts = LayoutManager.Get();
        var layout = layouts.FirstOrDefault(x => x.Id == Id);

        if (layout == null) return;

        action(layout);
        
        LayoutManager.Save(layouts);
    }
}