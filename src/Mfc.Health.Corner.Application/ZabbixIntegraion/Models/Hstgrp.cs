using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Hstgrp
    {
        public Hstgrp()
        {
            Configs = new HashSet<Config>();
            CorrConditionGroups = new HashSet<CorrConditionGroup>();
            GroupPrototypes = new HashSet<GroupPrototype>();
            HostsGroups = new HashSet<HostsGroup>();
            MaintenancesGroups = new HashSet<MaintenancesGroup>();
            OpcommandGrps = new HashSet<OpcommandGrp>();
            Opgroups = new HashSet<Opgroup>();
            Rights = new HashSet<Right>();
            Scripts = new HashSet<Script>();
            TagFilters = new HashSet<TagFilter>();
            WidgetFields = new HashSet<WidgetField>();
        }

        public ulong Groupid { get; set; }
        public string Name { get; set; }
        public int Internal { get; set; }
        public int Flags { get; set; }

        public virtual GroupDiscovery GroupDiscovery { get; set; }
        public virtual ICollection<Config> Configs { get; set; }
        public virtual ICollection<CorrConditionGroup> CorrConditionGroups { get; set; }
        public virtual ICollection<GroupPrototype> GroupPrototypes { get; set; }
        public virtual ICollection<HostsGroup> HostsGroups { get; set; }
        public virtual ICollection<MaintenancesGroup> MaintenancesGroups { get; set; }
        public virtual ICollection<OpcommandGrp> OpcommandGrps { get; set; }
        public virtual ICollection<Opgroup> Opgroups { get; set; }
        public virtual ICollection<Right> Rights { get; set; }
        public virtual ICollection<Script> Scripts { get; set; }
        public virtual ICollection<TagFilter> TagFilters { get; set; }
        public virtual ICollection<WidgetField> WidgetFields { get; set; }
    }
}
