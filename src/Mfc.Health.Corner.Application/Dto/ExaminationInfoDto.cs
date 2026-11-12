using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Dto
{
    public class ExaminationInfoDto
    {
        public string Id { get; set; }
        public string Date { get; set; }
        public string Phone { get; set; }
        public string Age { get; set; }
        public bool IsBpbioUsed { get; set; }
        public bool IsPulseUsed { get; set; }
        public bool IsAnalyzerUsed { get; set; }
        public bool IsBsmUsed { get; set; }
        public bool IsGazUsed { get; set; }
    }
}
