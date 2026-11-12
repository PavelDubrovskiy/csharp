using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class IconMap
    {
        public IconMap()
        {
            IconMappings = new HashSet<IconMapping>();
            Sysmaps = new HashSet<Sysmap>();
        }

        public ulong Iconmapid { get; set; }
        public string Name { get; set; }
        public ulong DefaultIconid { get; set; }

        public virtual Image DefaultIcon { get; set; }
        public virtual ICollection<IconMapping> IconMappings { get; set; }
        public virtual ICollection<Sysmap> Sysmaps { get; set; }
    }
}
