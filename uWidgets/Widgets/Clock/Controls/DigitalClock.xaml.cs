using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using uWidgets.Configuration.Models;
using uWidgets.UserInterface.Models;

namespace uWidgets.Widgets.Clock.Controls;

public partial class DigitalClock : UserControl
{
    public ClockSettings ClockSettings { get; }
    public AppSettings Settings { get; }
    public DispatcherTimer Timer { get; }

    public DigitalClock(ClockSettings clockSettings, AppSettings settings)
    {
        InitializeComponent();
        ClockSettings = clockSettings;
        Settings = settings;

        Timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(1)
        };
        Timer.Tick += TimerOnTick;
        Timer.Start();
        
        SizeChanged += OnSizeChanged;
    }

    private void OnSizeChanged(object sender, SizeChangedEventArgs e)
    {
        var width = Window.GetWindow(this)!.Width;
        var height = Window.GetWindow(this)!.Height;
        
        var small = Math.Min(width, height) <= Settings.WidgetSize;
        var smallHeight = height <= Settings.WidgetSize;
        
        Date.Visibility = small ? Visibility.Hidden : Visibility.Visible;

        Grid.RowDefinitions[0].Height = new GridLength(smallHeight ? 0 : 1, GridUnitType.Star);
        TimeViewbox.VerticalAlignment = smallHeight ? VerticalAlignment.Center : VerticalAlignment.Top;
    }

    private void TimerOnTick(object? sender, EventArgs e)
    {
        var now = DateTime.Now;
        var cultureInfo = new CultureInfo(Settings.Region.Language);
        var smallWidth = Width <= Settings.WidgetSize * 2 + Settings.WidgetPadding;

        var hours = ClockSettings.ShowAMPM ? DateTimeFormat.Hours12 : DateTimeFormat.Hours24;
        var minutes = DateTimeFormat.Minutes;
        var seconds = ClockSettings.ShowSeconds ? DateTimeFormat.Seconds : string.Empty;
        var ampm = ClockSettings.ShowAMPM ? DateTimeFormat.Ampm : string.Empty;
        var date = smallWidth ? DateTimeFormat.Date : DateTimeFormat.DateShort;

        Time.Text = now.ToString($"{hours}{minutes}{seconds}{ampm}");
        Date.Text = Capitalize(now.ToString(date, cultureInfo));
    }
    
    private static string Capitalize(string text) => char.ToUpper(text[0]) + text[1..];

}