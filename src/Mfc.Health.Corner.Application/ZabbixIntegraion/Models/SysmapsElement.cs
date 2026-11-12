using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class SysmapsElement
    {
        public SysmapsElement()
        {
            SysmapElementTriggers = new HashSet<SysmapElementTrigger>();
            SysmapElementUrls = new HashSet<SysmapElementUrl>();
            SysmapsLinkSelementid1Navigations = new HashSet<SysmapsLink>();
            SysmapsLinkSelementid2Navigations = new HashSet<SysmapsLink>();
        }

        public ulong Selementid { get; set; }
        public ulong Sysmapid { get; set; }
        public ulong Elementid { get; set; }
        public int Elementtype { get; set; }
        public ulong? IconidOff { get; set; }
        public ulong? IconidOn { get; set; }
        public string Label { get; set; }
        public int LabelLocation { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public ulong? IconidDisabled { get; set; }
        public ulong? IconidMaintenance { get; set; }
        public int Elementsubtype { get; set; }
        public int Areatype { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Viewtype { get; set; }
        public int UseIconmap { get; set; }
        public string Application { get; set; }

        public virtual Image IconidDisabledNavigation { get; set; }
        public virtual Image IconidMaintenanceNavigation { get; set; }
        public virtual Image IconidOffNavigation { get; set; }
        public virtual Image IconidOnNavigation { get; set; }
        public virtual Sysmap Sysmap { get; set; }
        public virtual ICollection<SysmapElementTrigger> SysmapElementTriggers { get; set; }
        public virtual ICollection<SysmapElementUrl> SysmapElementUrls { get; set; }
        public virtual ICollection<SysmapsLink> SysmapsLinkSelementid1Navigations { get; set; }
        public virtual ICollection<SysmapsLink> SysmapsLinkSelementid2Navigations { get; set; }
    }
}
