using System.Collections.Generic;
using uWidgets.WindowManagement.WindowTypes;

namespace uWidgets.WindowManagement.Interfaces;

public interface IWidgetFactory
{
    public List<WidgetBase> GetWidgets();
}