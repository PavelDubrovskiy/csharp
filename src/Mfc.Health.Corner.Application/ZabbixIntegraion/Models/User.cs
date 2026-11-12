using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class User
    {
        public User()
        {
            Acknowledges = new HashSet<Acknowledge>();
            Alerts = new HashSet<Alert>();
            Auditlogs = new HashSet<Auditlog>();
            DashboardUsers = new HashSet<DashboardUser>();
            Dashboards = new HashSet<Dashboard>();
            Media = new HashSet<Medium>();
            OpmessageUsrs = new HashSet<OpmessageUsr>();
            Profiles = new HashSet<Profile>();
            ScreenUsers = new HashSet<ScreenUser>();
            Screens = new HashSet<Screen>();
            Sessions = new HashSet<Session>();
            SlideshowUsers = new HashSet<SlideshowUser>();
            Slideshows = new HashSet<Slideshow>();
            SysmapUsers = new HashSet<SysmapUser>();
            Sysmaps = new HashSet<Sysmap>();
            UsersGroups = new HashSet<UsersGroup>();
        }

        public ulong Userid { get; set; }
        public string Alias { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Passwd { get; set; }
        public string Url { get; set; }
        public int Autologin { get; set; }
        public string Autologout { get; set; }
        public string Lang { get; set; }
        public string Refresh { get; set; }
        public string Theme { get; set; }
        public int AttemptFailed { get; set; }
        public string AttemptIp { get; set; }
        public int AttemptClock { get; set; }
        public int RowsPerPage { get; set; }
        public string Timezone { get; set; }
        public ulong Roleid { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Acknowledge> Acknowledges { get; set; }
        public virtual ICollection<Alert> Alerts { get; set; }
        public virtual ICollection<Auditlog> Auditlogs { get; set; }
        public virtual ICollection<DashboardUser> DashboardUsers { get; set; }
        public virtual ICollection<Dashboard> Dashboards { get; set; }
        public virtual ICollection<Medium> Media { get; set; }
        public virtual ICollection<OpmessageUsr> OpmessageUsrs { get; set; }
        public virtual ICollection<Profile> Profiles { get; set; }
        public virtual ICollection<ScreenUser> ScreenUsers { get; set; }
        public virtual ICollection<Screen> Screens { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
        public virtual ICollection<SlideshowUser> SlideshowUsers { get; set; }
        public virtual ICollection<Slideshow> Slideshows { get; set; }
        public virtual ICollection<SysmapUser> SysmapUsers { get; set; }
        public virtual ICollection<Sysmap> Sysmaps { get; set; }
        public virtual ICollection<UsersGroup> UsersGroups { get; set; }
    }
}
