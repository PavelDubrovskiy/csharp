using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class SysmapsLink
    {
        public SysmapsLink()
        {
            SysmapsLinkTriggers = new HashSet<SysmapsLinkTrigger>();
        }

        public ulong Linkid { get; set; }
        public ulong Sysmapid { get; set; }
        public ulong Selementid1 { get; set; }
        public ulong Selementid2 { get; set; }
        public int Drawtype { get; set; }
        public string Color { get; set; }
        public string Label { get; set; }

        public virtual SysmapsElement Selementid1Navigation { get; set; }
        public virtual SysmapsElement Selementid2Navigation { get; set; }
        public virtual Sysmap Sysmap { get; set; }
        public virtual ICollection<SysmapsLinkTrigger> SysmapsLinkTriggers { get; set; }
    }
}
