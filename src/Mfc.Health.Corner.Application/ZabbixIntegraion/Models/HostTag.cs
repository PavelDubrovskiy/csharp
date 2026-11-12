using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class HostTag
    {
        public ulong Hosttagid { get; set; }
        public ulong Hostid { get; set; }
        public string Tag { get; set; }
        public string Value { get; set; }

        public virtual Host Host { get; set; }
    }
}
