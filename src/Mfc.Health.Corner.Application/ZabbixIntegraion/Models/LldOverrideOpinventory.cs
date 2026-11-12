using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class LldOverrideOpinventory
    {
        public ulong LldOverrideOperationid { get; set; }
        public int InventoryMode { get; set; }

        public virtual LldOverrideOperation LldOverrideOperation { get; set; }
    }
}
