using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class LldOverrideOphistory
    {
        public ulong LldOverrideOperationid { get; set; }
        public string History { get; set; }

        public virtual LldOverrideOperation LldOverrideOperation { get; set; }
    }
}
