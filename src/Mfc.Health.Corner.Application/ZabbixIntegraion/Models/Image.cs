using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Image
    {
        public Image()
        {
            IconMappings = new HashSet<IconMapping>();
            IconMaps = new HashSet<IconMap>();
            Sysmaps = new HashSet<Sysmap>();
            SysmapsElementIconidDisabledNavigations = new HashSet<SysmapsElement>();
            SysmapsElementIconidMaintenanceNavigations = new HashSet<SysmapsElement>();
            SysmapsElementIconidOffNavigations = new HashSet<SysmapsElement>();
            SysmapsElementIconidOnNavigations = new HashSet<SysmapsElement>();
        }

        public ulong Imageid { get; set; }
        public int Imagetype { get; set; }
        public string Name { get; set; }
        public byte[] Image1 { get; set; }

        public virtual ICollection<IconMapping> IconMappings { get; set; }
        public virtual ICollection<IconMap> IconMaps { get; set; }
        public virtual ICollection<Sysmap> Sysmaps { get; set; }
        public virtual ICollection<SysmapsElement> SysmapsElementIconidDisabledNavigations { get; set; }
        public virtual ICollection<SysmapsElement> SysmapsElementIconidMaintenanceNavigations { get; set; }
        public virtual ICollection<SysmapsElement> SysmapsElementIconidOffNavigations { get; set; }
        public virtual ICollection<SysmapsElement> SysmapsElementIconidOnNavigations { get; set; }
    }
}
