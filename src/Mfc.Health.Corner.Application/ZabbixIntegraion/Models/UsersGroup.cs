using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class UsersGroup
    {
        public ulong Id { get; set; }
        public ulong Usrgrpid { get; set; }
        public ulong Userid { get; set; }

        public virtual User User { get; set; }
        public virtual Usrgrp Usrgrp { get; set; }
    }
}
