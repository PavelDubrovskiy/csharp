using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class SlideshowUsrgrp
    {
        public ulong Slideshowusrgrpid { get; set; }
        public ulong Slideshowid { get; set; }
        public ulong Usrgrpid { get; set; }
        public int Permission { get; set; }

        public virtual Slideshow Slideshow { get; set; }
        public virtual Usrgrp Usrgrp { get; set; }
    }
}
