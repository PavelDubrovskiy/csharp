using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class SysmapsLinkTrigger
    {
        public ulong Linktriggerid { get; set; }
        public ulong Linkid { get; set; }
        public ulong Triggerid { get; set; }
        public int Drawtype { get; set; }
        public string Color { get; set; }

        public virtual SysmapsLink Link { get; set; }
        public virtual Trigger Trigger { get; set; }
    }
}
