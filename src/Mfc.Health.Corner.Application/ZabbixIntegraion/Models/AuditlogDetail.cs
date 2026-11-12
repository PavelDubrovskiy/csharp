using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class AuditlogDetail
    {
        public ulong Auditdetailid { get; set; }
        public ulong Auditid { get; set; }
        public string TableName { get; set; }
        public string FieldName { get; set; }
        public string Oldvalue { get; set; }
        public string Newvalue { get; set; }

        public virtual Auditlog Audit { get; set; }
    }
}
