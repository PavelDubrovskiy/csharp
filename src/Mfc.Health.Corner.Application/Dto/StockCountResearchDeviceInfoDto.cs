using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Dto
{
    public class StockCountResearchDeviceInfoDto
    {
        public string Group { get; set; }
        public int Analyzer { get; set; }
        public int Bsm { get; set; }
        public int Gaz { get; set; }
        public int Pulse { get; set; }
        public int Bpbio { get; set; }
    }
}
