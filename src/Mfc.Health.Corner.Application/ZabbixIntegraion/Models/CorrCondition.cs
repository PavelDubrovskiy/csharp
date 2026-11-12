using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class CorrCondition
    {
        public ulong CorrConditionid { get; set; }
        public ulong Correlationid { get; set; }
        public int Type { get; set; }

        public virtual Correlation Correlation { get; set; }
        public virtual CorrConditionGroup CorrConditionGroup { get; set; }
        public virtual CorrConditionTag CorrConditionTag { get; set; }
        public virtual CorrConditionTagpair CorrConditionTagpair { get; set; }
        public virtual CorrConditionTagvalue CorrConditionTagvalue { get; set; }
    }
}
