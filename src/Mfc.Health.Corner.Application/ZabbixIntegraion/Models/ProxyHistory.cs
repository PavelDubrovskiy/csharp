using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class ProxyHistory
    {
        public ulong Id { get; set; }
        public ulong Itemid { get; set; }
        public int Clock { get; set; }
        public int Timestamp { get; set; }
        public string Source { get; set; }
        public int Severity { get; set; }
        public string Value { get; set; }
        public int Logeventid { get; set; }
        public int Ns { get; set; }
        public int State { get; set; }
        public ulong Lastlogsize { get; set; }
        public int Mtime { get; set; }
        public int Flags { get; set; }
        public int WriteClock { get; set; }
    }
}
