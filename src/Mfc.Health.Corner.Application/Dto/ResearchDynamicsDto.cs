using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Dto
{
    public class ResearchDynamicsDto
    {
        public List<ResearchDynamicsDescriptionDto> DynamicResearch { get; set; }
        public List<ResearchDynamicsStatisticPointPerWeekDto> VisitsPerWeek { get; set; }
        public List<ResearchDynamicsStatisticPointPerWeekDto> CornerCountPerWeek { get; set; }
        public List<ResearchDynamicsStatisticPointPerWeekDto> AverageAttendancePerWeek { get; set; }
        public List<ResearchDynamicsStatisticPointPerWeekDto> SpecialistCallPerWeek { get; set; }

        public List<ResearchDynamicsStatisticPointPerWeekDto> SendEmiasToEmiasPerWeek { get; set; }
        public List<ResearchDynamicsStatisticPointPerWeekDto> DoctorsAppointmentPerWeek { get; set; }

    }
}
