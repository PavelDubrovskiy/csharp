using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class SysmapUser
    {
        public ulong Sysmapuserid { get; set; }
        public ulong Sysmapid { get; set; }
        public ulong Userid { get; set; }
        public int Permission { get; set; }

        public virtual Sysmap Sysmap { get; set; }
        public virtual User User { get; set; }
    }
}
