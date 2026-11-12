using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Dto
{
    public class PatientInfoDto
    {
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public bool UseGaz { get; set; }
        public bool UseBPBIO { get; set; }
        public bool UsePulse { get; set; }
        public bool UseAnalizer { get; set; }
        public bool UseBSM { get; set; }
    }
}
