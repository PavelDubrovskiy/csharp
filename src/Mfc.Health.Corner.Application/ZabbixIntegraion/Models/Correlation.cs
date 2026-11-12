using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Correlation
    {
        public Correlation()
        {
            CorrConditions = new HashSet<CorrCondition>();
            CorrOperations = new HashSet<CorrOperation>();
        }

        public ulong Correlationid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Evaltype { get; set; }
        public int Status { get; set; }
        public string Formula { get; set; }

        public virtual ICollection<CorrCondition> CorrConditions { get; set; }
        public virtual ICollection<CorrOperation> CorrOperations { get; set; }
    }
}
