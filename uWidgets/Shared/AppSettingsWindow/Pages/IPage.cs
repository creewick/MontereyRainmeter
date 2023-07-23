using Shared.Interfaces;

namespace Shared.AppSettingsWindow.Pages;

public interface IPage
{
    public void SetDataContext(IAppSettingsProvider appSettingsProvider);
}