using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Alert
    {
        public ulong Alertid { get; set; }
        public ulong Actionid { get; set; }
        public ulong Eventid { get; set; }
        public ulong? Userid { get; set; }
        public int Clock { get; set; }
        public ulong? Mediatypeid { get; set; }
        public string Sendto { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
        public int Retries { get; set; }
        public string Error { get; set; }
        public int EscStep { get; set; }
        public int Alerttype { get; set; }
        public ulong? PEventid { get; set; }
        public ulong? Acknowledgeid { get; set; }
        public string Parameters { get; set; }

        public virtual Acknowledge Acknowledge { get; set; }
        public virtual Action Action { get; set; }
        public virtual Event Event { get; set; }
        public virtual MediaType Mediatype { get; set; }
        public virtual Event PEvent { get; set; }
        public virtual User User { get; set; }
    }
}
