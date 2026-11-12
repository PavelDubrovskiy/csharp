using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Domain.Models
{
    public class EquipmentCondition
    {
        public bool Gaz { get; set; }
        public bool Bpbio { get; set; }
        public bool Pulse { get; set; }
        public bool Analyzer { get; set; }
        public bool Bsm { get; set; }
    }
}
