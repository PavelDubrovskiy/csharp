using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class GraphDiscovery
    {
        public ulong Graphid { get; set; }
        public ulong ParentGraphid { get; set; }
        public int Lastcheck { get; set; }
        public int TsDelete { get; set; }

        public virtual Graph Graph { get; set; }
        public virtual Graph ParentGraph { get; set; }
    }
}
