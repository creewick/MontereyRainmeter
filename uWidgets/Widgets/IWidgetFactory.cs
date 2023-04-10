using System.Collections.Generic;

namespace uWidgets.Widgets;

public interface IWidgetFactory
{
    public List<Widget> GetWidgets();
}