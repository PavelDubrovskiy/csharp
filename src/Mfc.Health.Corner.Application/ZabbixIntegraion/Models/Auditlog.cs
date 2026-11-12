using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Auditlog
    {
        public Auditlog()
        {
            AuditlogDetails = new HashSet<AuditlogDetail>();
        }

        public ulong Auditid { get; set; }
        public ulong Userid { get; set; }
        public int Clock { get; set; }
        public int Action { get; set; }
        public int Resourcetype { get; set; }
        public string Note { get; set; }
        public string Ip { get; set; }
        public ulong? Resourceid { get; set; }
        public string Resourcename { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<AuditlogDetail> AuditlogDetails { get; set; }
    }
}
