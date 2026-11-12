using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Dashboard
    {
        public Dashboard()
        {
            DashboardUsers = new HashSet<DashboardUser>();
            DashboardUsrgrps = new HashSet<DashboardUsrgrp>();
            Widgets = new HashSet<Widget>();
        }

        public ulong Dashboardid { get; set; }
        public string Name { get; set; }
        public ulong? Userid { get; set; }
        public int Private { get; set; }
        public ulong? Templateid { get; set; }

        public virtual Host Template { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<DashboardUser> DashboardUsers { get; set; }
        public virtual ICollection<DashboardUsrgrp> DashboardUsrgrps { get; set; }
        public virtual ICollection<Widget> Widgets { get; set; }
    }
}
