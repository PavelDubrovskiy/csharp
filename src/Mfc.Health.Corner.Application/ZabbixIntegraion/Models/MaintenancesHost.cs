using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class MaintenancesHost
    {
        public ulong MaintenanceHostid { get; set; }
        public ulong Maintenanceid { get; set; }
        public ulong Hostid { get; set; }

        public virtual Host Host { get; set; }
        public virtual Maintenance Maintenance { get; set; }
    }
}
