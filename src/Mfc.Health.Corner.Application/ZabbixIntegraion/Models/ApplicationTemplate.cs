using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class ApplicationTemplate
    {
        public ulong ApplicationTemplateid { get; set; }
        public ulong Applicationid { get; set; }
        public ulong Templateid { get; set; }

        public virtual Application Application { get; set; }
        public virtual Application Template { get; set; }
    }
}
