using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class ScreenUser
    {
        public ulong Screenuserid { get; set; }
        public ulong Screenid { get; set; }
        public ulong Userid { get; set; }
        public int Permission { get; set; }

        public virtual Screen Screen { get; set; }
        public virtual User User { get; set; }
    }
}
