using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Id
    {
        public string TableName { get; set; }
        public string FieldName { get; set; }
        public ulong Nextid { get; set; }
    }
}
