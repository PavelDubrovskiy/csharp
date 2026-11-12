using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Valuemap
    {
        public Valuemap()
        {
            Items = new HashSet<Item>();
            Mappings = new HashSet<Mapping>();
        }

        public ulong Valuemapid { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<Mapping> Mappings { get; set; }
    }
}
