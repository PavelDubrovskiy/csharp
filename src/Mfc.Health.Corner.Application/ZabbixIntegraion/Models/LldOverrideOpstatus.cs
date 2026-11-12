using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class LldOverrideOpstatus
    {
        public ulong LldOverrideOperationid { get; set; }
        public int Status { get; set; }

        public virtual LldOverrideOperation LldOverrideOperation { get; set; }
    }
}
