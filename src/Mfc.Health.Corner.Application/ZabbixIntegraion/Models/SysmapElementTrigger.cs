using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class SysmapElementTrigger
    {
        public ulong SelementTriggerid { get; set; }
        public ulong Selementid { get; set; }
        public ulong Triggerid { get; set; }

        public virtual SysmapsElement Selement { get; set; }
        public virtual Trigger Trigger { get; set; }
    }
}
