using uWidgets.Configuration.Models;

namespace uWidgets.Configuration.Interfaces;

public interface ISettingsProvider
{
    AppSettings Get();
}