using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class InterfaceSnmp
    {
        public ulong Interfaceid { get; set; }
        public int Version { get; set; }
        public int Bulk { get; set; }
        public string Community { get; set; }
        public string Securityname { get; set; }
        public int Securitylevel { get; set; }
        public string Authpassphrase { get; set; }
        public string Privpassphrase { get; set; }
        public int Authprotocol { get; set; }
        public int Privprotocol { get; set; }
        public string Contextname { get; set; }

        public virtual Interface Interface { get; set; }
    }
}
