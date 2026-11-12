using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class TriggerDepend
    {
        public ulong Triggerdepid { get; set; }
        public ulong TriggeridDown { get; set; }
        public ulong TriggeridUp { get; set; }

        public virtual Trigger TriggeridDownNavigation { get; set; }
        public virtual Trigger TriggeridUpNavigation { get; set; }
    }
}
