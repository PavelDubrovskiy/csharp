using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Dto
{
    public class UpdateResearchDynamicsDto
    {
        public List<ResearchDynamicsDescriptionDto> DynamicResearch { get; set; }
        public ResearchDynamicsStatisticPointPerWeekDto VisitsPerWeek { get; set; }
        public ResearchDynamicsStatisticPointPerWeekDto CornerCountPerWeek { get; set; }
        public ResearchDynamicsStatisticPointPerWeekDto AverageAttendancePerWeek { get; set; }
        public ResearchDynamicsStatisticPointPerWeekDto SpecialistCallPerWeek { get; set; }
        public ResearchDynamicsStatisticPointPerWeekDto DoctorsApointmentPerWeek { get; set; }
        public ResearchDynamicsStatisticPointPerWeekDto SendEmiasPerWeek { get; set; }

    }
}
