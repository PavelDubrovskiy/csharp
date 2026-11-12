using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Usrgrp
    {
        public Usrgrp()
        {
            Configs = new HashSet<Config>();
            DashboardUsrgrps = new HashSet<DashboardUsrgrp>();
            OpmessageGrps = new HashSet<OpmessageGrp>();
            Rights = new HashSet<Right>();
            ScreenUsrgrps = new HashSet<ScreenUsrgrp>();
            Scripts = new HashSet<Script>();
            SlideshowUsrgrps = new HashSet<SlideshowUsrgrp>();
            SysmapUsrgrps = new HashSet<SysmapUsrgrp>();
            TagFilters = new HashSet<TagFilter>();
            UsersGroups = new HashSet<UsersGroup>();
        }

        public ulong Usrgrpid { get; set; }
        public string Name { get; set; }
        public int GuiAccess { get; set; }
        public int UsersStatus { get; set; }
        public int DebugMode { get; set; }

        public virtual ICollection<Config> Configs { get; set; }
        public virtual ICollection<DashboardUsrgrp> DashboardUsrgrps { get; set; }
        public virtual ICollection<OpmessageGrp> OpmessageGrps { get; set; }
        public virtual ICollection<Right> Rights { get; set; }
        public virtual ICollection<ScreenUsrgrp> ScreenUsrgrps { get; set; }
        public virtual ICollection<Script> Scripts { get; set; }
        public virtual ICollection<SlideshowUsrgrp> SlideshowUsrgrps { get; set; }
        public virtual ICollection<SysmapUsrgrp> SysmapUsrgrps { get; set; }
        public virtual ICollection<TagFilter> TagFilters { get; set; }
        public virtual ICollection<UsersGroup> UsersGroups { get; set; }
    }
}
