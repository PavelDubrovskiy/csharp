using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Httpstepitem
    {
        public ulong Httpstepitemid { get; set; }
        public ulong Httpstepid { get; set; }
        public ulong Itemid { get; set; }
        public int Type { get; set; }

        public virtual Httpstep Httpstep { get; set; }
        public virtual Item Item { get; set; }
    }
}
