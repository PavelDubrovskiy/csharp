using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Application
    {
        public Application()
        {
            ApplicationDiscoveries = new HashSet<ApplicationDiscovery>();
            ApplicationTemplateApplications = new HashSet<ApplicationTemplate>();
            ApplicationTemplateTemplates = new HashSet<ApplicationTemplate>();
            Httptests = new HashSet<Httptest>();
            ItemsApplications = new HashSet<ItemsApplication>();
        }

        public ulong Applicationid { get; set; }
        public ulong Hostid { get; set; }
        public string Name { get; set; }
        public int Flags { get; set; }

        public virtual Host Host { get; set; }
        public virtual ICollection<ApplicationDiscovery> ApplicationDiscoveries { get; set; }
        public virtual ICollection<ApplicationTemplate> ApplicationTemplateApplications { get; set; }
        public virtual ICollection<ApplicationTemplate> ApplicationTemplateTemplates { get; set; }
        public virtual ICollection<Httptest> Httptests { get; set; }
        public virtual ICollection<ItemsApplication> ItemsApplications { get; set; }
    }
}
