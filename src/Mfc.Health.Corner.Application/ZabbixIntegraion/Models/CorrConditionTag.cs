using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class CorrConditionTag
    {
        public ulong CorrConditionid { get; set; }
        public string Tag { get; set; }

        public virtual CorrCondition CorrCondition { get; set; }
    }
}
