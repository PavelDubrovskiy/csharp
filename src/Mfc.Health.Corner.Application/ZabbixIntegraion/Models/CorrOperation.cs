using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class CorrOperation
    {
        public ulong CorrOperationid { get; set; }
        public ulong Correlationid { get; set; }
        public int Type { get; set; }

        public virtual Correlation Correlation { get; set; }
    }
}
