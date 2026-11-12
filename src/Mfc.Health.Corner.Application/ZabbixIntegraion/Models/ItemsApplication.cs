using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class ItemsApplication
    {
        public ulong Itemappid { get; set; }
        public ulong Applicationid { get; set; }
        public ulong Itemid { get; set; }

        public virtual Application Application { get; set; }
        public virtual Item Item { get; set; }
    }
}
