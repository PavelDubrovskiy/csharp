using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class ConfigAutoregTl
    {
        public ulong AutoregTlsid { get; set; }
        public string TlsPskIdentity { get; set; }
        public string TlsPsk { get; set; }
    }
}
