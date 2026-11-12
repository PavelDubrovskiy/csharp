using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class ApplicationPrototype
    {
        public ApplicationPrototype()
        {
            ApplicationDiscoveries = new HashSet<ApplicationDiscovery>();
            InverseTemplate = new HashSet<ApplicationPrototype>();
            ItemApplicationPrototypes = new HashSet<ItemApplicationPrototype>();
        }

        public ulong ApplicationPrototypeid { get; set; }
        public ulong Itemid { get; set; }
        public ulong? Templateid { get; set; }
        public string Name { get; set; }

        public virtual Item Item { get; set; }
        public virtual ApplicationPrototype Template { get; set; }
        public virtual ICollection<ApplicationDiscovery> ApplicationDiscoveries { get; set; }
        public virtual ICollection<ApplicationPrototype> InverseTemplate { get; set; }
        public virtual ICollection<ItemApplicationPrototype> ItemApplicationPrototypes { get; set; }
    }
}
