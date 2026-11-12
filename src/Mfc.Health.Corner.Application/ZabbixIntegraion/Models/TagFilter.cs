using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class TagFilter
    {
        public ulong TagFilterid { get; set; }
        public ulong Usrgrpid { get; set; }
        public ulong Groupid { get; set; }
        public string Tag { get; set; }
        public string Value { get; set; }

        public virtual Hstgrp Group { get; set; }
        public virtual Usrgrp Usrgrp { get; set; }
    }
}
