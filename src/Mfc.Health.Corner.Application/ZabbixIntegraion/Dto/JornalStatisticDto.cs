using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.ZabbixIntegraion.Dto
{
    public class JornalStatisticDto
    {
        public string Host { get; set; }
        public DateTime Clock { get; set; }
        public int Priority { get; set; }
    }
}
