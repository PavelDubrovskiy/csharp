using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class HttpstepField
    {
        public ulong HttpstepFieldid { get; set; }
        public ulong Httpstepid { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public virtual Httpstep Httpstep { get; set; }
    }
}
