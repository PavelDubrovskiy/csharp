using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Mapping
    {
        public ulong Mappingid { get; set; }
        public ulong Valuemapid { get; set; }
        public string Value { get; set; }
        public string Newvalue { get; set; }

        public virtual Valuemap Valuemap { get; set; }
    }
}
