using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class HttptestField
    {
        public ulong HttptestFieldid { get; set; }
        public ulong Httptestid { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public virtual Httptest Httptest { get; set; }
    }
}
