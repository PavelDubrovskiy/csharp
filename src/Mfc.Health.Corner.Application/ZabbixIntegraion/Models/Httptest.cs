using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Httptest
    {
        public Httptest()
        {
            Httpsteps = new HashSet<Httpstep>();
            HttptestFields = new HashSet<HttptestField>();
            Httptestitems = new HashSet<Httptestitem>();
            InverseTemplate = new HashSet<Httptest>();
        }

        public ulong Httptestid { get; set; }
        public string Name { get; set; }
        public ulong? Applicationid { get; set; }
        public int Nextcheck { get; set; }
        public string Delay { get; set; }
        public int Status { get; set; }
        public string Agent { get; set; }
        public int Authentication { get; set; }
        public string HttpUser { get; set; }
        public string HttpPassword { get; set; }
        public ulong Hostid { get; set; }
        public ulong? Templateid { get; set; }
        public string HttpProxy { get; set; }
        public int Retries { get; set; }
        public string SslCertFile { get; set; }
        public string SslKeyFile { get; set; }
        public string SslKeyPassword { get; set; }
        public int VerifyPeer { get; set; }
        public int VerifyHost { get; set; }

        public virtual Application Application { get; set; }
        public virtual Host Host { get; set; }
        public virtual Httptest Template { get; set; }
        public virtual ICollection<Httpstep> Httpsteps { get; set; }
        public virtual ICollection<HttptestField> HttptestFields { get; set; }
        public virtual ICollection<Httptestitem> Httptestitems { get; set; }
        public virtual ICollection<Httptest> InverseTemplate { get; set; }
    }
}
