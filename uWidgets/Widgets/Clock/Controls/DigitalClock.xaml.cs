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
    public DigitalClock(ClockSettings clockSettings, AppSettings settings)
    {
        InitializeComponent();
        ClockSettings = clockSettings;
        Settings = settings;

        Timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(1)
        };
        Timer.Tick += (_,_) => TimerOnTick();
        Timer.Start();
        Initialized += (_, _) => TimerOnTick();
        SizeChanged += OnSizeChanged;
    }

    public ClockSettings ClockSettings { get; }
    public AppSettings Settings { get; }
    public DispatcherTimer Timer { get; }
    private string shortDate;
    private string longDate;

    private void OnSizeChanged(object sender, SizeChangedEventArgs e)
    {
        var width = Window.GetWindow(this)!.Width;
        var height = Window.GetWindow(this)!.Height;

        var small = Math.Min(width, height) <= Settings.WidgetSize;
        var mediumWidth = width <= Settings.WidgetSize * 2 + Settings.WidgetPadding;
        var smallHeight = height <= Settings.WidgetSize;
        
        Margin = new Thickness(small ? 4 : 16);
        Date.Visibility = small ? Visibility.Hidden : Visibility.Visible;
        Date.Text = mediumWidth ? shortDate : longDate;


        // TimeViewbox.VerticalAlignment = smallHeight ? VerticalAlignment.Center : VerticalAlignment.Top;
    }

    private void TimerOnTick()
    {
        var now = DateTime.Now;
        var cultureInfo = new CultureInfo(Settings.Region.Language);
        var mediumWidth = Window.GetWindow(this)!.Width <= Settings.WidgetSize * 2 + Settings.WidgetPadding;

        var hours = ClockSettings.ShowAMPM ? DateTimeFormat.Hours12 : DateTimeFormat.Hours24;
        var minutes = DateTimeFormat.Minutes;
        var seconds = ClockSettings.ShowSeconds ? DateTimeFormat.Seconds : string.Empty;
        var ampm = ClockSettings.ShowAMPM ? DateTimeFormat.Ampm : string.Empty;

        shortDate = now.ToString(DateTimeFormat.DateShort, cultureInfo);
        longDate = Capitalize(now.ToString(DateTimeFormat.Date, cultureInfo));

        Time.Text = now.ToString($"{hours}{minutes}{seconds}{ampm}");
        Date.Text = mediumWidth ? shortDate : longDate;
    }

    private static string Capitalize(string text)
    {
        return char.ToUpper(text[0]) + text[1..];
    }
}