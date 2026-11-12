using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class MaintenanceTag
    {
        public ulong Maintenancetagid { get; set; }
        public ulong Maintenanceid { get; set; }
        public string Tag { get; set; }
        public int Operator { get; set; }
        public string Value { get; set; }

        public virtual Maintenance Maintenance { get; set; }
    }
}
