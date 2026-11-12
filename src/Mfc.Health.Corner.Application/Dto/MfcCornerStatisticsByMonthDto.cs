using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Dto
{
    public class MfcCornerStatisticsByMonthsDto
    {
        public List<MfcCornerStatisticsByDayOfMonthDto> Month { get; set; }

    }
    public class MfcCornerStatisticsByDayOfMonthDto
    {
        public string Name { get; set; }
        public long Count { get; set; }
    }
}
