using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class HostsGroup
    {
        public ulong Hostgroupid { get; set; }
        public ulong Hostid { get; set; }
        public ulong Groupid { get; set; }

        public virtual Hstgrp Group { get; set; }
        public virtual Host Host { get; set; }
    }
}
