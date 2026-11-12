using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Widget
    {
        public Widget()
        {
            WidgetFields = new HashSet<WidgetField>();
        }

        public ulong Widgetid { get; set; }
        public ulong Dashboardid { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int ViewMode { get; set; }

        public virtual Dashboard Dashboard { get; set; }
        public virtual ICollection<WidgetField> WidgetFields { get; set; }
    }
}
