using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Medium
    {
        public ulong Mediaid { get; set; }
        public ulong Userid { get; set; }
        public ulong Mediatypeid { get; set; }
        public string Sendto { get; set; }
        public int Active { get; set; }
        public int Severity { get; set; }
        public string Period { get; set; }

        public virtual MediaType Mediatype { get; set; }
        public virtual User User { get; set; }
    }
}
