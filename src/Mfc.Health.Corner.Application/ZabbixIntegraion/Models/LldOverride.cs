using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class LldOverride
    {
        public LldOverride()
        {
            LldOverrideConditions = new HashSet<LldOverrideCondition>();
            LldOverrideOperations = new HashSet<LldOverrideOperation>();
        }

        public ulong LldOverrideid { get; set; }
        public ulong Itemid { get; set; }
        public string Name { get; set; }
        public int Step { get; set; }
        public int Evaltype { get; set; }
        public string Formula { get; set; }
        public int Stop { get; set; }

        public virtual Item Item { get; set; }
        public virtual ICollection<LldOverrideCondition> LldOverrideConditions { get; set; }
        public virtual ICollection<LldOverrideOperation> LldOverrideOperations { get; set; }
    }
}
