using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class HostDiscovery
    {
        public ulong Hostid { get; set; }
        public ulong? ParentHostid { get; set; }
        public ulong? ParentItemid { get; set; }
        public string Host { get; set; }
        public int Lastcheck { get; set; }
        public int TsDelete { get; set; }

        public virtual Host HostNavigation { get; set; }
        public virtual Host ParentHost { get; set; }
        public virtual Item ParentItem { get; set; }
    }
}
