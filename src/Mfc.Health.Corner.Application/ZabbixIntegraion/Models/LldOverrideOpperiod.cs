using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class LldOverrideOpperiod
    {
        public ulong LldOverrideOperationid { get; set; }
        public string Delay { get; set; }

        public virtual LldOverrideOperation LldOverrideOperation { get; set; }
    }
}
