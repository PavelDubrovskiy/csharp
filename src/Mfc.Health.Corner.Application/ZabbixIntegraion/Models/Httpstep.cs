using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Httpstep
    {
        public Httpstep()
        {
            HttpstepFields = new HashSet<HttpstepField>();
            Httpstepitems = new HashSet<Httpstepitem>();
        }

        public ulong Httpstepid { get; set; }
        public ulong Httptestid { get; set; }
        public string Name { get; set; }
        public int No { get; set; }
        public string Url { get; set; }
        public string Timeout { get; set; }
        public string Posts { get; set; }
        public string Required { get; set; }
        public string StatusCodes { get; set; }
        public int FollowRedirects { get; set; }
        public int RetrieveMode { get; set; }
        public int PostType { get; set; }

        public virtual Httptest Httptest { get; set; }
        public virtual ICollection<HttpstepField> HttpstepFields { get; set; }
        public virtual ICollection<Httpstepitem> Httpstepitems { get; set; }
    }
}
