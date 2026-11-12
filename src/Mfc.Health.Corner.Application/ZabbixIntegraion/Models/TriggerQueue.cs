using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class TriggerQueue
    {
        public ulong Objectid { get; set; }
        public int Type { get; set; }
        public int Clock { get; set; }
        public int Ns { get; set; }
    }
}
