using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class History
    {
        public ulong Itemid { get; set; }
        public int Clock { get; set; }
        public double Value { get; set; }
        public int Ns { get; set; }
    }
}
