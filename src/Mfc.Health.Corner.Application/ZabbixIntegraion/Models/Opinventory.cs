using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Opinventory
    {
        public ulong Operationid { get; set; }
        public int InventoryMode { get; set; }

        public virtual Operation Operation { get; set; }
    }
}
