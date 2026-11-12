using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Dto
{
    public class MfcCornerStatisticByHoursDto
    {
         public List<MfcCornerStatisticByHourDto> Hours { get; set; }
    }

    public class MfcCornerStatisticByHourDto
    {
        public int Hour { get; set; }
        public long Count { get; set; }
    }
}
