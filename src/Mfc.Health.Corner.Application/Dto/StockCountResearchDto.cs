using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Dto
{
    public class StockCountResearchDto
    {
        public List<StockCountResearchDeviceInfoDto> countResearchDeviceInfo { get; set; }
        public List<StockCountResearchFullUnfullInfoDto> countResearchFullUnfullInfo { get; set; }
    }
}
