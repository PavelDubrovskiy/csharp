using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Acknowledge
    {
        public Acknowledge()
        {
            Alerts = new HashSet<Alert>();
        }

        public ulong Acknowledgeid { get; set; }
        public ulong Userid { get; set; }
        public ulong Eventid { get; set; }
        public int Clock { get; set; }
        public string Message { get; set; }
        public int Action { get; set; }
        public int OldSeverity { get; set; }
        public int NewSeverity { get; set; }

        public virtual Event Event { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Alert> Alerts { get; set; }
    }
}
