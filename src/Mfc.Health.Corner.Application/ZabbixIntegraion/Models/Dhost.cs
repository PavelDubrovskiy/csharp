using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Dhost
    {
        public Dhost()
        {
            Dservices = new HashSet<Dservice>();
        }

        public ulong Dhostid { get; set; }
        public ulong Druleid { get; set; }
        public int Status { get; set; }
        public int Lastup { get; set; }
        public int Lastdown { get; set; }

        public virtual Drule Drule { get; set; }
        public virtual ICollection<Dservice> Dservices { get; set; }
    }
}
