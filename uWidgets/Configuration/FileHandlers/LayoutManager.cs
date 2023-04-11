using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using uWidgets.Configuration.Interfaces;
using uWidgets.Configuration.Models;

namespace uWidgets.Configuration.FileHandlers;

public class LayoutManager : FileHandler<IReadOnlyList<WidgetLayout>>, ILayoutManager
{
    public LayoutManager() : base(Path.Combine("Configuration", "layout.json")) { }

    public WidgetLayout Get(Guid id) => Get().Single(layout => layout.Id == id);
}