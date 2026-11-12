using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class MediaTypeParam
    {
        public ulong MediatypeParamid { get; set; }
        public ulong Mediatypeid { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public virtual MediaType Mediatype { get; set; }
    }
}
