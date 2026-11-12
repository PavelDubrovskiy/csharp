using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class GroupDiscovery
    {
        public ulong Groupid { get; set; }
        public ulong ParentGroupPrototypeid { get; set; }
        public string Name { get; set; }
        public int Lastcheck { get; set; }
        public int TsDelete { get; set; }

        public virtual Hstgrp Group { get; set; }
        public virtual GroupPrototype ParentGroupPrototype { get; set; }
    }
}
