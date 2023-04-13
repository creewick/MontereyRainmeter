using System.Collections.Generic;
using uWidgets.UserInterface.WindowTypes;

namespace uWidgets.WindowManagement.Interfaces;

public interface IWidgetFactory
{
    public List<WidgetBase> GetWidgets();
}