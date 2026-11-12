using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class HostsTemplate
    {
        public ulong Hosttemplateid { get; set; }
        public ulong Hostid { get; set; }
        public ulong Templateid { get; set; }

        public virtual Host Host { get; set; }
        public virtual Host Template { get; set; }
    }
}
