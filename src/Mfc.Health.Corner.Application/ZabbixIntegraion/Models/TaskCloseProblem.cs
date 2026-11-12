using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class TaskCloseProblem
    {
        public ulong Taskid { get; set; }
        public ulong Acknowledgeid { get; set; }

        public virtual Task Task { get; set; }
    }
}
