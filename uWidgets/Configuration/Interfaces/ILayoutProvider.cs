using System;
using System.Collections.Generic;
using uWidgets.Configuration.Models;

namespace uWidgets.Configuration.Interfaces;

public interface ILayoutProvider
{
    WidgetLayout Get(Guid id);
    List<WidgetLayout> Get();
}