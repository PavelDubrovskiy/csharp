using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Trend
    {
        public ulong Itemid { get; set; }
        public int Clock { get; set; }
        public int Num { get; set; }
        public double ValueMin { get; set; }
        public double ValueAvg { get; set; }
        public double ValueMax { get; set; }
    }
}
