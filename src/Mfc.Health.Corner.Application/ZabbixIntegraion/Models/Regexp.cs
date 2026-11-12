using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Regexp
    {
        public Regexp()
        {
            Expressions = new HashSet<Expression>();
        }

        public ulong Regexpid { get; set; }
        public string Name { get; set; }
        public string TestString { get; set; }

        public virtual ICollection<Expression> Expressions { get; set; }
    }
}
