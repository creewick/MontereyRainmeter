using System.Windows.Controls;
using Shared.Interfaces;

namespace Shared.AppSettingsWindow.Pages;

public interface IAppSettingsPage
{
    public void SetDataContext(IAppSettingsProvider appSettingsProvider);
}