using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class MediaTypeMessage
    {
        public ulong MediatypeMessageid { get; set; }
        public ulong Mediatypeid { get; set; }
        public int Eventsource { get; set; }
        public int Recovery { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

        public virtual MediaType Mediatype { get; set; }
    }
}
