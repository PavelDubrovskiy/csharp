using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class AutoregHost
    {
        public ulong AutoregHostid { get; set; }
        public ulong? ProxyHostid { get; set; }
        public string Host { get; set; }
        public string ListenIp { get; set; }
        public int ListenPort { get; set; }
        public string ListenDns { get; set; }
        public string HostMetadata { get; set; }
        public int Flags { get; set; }
        public int TlsAccepted { get; set; }

        public virtual Host ProxyHost { get; set; }
    }
}
