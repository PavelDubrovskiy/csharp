using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Role
    {
        public Role()
        {
            RoleRules = new HashSet<RoleRule>();
            Users = new HashSet<User>();
        }

        public ulong Roleid { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public int Readonly { get; set; }

        public virtual ICollection<RoleRule> RoleRules { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
