using System.Collections.Generic;

namespace Mfc.Health.Corner.Application.Dto
{
    public class CreateMedicalExaminationDto
    {
        public string PhoneNumber { get; set; }
        public string Age { get; set; }
        public bool Male { get; set; }
        public List<string> TestNames { get; set; }
    }
}
