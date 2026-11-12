using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class SlideshowUser
    {
        public ulong Slideshowuserid { get; set; }
        public ulong Slideshowid { get; set; }
        public ulong Userid { get; set; }
        public int Permission { get; set; }

        public virtual Slideshow Slideshow { get; set; }
        public virtual User User { get; set; }
    }
}
