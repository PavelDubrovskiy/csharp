using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Dto
{
    public class MfcCormerExaminationDataCountsDto
    {
        public string MfcCormerName { get; set; }
        public long TotalExaminationCount { get; set; }
        public long Bsm { get; set; }
        public long Analyzer { get; set; }
        public long Bpbio { get; set; }
        public long Pulse { get; set; }
        public long Gaz { get; set; }
    }
}
