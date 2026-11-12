using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class ItemCondition
    {
        public ulong ItemConditionid { get; set; }
        public ulong Itemid { get; set; }
        public int Operator { get; set; }
        public string Macro { get; set; }
        public string Value { get; set; }

        public virtual Item Item { get; set; }
    }
}
