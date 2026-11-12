using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Dto
{
    public class MfcCornerStatisticsByYearsDto
    {
        public List<MfcCornerStatisticsByYearDto> Year { get; set; }
    }
    public class MfcCornerStatisticsByYearDto
    {
        public int Year { get; set; }
        public long Count { get; set; }
    }
}
