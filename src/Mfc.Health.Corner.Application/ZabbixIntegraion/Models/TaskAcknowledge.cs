using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class TaskAcknowledge
    {
        public ulong Taskid { get; set; }
        public ulong Acknowledgeid { get; set; }

        public virtual Task Task { get; set; }
    }
}
