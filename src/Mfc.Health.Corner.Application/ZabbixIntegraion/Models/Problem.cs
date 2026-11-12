using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Problem
    {
        public Problem()
        {
            ProblemTags = new HashSet<ProblemTag>();
        }

        public ulong Eventid { get; set; }
        public int Source { get; set; }
        public int Object { get; set; }
        public ulong Objectid { get; set; }
        public int Clock { get; set; }
        public int Ns { get; set; }
        public ulong? REventid { get; set; }
        public int RClock { get; set; }
        public int RNs { get; set; }
        public ulong? Correlationid { get; set; }
        public ulong? Userid { get; set; }
        public string Name { get; set; }
        public int Acknowledged { get; set; }
        public int Severity { get; set; }

        public virtual Event Event { get; set; }
        public virtual Event REvent { get; set; }
        public virtual ICollection<ProblemTag> ProblemTags { get; set; }
    }
}
