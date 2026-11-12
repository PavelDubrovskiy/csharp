using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class ItemDiscovery
    {
        public ulong Itemdiscoveryid { get; set; }
        public ulong Itemid { get; set; }
        public ulong ParentItemid { get; set; }
        public string Key { get; set; }
        public int Lastcheck { get; set; }
        public int TsDelete { get; set; }

        public virtual Item Item { get; set; }
        public virtual Item ParentItem { get; set; }
    }
}
