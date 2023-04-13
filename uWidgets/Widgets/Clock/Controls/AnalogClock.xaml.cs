using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using uWidgets.Configuration.Models;

namespace uWidgets.Widgets.Clock.Controls;

public partial class AnalogClock : UserControl
{
    public AnalogClock(ClockSettings clockSettings, AppSettings settings)
    {
        InitializeComponent();
        Settings = settings;

        Timer = new DispatcherTimer
        {
            Interval = clockSettings.ShowSeconds
                ? TimeSpan.FromSeconds(0.1)
                : TimeSpan.FromSeconds(5)
        };
        Timer.Tick += (_,_) => TimerOnTick();
        Timer.Start();
        TimerOnTick();

        SizeChanged += OnResize;
    }

    public AppSettings Settings { get; }
    public DispatcherTimer Timer { get; }

    private void OnResize(object sender, SizeChangedEventArgs e)
    {
        var width = Window.GetWindow(this)!.Width;
        var height = Window.GetWindow(this)!.Height;
        
        var small = Math.Min(width, height) <= Settings.WidgetSize;

        Margin = new Thickness(small ? 4 : 8);
        Strokes.Visibility = small ? Visibility.Hidden : Visibility.Visible;
        Numbers.RenderTransform = small
            ? new ScaleTransform(1.1, 1.1, 500, 500)
            : new ScaleTransform();

        foreach (TextBlock number in Numbers.Children)
            number.FontFamily = (FontFamily)Application.Current.Resources[small ? "SfProLight" : "SfProMedium"];

        foreach (Path secondHandPath in Seconds.Children)
            secondHandPath.StrokeThickness = small ? 12 : 7;
    }

    private void TimerOnTick()
    {
        var now = DateTime.Now;

        Seconds.RenderTransform = new RotateTransform((now.Second + now.Millisecond / 1000.0) * 6, 500, 500);
        Minutes.RenderTransform = new RotateTransform((now.Minute + now.Second / 60.0) * 6, 500, 500);
        Hours.RenderTransform = new RotateTransform((now.Hour + now.Minute / 60.0) * 30, 500, 500);
    }
}