using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class ItemParameter
    {
        public ulong ItemParameterid { get; set; }
        public ulong Itemid { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public virtual Item Item { get; set; }
    }
}
