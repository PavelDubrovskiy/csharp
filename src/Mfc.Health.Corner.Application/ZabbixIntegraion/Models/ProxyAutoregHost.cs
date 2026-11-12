using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class ProxyAutoregHost
    {
        public ulong Id { get; set; }
        public int Clock { get; set; }
        public string Host { get; set; }
        public string ListenIp { get; set; }
        public int ListenPort { get; set; }
        public string ListenDns { get; set; }
        public string HostMetadata { get; set; }
        public int Flags { get; set; }
        public int TlsAccepted { get; set; }
    }
}
