using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Dto
{
    public class CornerPopularityDto
    {
        public string Title { get; set; }
        public int Total { get; set; }
        public DeviceInfoDto Devices { get; set; }
        public ExamCountsForTypeDto Full { get; set; }
        public double Average { get; set; }
    }
}
