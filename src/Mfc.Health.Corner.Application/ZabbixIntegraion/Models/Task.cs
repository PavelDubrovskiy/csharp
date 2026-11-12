using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Task
    {
        public ulong Taskid { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }
        public int Clock { get; set; }
        public int Ttl { get; set; }
        public ulong? ProxyHostid { get; set; }

        public virtual Host ProxyHost { get; set; }
        public virtual TaskAcknowledge TaskAcknowledge { get; set; }
        public virtual TaskCheckNow TaskCheckNow { get; set; }
        public virtual TaskCloseProblem TaskCloseProblem { get; set; }
        public virtual TaskDatum TaskDatum { get; set; }
        public virtual TaskRemoteCommand TaskRemoteCommand { get; set; }
        public virtual TaskRemoteCommandResult TaskRemoteCommandResult { get; set; }
        public virtual TaskResult TaskResult { get; set; }
    }
}
