using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class ProxyDhistory
    {
        public ulong Id { get; set; }
        public int Clock { get; set; }
        public ulong Druleid { get; set; }
        public string Ip { get; set; }
        public int Port { get; set; }
        public string Value { get; set; }
        public int Status { get; set; }
        public ulong? Dcheckid { get; set; }
        public string Dns { get; set; }
    }
}
