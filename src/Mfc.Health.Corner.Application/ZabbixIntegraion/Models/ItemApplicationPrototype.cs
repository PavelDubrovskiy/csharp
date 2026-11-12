using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class ItemApplicationPrototype
    {
        public ulong ItemApplicationPrototypeid { get; set; }
        public ulong ApplicationPrototypeid { get; set; }
        public ulong Itemid { get; set; }

        public virtual ApplicationPrototype ApplicationPrototype { get; set; }
        public virtual Item Item { get; set; }
    }
}
