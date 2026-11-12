using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Dto
{
    public class LastExaminationAnalyzerBsmDto
    {
        public string idClient { get; set; }
        public string nameComplex { get; set; }
        public string AGE { get; set; }
        public string GENDER { get; set; }
        public double HT { get; set; }
        public double WT { get; set; }
        public string BMI { get; set; }
        public double BMR { get; set; }
    }
}
