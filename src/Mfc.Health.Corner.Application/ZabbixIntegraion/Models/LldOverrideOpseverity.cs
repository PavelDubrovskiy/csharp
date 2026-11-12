using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class LldOverrideOpseverity
    {
        public ulong LldOverrideOperationid { get; set; }
        public int Severity { get; set; }

        public virtual LldOverrideOperation LldOverrideOperation { get; set; }
    }
}
