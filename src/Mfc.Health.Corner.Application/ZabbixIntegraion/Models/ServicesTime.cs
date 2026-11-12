using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class ServicesTime
    {
        public ulong Timeid { get; set; }
        public ulong Serviceid { get; set; }
        public int Type { get; set; }
        public int TsFrom { get; set; }
        public int TsTo { get; set; }
        public string Note { get; set; }

        public virtual Service Service { get; set; }
    }
}
