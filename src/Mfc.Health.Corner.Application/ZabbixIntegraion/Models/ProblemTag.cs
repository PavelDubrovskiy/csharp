using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class ProblemTag
    {
        public ulong Problemtagid { get; set; }
        public ulong Eventid { get; set; }
        public string Tag { get; set; }
        public string Value { get; set; }

        public virtual Problem Event { get; set; }
    }
}
