using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class ApplicationDiscovery
    {
        public ulong ApplicationDiscoveryid { get; set; }
        public ulong Applicationid { get; set; }
        public ulong ApplicationPrototypeid { get; set; }
        public string Name { get; set; }
        public int Lastcheck { get; set; }
        public int TsDelete { get; set; }

        public virtual Application Application { get; set; }
        public virtual ApplicationPrototype ApplicationPrototype { get; set; }
    }
}
