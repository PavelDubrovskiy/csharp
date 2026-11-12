using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class LldOverrideOptemplate
    {
        public ulong LldOverrideOptemplateid { get; set; }
        public ulong LldOverrideOperationid { get; set; }
        public ulong Templateid { get; set; }

        public virtual LldOverrideOperation LldOverrideOperation { get; set; }
        public virtual Host Template { get; set; }
    }
}
