using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Session
    {
        public string Sessionid { get; set; }
        public ulong Userid { get; set; }
        public int Lastaccess { get; set; }
        public int Status { get; set; }

        public virtual User User { get; set; }
    }
}
