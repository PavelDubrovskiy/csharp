using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class TaskRemoteCommandResult
    {
        public ulong Taskid { get; set; }
        public int Status { get; set; }
        public ulong ParentTaskid { get; set; }
        public string Info { get; set; }

        public virtual Task Task { get; set; }
    }
}
