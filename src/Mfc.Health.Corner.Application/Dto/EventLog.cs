using Mfc.Health.Corner.Application.ZabbixIntegraion.Dto;
using Mfc.Health.Corner.ZabbixIntegration.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Dto
{
    public class EventLog
    {
        public TotalInfo total { get; set; }
        public List<JournalEventsTime> JournalEventsTime { get; set; }
        public List<JournalEvents> journalEvents { get; set; }
    }

    public class TotalInfo
    {
        public int errors { get; set; }
        public int warnings { get; set; }
        public int info { get; set; }
    }
}
