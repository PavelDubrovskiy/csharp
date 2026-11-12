using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Screen
    {
        public Screen()
        {
            ScreenUsers = new HashSet<ScreenUser>();
            ScreenUsrgrps = new HashSet<ScreenUsrgrp>();
            ScreensItems = new HashSet<ScreensItem>();
            Slides = new HashSet<Slide>();
        }

        public ulong Screenid { get; set; }
        public string Name { get; set; }
        public int Hsize { get; set; }
        public int Vsize { get; set; }
        public ulong? Userid { get; set; }
        public int Private { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<ScreenUser> ScreenUsers { get; set; }
        public virtual ICollection<ScreenUsrgrp> ScreenUsrgrps { get; set; }
        public virtual ICollection<ScreensItem> ScreensItems { get; set; }
        public virtual ICollection<Slide> Slides { get; set; }
    }
}
