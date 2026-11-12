using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Maintenance
    {
        public Maintenance()
        {
            EventSuppresses = new HashSet<EventSuppress>();
            Hosts = new HashSet<Host>();
            MaintenanceTags = new HashSet<MaintenanceTag>();
            MaintenancesGroups = new HashSet<MaintenancesGroup>();
            MaintenancesHosts = new HashSet<MaintenancesHost>();
            MaintenancesWindows = new HashSet<MaintenancesWindow>();
        }

        public ulong Maintenanceid { get; set; }
        public string Name { get; set; }
        public int MaintenanceType { get; set; }
        public string Description { get; set; }
        public int ActiveSince { get; set; }
        public int ActiveTill { get; set; }
        public int TagsEvaltype { get; set; }

        public virtual ICollection<EventSuppress> EventSuppresses { get; set; }
        public virtual ICollection<Host> Hosts { get; set; }
        public virtual ICollection<MaintenanceTag> MaintenanceTags { get; set; }
        public virtual ICollection<MaintenancesGroup> MaintenancesGroups { get; set; }
        public virtual ICollection<MaintenancesHost> MaintenancesHosts { get; set; }
        public virtual ICollection<MaintenancesWindow> MaintenancesWindows { get; set; }
    }
}
