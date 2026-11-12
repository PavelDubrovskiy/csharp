using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class TaskDatum
    {
        public ulong Taskid { get; set; }
        public int Type { get; set; }
        public string Data { get; set; }
        public ulong ParentTaskid { get; set; }

        public virtual Task Task { get; set; }
    }
}
