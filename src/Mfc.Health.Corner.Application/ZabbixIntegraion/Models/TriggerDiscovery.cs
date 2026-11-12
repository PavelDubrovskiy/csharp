using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class TriggerDiscovery
    {
        public ulong Triggerid { get; set; }
        public ulong ParentTriggerid { get; set; }
        public int Lastcheck { get; set; }
        public int TsDelete { get; set; }

        public virtual Trigger ParentTrigger { get; set; }
        public virtual Trigger Trigger { get; set; }
    }
}
