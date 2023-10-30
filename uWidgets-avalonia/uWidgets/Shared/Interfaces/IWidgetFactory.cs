using Shared.Models;
using Shared.Templates;

namespace Shared.Interfaces;

public interface IWidgetFactory
{
    public List<Widget> CreateWidgets(IEnumerable<WidgetSettings> widgets);
}