using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Operation
    {
        public Operation()
        {
            OpcommandGrps = new HashSet<OpcommandGrp>();
            OpcommandHsts = new HashSet<OpcommandHst>();
            Opconditions = new HashSet<Opcondition>();
            Opgroups = new HashSet<Opgroup>();
            OpmessageGrps = new HashSet<OpmessageGrp>();
            OpmessageUsrs = new HashSet<OpmessageUsr>();
            Optemplates = new HashSet<Optemplate>();
        }

        public ulong Operationid { get; set; }
        public ulong Actionid { get; set; }
        public int Operationtype { get; set; }
        public string EscPeriod { get; set; }
        public int EscStepFrom { get; set; }
        public int EscStepTo { get; set; }
        public int Evaltype { get; set; }
        public int Recovery { get; set; }

        public virtual Action Action { get; set; }
        public virtual Opcommand Opcommand { get; set; }
        public virtual Opinventory Opinventory { get; set; }
        public virtual Opmessage Opmessage { get; set; }
        public virtual ICollection<OpcommandGrp> OpcommandGrps { get; set; }
        public virtual ICollection<OpcommandHst> OpcommandHsts { get; set; }
        public virtual ICollection<Opcondition> Opconditions { get; set; }
        public virtual ICollection<Opgroup> Opgroups { get; set; }
        public virtual ICollection<OpmessageGrp> OpmessageGrps { get; set; }
        public virtual ICollection<OpmessageUsr> OpmessageUsrs { get; set; }
        public virtual ICollection<Optemplate> Optemplates { get; set; }
    }
}
