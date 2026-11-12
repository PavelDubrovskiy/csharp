using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class CorrConditionGroup
    {
        public ulong CorrConditionid { get; set; }
        public int Operator { get; set; }
        public ulong Groupid { get; set; }

        public virtual CorrCondition CorrCondition { get; set; }
        public virtual Hstgrp Group { get; set; }
    }
}
