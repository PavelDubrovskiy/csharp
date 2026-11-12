using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Httptestitem
    {
        public ulong Httptestitemid { get; set; }
        public ulong Httptestid { get; set; }
        public ulong Itemid { get; set; }
        public int Type { get; set; }

        public virtual Httptest Httptest { get; set; }
        public virtual Item Item { get; set; }
    }
}
