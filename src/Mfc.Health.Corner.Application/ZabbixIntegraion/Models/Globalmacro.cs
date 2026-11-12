using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Globalmacro
    {
        public ulong Globalmacroid { get; set; }
        public string Macro { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
    }
}
