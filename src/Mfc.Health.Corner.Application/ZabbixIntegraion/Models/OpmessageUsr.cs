using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class OpmessageUsr
    {
        public ulong OpmessageUsrid { get; set; }
        public ulong Operationid { get; set; }
        public ulong Userid { get; set; }

        public virtual Operation Operation { get; set; }
        public virtual User User { get; set; }
    }
}
