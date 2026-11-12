using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class CorrConditionTagvalue
    {
        public ulong CorrConditionid { get; set; }
        public string Tag { get; set; }
        public int Operator { get; set; }
        public string Value { get; set; }

        public virtual CorrCondition CorrCondition { get; set; }
    }
}
