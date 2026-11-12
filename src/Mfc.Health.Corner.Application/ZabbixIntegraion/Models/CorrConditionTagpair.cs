using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class CorrConditionTagpair
    {
        public ulong CorrConditionid { get; set; }
        public string Oldtag { get; set; }
        public string Newtag { get; set; }

        public virtual CorrCondition CorrCondition { get; set; }
    }
}
