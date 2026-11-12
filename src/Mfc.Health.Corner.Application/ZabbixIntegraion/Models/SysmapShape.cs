using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class SysmapShape
    {
        public ulong SysmapShapeid { get; set; }
        public ulong Sysmapid { get; set; }
        public int Type { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Text { get; set; }
        public int Font { get; set; }
        public int FontSize { get; set; }
        public string FontColor { get; set; }
        public int TextHalign { get; set; }
        public int TextValign { get; set; }
        public int BorderType { get; set; }
        public int BorderWidth { get; set; }
        public string BorderColor { get; set; }
        public string BackgroundColor { get; set; }
        public int Zindex { get; set; }

        public virtual Sysmap Sysmap { get; set; }
    }
}
