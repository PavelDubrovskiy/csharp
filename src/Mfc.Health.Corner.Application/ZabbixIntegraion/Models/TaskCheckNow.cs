using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class TaskCheckNow
    {
        public ulong Taskid { get; set; }
        public ulong Itemid { get; set; }

        public virtual Task Task { get; set; }
    }
}
