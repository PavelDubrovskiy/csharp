using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class OpcommandHst
    {
        public ulong OpcommandHstid { get; set; }
        public ulong Operationid { get; set; }
        public ulong? Hostid { get; set; }

        public virtual Host Host { get; set; }
        public virtual Operation Operation { get; set; }
    }
}
