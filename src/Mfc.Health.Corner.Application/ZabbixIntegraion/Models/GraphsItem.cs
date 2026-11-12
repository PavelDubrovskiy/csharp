using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class GraphsItem
    {
        public ulong Gitemid { get; set; }
        public ulong Graphid { get; set; }
        public ulong Itemid { get; set; }
        public int Drawtype { get; set; }
        public int Sortorder { get; set; }
        public string Color { get; set; }
        public int Yaxisside { get; set; }
        public int CalcFnc { get; set; }
        public int Type { get; set; }

        public virtual Graph Graph { get; set; }
        public virtual Item Item { get; set; }
    }
}
