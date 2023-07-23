using System;
using System.Linq;
using Shared.Interfaces;

namespace Shared.AppSettingsWindow.Pages;

public partial class AboutPage : IPage
{
    public string? Version { get; set; }

    public AboutPage()
    {
        InitializeComponent();
    }

    public void SetDataContext(IAppSettingsProvider appSettingsProvider)
    {
        DataContext = this;

        Version = AppDomain.CurrentDomain.GetAssemblies()
            .FirstOrDefault(a => a.GetName().Name == "uWidgets")?
            .GetName()?.Version?.ToString();
    }
}