using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class ScreensItem
    {
        public ulong Screenitemid { get; set; }
        public ulong Screenid { get; set; }
        public int Resourcetype { get; set; }
        public ulong Resourceid { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Colspan { get; set; }
        public int Rowspan { get; set; }
        public int Elements { get; set; }
        public int Valign { get; set; }
        public int Halign { get; set; }
        public int Style { get; set; }
        public string Url { get; set; }
        public int Dynamic { get; set; }
        public int SortTriggers { get; set; }
        public string Application { get; set; }
        public int MaxColumns { get; set; }

        public virtual Screen Screen { get; set; }
    }
}
