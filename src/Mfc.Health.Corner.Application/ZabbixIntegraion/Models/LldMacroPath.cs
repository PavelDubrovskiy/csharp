using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class LldMacroPath
    {
        public ulong LldMacroPathid { get; set; }
        public ulong Itemid { get; set; }
        public string LldMacro { get; set; }
        public string Path { get; set; }

        public virtual Item Item { get; set; }
    }
}
