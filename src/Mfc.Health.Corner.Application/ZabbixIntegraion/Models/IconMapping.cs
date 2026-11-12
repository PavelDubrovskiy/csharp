using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class IconMapping
    {
        public ulong Iconmappingid { get; set; }
        public ulong Iconmapid { get; set; }
        public ulong Iconid { get; set; }
        public int InventoryLink { get; set; }
        public string Expression { get; set; }
        public int Sortorder { get; set; }

        public virtual Image Icon { get; set; }
        public virtual IconMap Iconmap { get; set; }
    }
}
