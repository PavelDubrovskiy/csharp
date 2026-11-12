using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Function
    {
        public ulong Functionid { get; set; }
        public ulong Itemid { get; set; }
        public ulong Triggerid { get; set; }
        public string Name { get; set; }
        public string Parameter { get; set; }

        public virtual Item Item { get; set; }
        public virtual Trigger Trigger { get; set; }
    }
}
