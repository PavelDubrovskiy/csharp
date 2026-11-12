using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Right
    {
        public ulong Rightid { get; set; }
        public ulong Groupid { get; set; }
        public int Permission { get; set; }
        public ulong Id { get; set; }

        public virtual Usrgrp Group { get; set; }
        public virtual Hstgrp IdNavigation { get; set; }
    }
}
