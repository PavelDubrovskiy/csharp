using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class LldOverrideOpdiscover
    {
        public ulong LldOverrideOperationid { get; set; }
        public int Discover { get; set; }

        public virtual LldOverrideOperation LldOverrideOperation { get; set; }
    }
}
