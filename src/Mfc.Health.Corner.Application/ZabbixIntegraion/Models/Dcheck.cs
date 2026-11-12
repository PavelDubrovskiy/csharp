using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Dcheck
    {
        public Dcheck()
        {
            Dservices = new HashSet<Dservice>();
        }

        public ulong Dcheckid { get; set; }
        public ulong Druleid { get; set; }
        public int Type { get; set; }
        public string Key { get; set; }
        public string SnmpCommunity { get; set; }
        public string Ports { get; set; }
        public string Snmpv3Securityname { get; set; }
        public int Snmpv3Securitylevel { get; set; }
        public string Snmpv3Authpassphrase { get; set; }
        public string Snmpv3Privpassphrase { get; set; }
        public int Uniq { get; set; }
        public int Snmpv3Authprotocol { get; set; }
        public int Snmpv3Privprotocol { get; set; }
        public string Snmpv3Contextname { get; set; }
        public int HostSource { get; set; }
        public int NameSource { get; set; }

        public virtual Drule Drule { get; set; }
        public virtual ICollection<Dservice> Dservices { get; set; }
    }
}
