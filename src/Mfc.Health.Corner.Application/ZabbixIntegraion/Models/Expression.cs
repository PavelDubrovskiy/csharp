using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Expression
    {
        public ulong Expressionid { get; set; }
        public ulong Regexpid { get; set; }
        public string Expression1 { get; set; }
        public int ExpressionType { get; set; }
        public string ExpDelimiter { get; set; }
        public int CaseSensitive { get; set; }

        public virtual Regexp Regexp { get; set; }
    }
}
