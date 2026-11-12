using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class HistoryLog
    {
        public ulong Itemid { get; set; }
        public int Clock { get; set; }
        public int Timestamp { get; set; }
        public string Source { get; set; }
        public int Severity { get; set; }
        public string Value { get; set; }
        public int Logeventid { get; set; }
        public int Ns { get; set; }
    }
}
