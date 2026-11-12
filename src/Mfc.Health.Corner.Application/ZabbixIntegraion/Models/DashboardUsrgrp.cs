using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class DashboardUsrgrp
    {
        public ulong DashboardUsrgrpid { get; set; }
        public ulong Dashboardid { get; set; }
        public ulong Usrgrpid { get; set; }
        public int Permission { get; set; }

        public virtual Dashboard Dashboard { get; set; }
        public virtual Usrgrp Usrgrp { get; set; }
    }
}
