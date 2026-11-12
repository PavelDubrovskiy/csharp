using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class DashboardUser
    {
        public ulong DashboardUserid { get; set; }
        public ulong Dashboardid { get; set; }
        public ulong Userid { get; set; }
        public int Permission { get; set; }

        public virtual Dashboard Dashboard { get; set; }
        public virtual User User { get; set; }
    }
}
