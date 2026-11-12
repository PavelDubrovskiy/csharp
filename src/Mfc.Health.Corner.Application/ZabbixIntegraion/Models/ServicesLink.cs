using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class ServicesLink
    {
        public ulong Linkid { get; set; }
        public ulong Serviceupid { get; set; }
        public ulong Servicedownid { get; set; }
        public int Soft { get; set; }

        public virtual Service Servicedown { get; set; }
        public virtual Service Serviceup { get; set; }
    }
}
