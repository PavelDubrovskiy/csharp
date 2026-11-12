using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Dto
{
    public class ComplexDto
    {
        public MfcCornerDto MfcCorner { get; set; }
        public EquipmentConditionDto EquipmentCondition { get; set; }
        public long AllExaminationCount { get; set; }
        public long TodayExaminationCount { get; set; }

    }
}
