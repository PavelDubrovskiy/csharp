using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class MaintenancesGroup
    {
        public ulong MaintenanceGroupid { get; set; }
        public ulong Maintenanceid { get; set; }
        public ulong Groupid { get; set; }

        public virtual Hstgrp Group { get; set; }
        public virtual Maintenance Maintenance { get; set; }
    }
}
