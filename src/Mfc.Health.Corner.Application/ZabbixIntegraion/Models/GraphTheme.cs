using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class GraphTheme
    {
        public ulong Graphthemeid { get; set; }
        public string Theme { get; set; }
        public string Backgroundcolor { get; set; }
        public string Graphcolor { get; set; }
        public string Gridcolor { get; set; }
        public string Maingridcolor { get; set; }
        public string Gridbordercolor { get; set; }
        public string Textcolor { get; set; }
        public string Highlightcolor { get; set; }
        public string Leftpercentilecolor { get; set; }
        public string Rightpercentilecolor { get; set; }
        public string Nonworktimecolor { get; set; }
        public string Colorpalette { get; set; }
    }
}
