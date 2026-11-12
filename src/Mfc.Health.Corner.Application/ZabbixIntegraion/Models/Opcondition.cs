using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Opcondition
    {
        public ulong Opconditionid { get; set; }
        public ulong Operationid { get; set; }
        public int Conditiontype { get; set; }
        public int Operator { get; set; }
        public string Value { get; set; }

        public virtual Operation Operation { get; set; }
    }
}
