using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class SysmapElementUrl
    {
        public ulong Sysmapelementurlid { get; set; }
        public ulong Selementid { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public virtual SysmapsElement Selement { get; set; }
    }
}
