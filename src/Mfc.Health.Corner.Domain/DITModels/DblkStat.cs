using System;

namespace Mfc.Health.Corner.Domain.DITModels
{
    public partial class DblkStat
    {
        public int Id { get; set; }
        public int Complex { get; set; }
        public int Amount { get; set; }
        public int Bsm { get; set; }
        public int Analyzer { get; set; }
        public int Pulse { get; set; }
        public int Bpbio { get; set; }
        public int Gaz { get; set; }
        public int Oms { get; set; }
        public int Patient { get; set; }
        public DateTime Cdate { get; set; }
    }
}
