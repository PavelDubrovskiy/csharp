using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Sysmap
    {
        public Sysmap()
        {
            SysmapShapes = new HashSet<SysmapShape>();
            SysmapUrls = new HashSet<SysmapUrl>();
            SysmapUsers = new HashSet<SysmapUser>();
            SysmapUsrgrps = new HashSet<SysmapUsrgrp>();
            SysmapsElements = new HashSet<SysmapsElement>();
            SysmapsLinks = new HashSet<SysmapsLink>();
            WidgetFields = new HashSet<WidgetField>();
        }

        public ulong Sysmapid { get; set; }
        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public ulong? Backgroundid { get; set; }
        public int LabelType { get; set; }
        public int LabelLocation { get; set; }
        public int Highlight { get; set; }
        public int Expandproblem { get; set; }
        public int Markelements { get; set; }
        public int ShowUnack { get; set; }
        public int GridSize { get; set; }
        public int GridShow { get; set; }
        public int GridAlign { get; set; }
        public int LabelFormat { get; set; }
        public int LabelTypeHost { get; set; }
        public int LabelTypeHostgroup { get; set; }
        public int LabelTypeTrigger { get; set; }
        public int LabelTypeMap { get; set; }
        public int LabelTypeImage { get; set; }
        public string LabelStringHost { get; set; }
        public string LabelStringHostgroup { get; set; }
        public string LabelStringTrigger { get; set; }
        public string LabelStringMap { get; set; }
        public string LabelStringImage { get; set; }
        public ulong? Iconmapid { get; set; }
        public int ExpandMacros { get; set; }
        public int SeverityMin { get; set; }
        public ulong Userid { get; set; }
        public int Private { get; set; }
        public int ShowSuppressed { get; set; }

        public virtual Image Background { get; set; }
        public virtual IconMap Iconmap { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<SysmapShape> SysmapShapes { get; set; }
        public virtual ICollection<SysmapUrl> SysmapUrls { get; set; }
        public virtual ICollection<SysmapUser> SysmapUsers { get; set; }
        public virtual ICollection<SysmapUsrgrp> SysmapUsrgrps { get; set; }
        public virtual ICollection<SysmapsElement> SysmapsElements { get; set; }
        public virtual ICollection<SysmapsLink> SysmapsLinks { get; set; }
        public virtual ICollection<WidgetField> WidgetFields { get; set; }
    }
}
