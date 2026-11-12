using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class GroupPrototype
    {
        public GroupPrototype()
        {
            GroupDiscoveries = new HashSet<GroupDiscovery>();
            InverseTemplate = new HashSet<GroupPrototype>();
        }

        public ulong GroupPrototypeid { get; set; }
        public ulong Hostid { get; set; }
        public string Name { get; set; }
        public ulong? Groupid { get; set; }
        public ulong? Templateid { get; set; }

        public virtual Hstgrp Group { get; set; }
        public virtual Host Host { get; set; }
        public virtual GroupPrototype Template { get; set; }
        public virtual ICollection<GroupDiscovery> GroupDiscoveries { get; set; }
        public virtual ICollection<GroupPrototype> InverseTemplate { get; set; }
    }
}
