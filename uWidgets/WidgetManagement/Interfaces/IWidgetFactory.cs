using System.Collections.Generic;

namespace uWidgets.WidgetManagement.Interfaces;

public interface IWidgetFactory
{
    public List<IWidget> GetWidgets();
}