using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class ItemRtdatum
    {
        public ulong Itemid { get; set; }
        public ulong Lastlogsize { get; set; }
        public int State { get; set; }
        public int Mtime { get; set; }
        public string Error { get; set; }

        public virtual Item Item { get; set; }
    }
}
