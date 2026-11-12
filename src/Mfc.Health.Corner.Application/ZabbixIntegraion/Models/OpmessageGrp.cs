using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class OpmessageGrp
    {
        public ulong OpmessageGrpid { get; set; }
        public ulong Operationid { get; set; }
        public ulong Usrgrpid { get; set; }

        public virtual Operation Operation { get; set; }
        public virtual Usrgrp Usrgrp { get; set; }
    }
}
