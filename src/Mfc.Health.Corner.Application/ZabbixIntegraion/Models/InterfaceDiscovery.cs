using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class InterfaceDiscovery
    {
        public ulong Interfaceid { get; set; }
        public ulong ParentInterfaceid { get; set; }

        public virtual Interface Interface { get; set; }
        public virtual Interface ParentInterface { get; set; }
    }
}
