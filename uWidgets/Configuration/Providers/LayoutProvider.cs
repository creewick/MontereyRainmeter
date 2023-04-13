using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using uWidgets.Configuration.Interfaces;
using uWidgets.Configuration.Models;

namespace uWidgets.Configuration.Providers;

public class LayoutProvider : FileHandler<List<WidgetLayout>>, ILayoutProvider
{
    public LayoutProvider() : base(Path.Combine("Configuration", "layout.json"))
    {
    }

    public WidgetLayout Get(Guid id)
    {
        return Get().Single(layout => layout.Id == id);
    }

    public void Save(WidgetLayout newLayout)
    {
        var layouts = Get().Select(layout => layout.Id != newLayout.Id ? layout : newLayout).ToList();

        Save(layouts);
    }
}