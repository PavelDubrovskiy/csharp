using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class EventSuppress
    {
        public ulong EventSuppressid { get; set; }
        public ulong Eventid { get; set; }
        public ulong? Maintenanceid { get; set; }
        public int SuppressUntil { get; set; }

        public virtual Event Event { get; set; }
        public virtual Maintenance Maintenance { get; set; }
    }
}
