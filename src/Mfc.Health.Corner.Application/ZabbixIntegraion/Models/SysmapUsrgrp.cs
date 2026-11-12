using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class SysmapUsrgrp
    {
        public ulong Sysmapusrgrpid { get; set; }
        public ulong Sysmapid { get; set; }
        public ulong Usrgrpid { get; set; }
        public int Permission { get; set; }

        public virtual Sysmap Sysmap { get; set; }
        public virtual Usrgrp Usrgrp { get; set; }
    }
}
