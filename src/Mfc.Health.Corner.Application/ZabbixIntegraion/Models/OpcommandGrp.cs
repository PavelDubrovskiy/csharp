using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class OpcommandGrp
    {
        public ulong OpcommandGrpid { get; set; }
        public ulong Operationid { get; set; }
        public ulong Groupid { get; set; }

        public virtual Hstgrp Group { get; set; }
        public virtual Operation Operation { get; set; }
    }
}
