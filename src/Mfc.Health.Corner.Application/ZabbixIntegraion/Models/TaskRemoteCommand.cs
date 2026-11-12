using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class TaskRemoteCommand
    {
        public ulong Taskid { get; set; }
        public int CommandType { get; set; }
        public int ExecuteOn { get; set; }
        public int Port { get; set; }
        public int Authtype { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Publickey { get; set; }
        public string Privatekey { get; set; }
        public string Command { get; set; }
        public ulong? Alertid { get; set; }
        public ulong ParentTaskid { get; set; }
        public ulong Hostid { get; set; }

        public virtual Task Task { get; set; }
    }
}
