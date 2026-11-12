using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class TrendsUint
    {
        public ulong Itemid { get; set; }
        public int Clock { get; set; }
        public int Num { get; set; }
        public ulong ValueMin { get; set; }
        public ulong ValueAvg { get; set; }
        public ulong ValueMax { get; set; }
    }
}
