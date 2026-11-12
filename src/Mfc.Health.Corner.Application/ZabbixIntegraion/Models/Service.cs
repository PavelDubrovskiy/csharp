using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Service
    {
        public Service()
        {
            ServiceAlarms = new HashSet<ServiceAlarm>();
            ServicesLinkServicedowns = new HashSet<ServicesLink>();
            ServicesLinkServiceups = new HashSet<ServicesLink>();
            ServicesTimes = new HashSet<ServicesTime>();
        }

        public ulong Serviceid { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public int Algorithm { get; set; }
        public ulong? Triggerid { get; set; }
        public int Showsla { get; set; }
        public double Goodsla { get; set; }
        public int Sortorder { get; set; }

        public virtual Trigger Trigger { get; set; }
        public virtual ICollection<ServiceAlarm> ServiceAlarms { get; set; }
        public virtual ICollection<ServicesLink> ServicesLinkServicedowns { get; set; }
        public virtual ICollection<ServicesLink> ServicesLinkServiceups { get; set; }
        public virtual ICollection<ServicesTime> ServicesTimes { get; set; }
    }
}
