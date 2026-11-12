using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class ItemPreproc
    {
        public ulong ItemPreprocid { get; set; }
        public ulong Itemid { get; set; }
        public int Step { get; set; }
        public int Type { get; set; }
        public string Params { get; set; }
        public int ErrorHandler { get; set; }
        public string ErrorHandlerParams { get; set; }

        public virtual Item Item { get; set; }
    }
}
