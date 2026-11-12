using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Optemplate
    {
        public ulong Optemplateid { get; set; }
        public ulong Operationid { get; set; }
        public ulong Templateid { get; set; }

        public virtual Operation Operation { get; set; }
        public virtual Host Template { get; set; }
    }
}
