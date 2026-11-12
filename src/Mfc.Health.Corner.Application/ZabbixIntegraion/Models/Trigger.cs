using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Trigger
    {
        public Trigger()
        {
            Functions = new HashSet<Function>();
            InverseTemplate = new HashSet<Trigger>();
            Services = new HashSet<Service>();
            SysmapElementTriggers = new HashSet<SysmapElementTrigger>();
            SysmapsLinkTriggers = new HashSet<SysmapsLinkTrigger>();
            TriggerDependTriggeridDownNavigations = new HashSet<TriggerDepend>();
            TriggerDependTriggeridUpNavigations = new HashSet<TriggerDepend>();
            TriggerDiscoveryParentTriggers = new HashSet<TriggerDiscovery>();
            TriggerTags = new HashSet<TriggerTag>();
        }

        public ulong Triggerid { get; set; }
        public string Expression { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public int Status { get; set; }
        public int Value { get; set; }
        public int Priority { get; set; }
        public int Lastchange { get; set; }
        public string Comments { get; set; }
        public string Error { get; set; }
        public ulong? Templateid { get; set; }
        public int Type { get; set; }
        public int State { get; set; }
        public int Flags { get; set; }
        public int RecoveryMode { get; set; }
        public string RecoveryExpression { get; set; }
        public int CorrelationMode { get; set; }
        public string CorrelationTag { get; set; }
        public int ManualClose { get; set; }
        public string Opdata { get; set; }
        public int Discover { get; set; }
        public string EventName { get; set; }

        public virtual Trigger Template { get; set; }
        public virtual TriggerDiscovery TriggerDiscoveryTrigger { get; set; }
        public virtual ICollection<Function> Functions { get; set; }
        public virtual ICollection<Trigger> InverseTemplate { get; set; }
        public virtual ICollection<Service> Services { get; set; }
        public virtual ICollection<SysmapElementTrigger> SysmapElementTriggers { get; set; }
        public virtual ICollection<SysmapsLinkTrigger> SysmapsLinkTriggers { get; set; }
        public virtual ICollection<TriggerDepend> TriggerDependTriggeridDownNavigations { get; set; }
        public virtual ICollection<TriggerDepend> TriggerDependTriggeridUpNavigations { get; set; }
        public virtual ICollection<TriggerDiscovery> TriggerDiscoveryParentTriggers { get; set; }
        public virtual ICollection<TriggerTag> TriggerTags { get; set; }
    }
}
