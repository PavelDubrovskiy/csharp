using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Opcommand
    {
        public ulong Operationid { get; set; }
        public int Type { get; set; }
        public ulong? Scriptid { get; set; }
        public int ExecuteOn { get; set; }
        public string Port { get; set; }
        public int Authtype { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Publickey { get; set; }
        public string Privatekey { get; set; }
        public string Command { get; set; }

        public virtual Operation Operation { get; set; }
        public virtual Script Script { get; set; }
    }
}
