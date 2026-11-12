using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Escalation
    {
        public ulong Escalationid { get; set; }
        public ulong Actionid { get; set; }
        public ulong? Triggerid { get; set; }
        public ulong? Eventid { get; set; }
        public ulong? REventid { get; set; }
        public int Nextcheck { get; set; }
        public int EscStep { get; set; }
        public int Status { get; set; }
        public ulong? Itemid { get; set; }
        public ulong? Acknowledgeid { get; set; }
    }
}
