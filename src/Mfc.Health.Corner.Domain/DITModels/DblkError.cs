using System;

namespace Mfc.Health.Corner.Domain.DITModels
{
    public partial class DblkError
    {
        public int Id { get; set; }
        public int Complex { get; set; }
        public bool Device { get; set; }
        public bool Bsm { get; set; }
        public bool Analyzer { get; set; }
        public bool Pulse { get; set; }
        public bool Bpbio { get; set; }
        public bool Gaz { get; set; }
        public string Status { get; set; }
        public DateTime Cdate { get; set; }
        public DateTime Fdate { get; set; }
    }
}
