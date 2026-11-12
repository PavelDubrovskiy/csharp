using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Action
    {
        public Action()
        {
            Alerts = new HashSet<Alert>();
            Conditions = new HashSet<Condition>();
            Operations = new HashSet<Operation>();
        }

        public ulong Actionid { get; set; }
        public string Name { get; set; }
        public int Eventsource { get; set; }
        public int Evaltype { get; set; }
        public int Status { get; set; }
        public string EscPeriod { get; set; }
        public string Formula { get; set; }
        public int PauseSuppressed { get; set; }

        public virtual ICollection<Alert> Alerts { get; set; }
        public virtual ICollection<Condition> Conditions { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
    }
}
