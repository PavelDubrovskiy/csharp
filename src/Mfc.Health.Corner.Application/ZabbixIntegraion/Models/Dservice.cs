using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Dservice
    {
        public ulong Dserviceid { get; set; }
        public ulong Dhostid { get; set; }
        public string Value { get; set; }
        public int Port { get; set; }
        public int Status { get; set; }
        public int Lastup { get; set; }
        public int Lastdown { get; set; }
        public ulong Dcheckid { get; set; }
        public string Ip { get; set; }
        public string Dns { get; set; }

        public virtual Dcheck Dcheck { get; set; }
        public virtual Dhost Dhost { get; set; }
    }
}
