using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Hostmacro
    {
        public ulong Hostmacroid { get; set; }
        public ulong Hostid { get; set; }
        public string Macro { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }

        public virtual Host Host { get; set; }
    }
}
