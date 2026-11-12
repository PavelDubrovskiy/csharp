using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Housekeeper
    {
        public ulong Housekeeperid { get; set; }
        public string Tablename { get; set; }
        public string Field { get; set; }
        public ulong Value { get; set; }
    }
}
