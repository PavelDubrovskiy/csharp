using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Slide
    {
        public ulong Slideid { get; set; }
        public ulong Slideshowid { get; set; }
        public ulong Screenid { get; set; }
        public int Step { get; set; }
        public string Delay { get; set; }

        public virtual Screen Screen { get; set; }
        public virtual Slideshow Slideshow { get; set; }
    }
}
