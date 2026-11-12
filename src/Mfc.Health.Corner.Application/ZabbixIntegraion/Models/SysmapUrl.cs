using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class SysmapUrl
    {
        public ulong Sysmapurlid { get; set; }
        public ulong Sysmapid { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int Elementtype { get; set; }

        public virtual Sysmap Sysmap { get; set; }
    }
}
