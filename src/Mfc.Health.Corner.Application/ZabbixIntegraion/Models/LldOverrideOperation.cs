using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class LldOverrideOperation
    {
        public LldOverrideOperation()
        {
            LldOverrideOptags = new HashSet<LldOverrideOptag>();
            LldOverrideOptemplates = new HashSet<LldOverrideOptemplate>();
        }

        public ulong LldOverrideOperationid { get; set; }
        public ulong LldOverrideid { get; set; }
        public int Operationobject { get; set; }
        public int Operator { get; set; }
        public string Value { get; set; }

        public virtual LldOverride LldOverride { get; set; }
        public virtual LldOverrideOpdiscover LldOverrideOpdiscover { get; set; }
        public virtual LldOverrideOphistory LldOverrideOphistory { get; set; }
        public virtual LldOverrideOpinventory LldOverrideOpinventory { get; set; }
        public virtual LldOverrideOpperiod LldOverrideOpperiod { get; set; }
        public virtual LldOverrideOpseverity LldOverrideOpseverity { get; set; }
        public virtual LldOverrideOpstatus LldOverrideOpstatus { get; set; }
        public virtual LldOverrideOptrend LldOverrideOptrend { get; set; }
        public virtual ICollection<LldOverrideOptag> LldOverrideOptags { get; set; }
        public virtual ICollection<LldOverrideOptemplate> LldOverrideOptemplates { get; set; }
    }
}
