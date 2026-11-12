using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class EventRecovery
    {
        public ulong Eventid { get; set; }
        public ulong REventid { get; set; }
        public ulong? CEventid { get; set; }
        public ulong? Correlationid { get; set; }
        public ulong? Userid { get; set; }

        public virtual Event CEvent { get; set; }
        public virtual Event Event { get; set; }
        public virtual Event REvent { get; set; }
    }
}
