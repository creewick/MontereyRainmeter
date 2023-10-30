using Shared.Models;

namespace Shared.Interfaces.DataManagers;

public interface IWidgetSettingsManager : IDataManager<IEnumerable<WidgetSettings>>
{
    public WidgetSettings? Get(Guid id);
    
    public void Update(WidgetSettings widgetSettings);
}