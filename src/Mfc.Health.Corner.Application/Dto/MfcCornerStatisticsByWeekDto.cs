using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Dto
{
    public class MfcCornerStatisticsByWeekDto
    {
        public List<MfcCornerStatisticsByDayOfWeekDto> Week { get; set; }
    }

    public class MfcCornerStatisticsByDayOfWeekDto
    {
        public string Name { get; set; }
        public long Count { get; set; }
    }

}
