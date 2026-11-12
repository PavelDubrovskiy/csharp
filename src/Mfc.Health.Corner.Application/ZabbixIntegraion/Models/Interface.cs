using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Interface
    {
        public Interface()
        {
            InterfaceDiscoveryParentInterfaces = new HashSet<InterfaceDiscovery>();
            Items = new HashSet<Item>();
        }

        public ulong Interfaceid { get; set; }
        public ulong Hostid { get; set; }
        public int Main { get; set; }
        public int Type { get; set; }
        public int Useip { get; set; }
        public string Ip { get; set; }
        public string Dns { get; set; }
        public string Port { get; set; }

        public virtual Host Host { get; set; }
        public virtual InterfaceDiscovery InterfaceDiscoveryInterface { get; set; }
        public virtual InterfaceSnmp InterfaceSnmp { get; set; }
        public virtual ICollection<InterfaceDiscovery> InterfaceDiscoveryParentInterfaces { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
