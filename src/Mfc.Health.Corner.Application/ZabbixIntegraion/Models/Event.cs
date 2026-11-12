using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Event
    {
        public Event()
        {
            Acknowledges = new HashSet<Acknowledge>();
            AlertEvents = new HashSet<Alert>();
            AlertPEvents = new HashSet<Alert>();
            EventRecoveryCEvents = new HashSet<EventRecovery>();
            EventRecoveryREvents = new HashSet<EventRecovery>();
            EventSuppresses = new HashSet<EventSuppress>();
            EventTags = new HashSet<EventTag>();
            ProblemREvents = new HashSet<Problem>();
        }

        public ulong Eventid { get; set; }
        public int Source { get; set; }
        public int Object { get; set; }
        public ulong Objectid { get; set; }
        public int Clock { get; set; }
        public int Value { get; set; }
        public int Acknowledged { get; set; }
        public int Ns { get; set; }
        public string Name { get; set; }
        public int Severity { get; set; }

        public virtual EventRecovery EventRecoveryEvent { get; set; }
        public virtual Problem ProblemEvent { get; set; }
        public virtual ICollection<Acknowledge> Acknowledges { get; set; }
        public virtual ICollection<Alert> AlertEvents { get; set; }
        public virtual ICollection<Alert> AlertPEvents { get; set; }
        public virtual ICollection<EventRecovery> EventRecoveryCEvents { get; set; }
        public virtual ICollection<EventRecovery> EventRecoveryREvents { get; set; }
        public virtual ICollection<EventSuppress> EventSuppresses { get; set; }
        public virtual ICollection<EventTag> EventTags { get; set; }
        public virtual ICollection<Problem> ProblemREvents { get; set; }
    }
}
