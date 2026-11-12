using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class RoleRule
    {
        public ulong RoleRuleid { get; set; }
        public ulong Roleid { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public int ValueInt { get; set; }
        public string ValueStr { get; set; }
        public ulong? ValueModuleid { get; set; }

        public virtual Role Role { get; set; }
        public virtual Module ValueModule { get; set; }
    }
}
