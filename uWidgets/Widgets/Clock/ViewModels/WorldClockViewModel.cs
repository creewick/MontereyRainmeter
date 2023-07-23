using System.ComponentModel;
using Shared.Interfaces;
using Shared.Models;

namespace Clock.ViewModels;

public class WorldClockViewModel : INotifyPropertyChanged
{
    public double Margin => appSettings.WidgetSize * 0.05;

    private AppSettings appSettings;
    public event PropertyChangedEventHandler? PropertyChanged;

    public WorldClockViewModel(IAppSettingsProvider appSettingsProvider)
    {
        appSettings = appSettingsProvider.Get();

        appSettingsProvider.Updated += (_, _) =>
        {
            appSettings = appSettingsProvider.Get();
            Update();
        };
    }

    protected virtual void Update() => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
}