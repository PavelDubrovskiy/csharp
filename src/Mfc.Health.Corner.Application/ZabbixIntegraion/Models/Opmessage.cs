using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Opmessage
    {
        public ulong Operationid { get; set; }
        public int DefaultMsg { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public ulong? Mediatypeid { get; set; }

        public virtual MediaType Mediatype { get; set; }
        public virtual Operation Operation { get; set; }
    }
}
