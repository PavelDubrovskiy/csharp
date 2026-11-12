using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class LldOverrideOptrend
    {
        public ulong LldOverrideOperationid { get; set; }
        public string Trends { get; set; }

        public virtual LldOverrideOperation LldOverrideOperation { get; set; }
    }
}
