using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class LldOverrideCondition
    {
        public ulong LldOverrideConditionid { get; set; }
        public ulong LldOverrideid { get; set; }
        public int Operator { get; set; }
        public string Macro { get; set; }
        public string Value { get; set; }

        public virtual LldOverride LldOverride { get; set; }
    }
}
