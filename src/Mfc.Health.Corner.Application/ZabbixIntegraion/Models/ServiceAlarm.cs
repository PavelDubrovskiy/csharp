using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class ServiceAlarm
    {
        public ulong Servicealarmid { get; set; }
        public ulong Serviceid { get; set; }
        public int Clock { get; set; }
        public int Value { get; set; }

        public virtual Service Service { get; set; }
    }
}
