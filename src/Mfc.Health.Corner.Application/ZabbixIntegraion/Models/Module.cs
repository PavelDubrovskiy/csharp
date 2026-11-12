using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Module
    {
        public Module()
        {
            RoleRules = new HashSet<RoleRule>();
        }

        public ulong Moduleid { get; set; }
        public string Id { get; set; }
        public string RelativePath { get; set; }
        public int Status { get; set; }
        public string Config { get; set; }

        public virtual ICollection<RoleRule> RoleRules { get; set; }
    }
}
