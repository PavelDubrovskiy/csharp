using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class ScreenUsrgrp
    {
        public ulong Screenusrgrpid { get; set; }
        public ulong Screenid { get; set; }
        public ulong Usrgrpid { get; set; }
        public int Permission { get; set; }

        public virtual Screen Screen { get; set; }
        public virtual Usrgrp Usrgrp { get; set; }
    }
}
