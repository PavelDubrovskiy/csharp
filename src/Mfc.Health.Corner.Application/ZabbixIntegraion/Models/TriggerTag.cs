using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class TriggerTag
    {
        public ulong Triggertagid { get; set; }
        public ulong Triggerid { get; set; }
        public string Tag { get; set; }
        public string Value { get; set; }

        public virtual Trigger Trigger { get; set; }
    }
}
