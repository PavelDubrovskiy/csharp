using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Profile
    {
        public ulong Profileid { get; set; }
        public ulong Userid { get; set; }
        public string Idx { get; set; }
        public ulong Idx2 { get; set; }
        public ulong ValueId { get; set; }
        public int ValueInt { get; set; }
        public string ValueStr { get; set; }
        public string Source { get; set; }
        public int Type { get; set; }

        public virtual User User { get; set; }
    }
}
