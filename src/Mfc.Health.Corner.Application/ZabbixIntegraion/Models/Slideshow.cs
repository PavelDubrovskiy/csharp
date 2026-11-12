using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Slideshow
    {
        public Slideshow()
        {
            Slides = new HashSet<Slide>();
            SlideshowUsers = new HashSet<SlideshowUser>();
            SlideshowUsrgrps = new HashSet<SlideshowUsrgrp>();
        }

        public ulong Slideshowid { get; set; }
        public string Name { get; set; }
        public string Delay { get; set; }
        public ulong Userid { get; set; }
        public int Private { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Slide> Slides { get; set; }
        public virtual ICollection<SlideshowUser> SlideshowUsers { get; set; }
        public virtual ICollection<SlideshowUsrgrp> SlideshowUsrgrps { get; set; }
    }
}
