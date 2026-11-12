using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class MaintenancesWindow
    {
        public ulong MaintenanceTimeperiodid { get; set; }
        public ulong Maintenanceid { get; set; }
        public ulong Timeperiodid { get; set; }

        public virtual Maintenance Maintenance { get; set; }
        public virtual Timeperiod Timeperiod { get; set; }
    }
}
