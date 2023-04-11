using System;
using System.Collections.Generic;
using uWidgets.Configuration.Models;

namespace uWidgets.Configuration.Interfaces;

public interface ILayoutManager : IFileHandler<IReadOnlyList<WidgetLayout>>
{
    WidgetLayout Get(Guid id);
}