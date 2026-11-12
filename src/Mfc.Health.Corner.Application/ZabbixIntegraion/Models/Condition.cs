using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Condition
    {
        public ulong Conditionid { get; set; }
        public ulong Actionid { get; set; }
        public int Conditiontype { get; set; }
        public int Operator { get; set; }
        public string Value { get; set; }
        public string Value2 { get; set; }

        public virtual Action Action { get; set; }
    }
}
