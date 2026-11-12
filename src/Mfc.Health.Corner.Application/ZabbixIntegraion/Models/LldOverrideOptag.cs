using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class LldOverrideOptag
    {
        public ulong LldOverrideOptagid { get; set; }
        public ulong LldOverrideOperationid { get; set; }
        public string Tag { get; set; }
        public string Value { get; set; }

        public virtual LldOverrideOperation LldOverrideOperation { get; set; }
    }
}
