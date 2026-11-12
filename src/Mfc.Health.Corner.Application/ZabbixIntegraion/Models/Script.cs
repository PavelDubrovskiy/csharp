using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Script
    {
        public Script()
        {
            Opcommands = new HashSet<Opcommand>();
        }

        public ulong Scriptid { get; set; }
        public string Name { get; set; }
        public string Command { get; set; }
        public int HostAccess { get; set; }
        public ulong? Usrgrpid { get; set; }
        public ulong? Groupid { get; set; }
        public string Description { get; set; }
        public string Confirmation { get; set; }
        public int Type { get; set; }
        public int ExecuteOn { get; set; }

        public virtual Hstgrp Group { get; set; }
        public virtual Usrgrp Usrgrp { get; set; }
        public virtual ICollection<Opcommand> Opcommands { get; set; }
    }
}
