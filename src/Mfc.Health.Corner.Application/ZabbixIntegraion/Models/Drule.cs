using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Drule
    {
        public Drule()
        {
            Dchecks = new HashSet<Dcheck>();
            Dhosts = new HashSet<Dhost>();
        }

        public ulong Druleid { get; set; }
        public ulong? ProxyHostid { get; set; }
        public string Name { get; set; }
        public string Iprange { get; set; }
        public string Delay { get; set; }
        public int Nextcheck { get; set; }
        public int Status { get; set; }

        public virtual Host ProxyHost { get; set; }
        public virtual ICollection<Dcheck> Dchecks { get; set; }
        public virtual ICollection<Dhost> Dhosts { get; set; }
    }
}
