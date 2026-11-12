using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class MediaType
    {
        public MediaType()
        {
            Alerts = new HashSet<Alert>();
            Media = new HashSet<Medium>();
            MediaTypeMessages = new HashSet<MediaTypeMessage>();
            MediaTypeParams = new HashSet<MediaTypeParam>();
            Opmessages = new HashSet<Opmessage>();
        }

        public ulong Mediatypeid { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public string SmtpServer { get; set; }
        public string SmtpHelo { get; set; }
        public string SmtpEmail { get; set; }
        public string ExecPath { get; set; }
        public string GsmModem { get; set; }
        public string Username { get; set; }
        public string Passwd { get; set; }
        public int Status { get; set; }
        public int SmtpPort { get; set; }
        public int SmtpSecurity { get; set; }
        public int SmtpVerifyPeer { get; set; }
        public int SmtpVerifyHost { get; set; }
        public int SmtpAuthentication { get; set; }
        public string ExecParams { get; set; }
        public int Maxsessions { get; set; }
        public int Maxattempts { get; set; }
        public string AttemptInterval { get; set; }
        public int ContentType { get; set; }
        public string Script { get; set; }
        public string Timeout { get; set; }
        public int ProcessTags { get; set; }
        public int ShowEventMenu { get; set; }
        public string EventMenuUrl { get; set; }
        public string EventMenuName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Alert> Alerts { get; set; }
        public virtual ICollection<Medium> Media { get; set; }
        public virtual ICollection<MediaTypeMessage> MediaTypeMessages { get; set; }
        public virtual ICollection<MediaTypeParam> MediaTypeParams { get; set; }
        public virtual ICollection<Opmessage> Opmessages { get; set; }
    }
}
