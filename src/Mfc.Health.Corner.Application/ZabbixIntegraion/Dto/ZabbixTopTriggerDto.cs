using System.Collections.Generic;

namespace Mfc.Health.Corner.ZabbixIntegration.Dto
{
    public class ZabbixTopTriggerDto
    {
        public  string Text { get; set; }
        public  List<string> Mfcs { get; set; }
        public  int Count { get; set; }
    }
}
