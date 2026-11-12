using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Common
{
    public class WebSocketsSettings
    {
        public string StartExaminationPathBase { get; set; }
        public string SendCommandDeviceStatusPathBase { get; set; }
        public string CircleDiagramUpdate { get; set; }
        public string MfcPopularityDataUpdate { get; set; }
        public string ResearchDynamicsUpdate { get; set; }
        public string StockDiagramByMedDeviceUpdate { get; set; }
        public string CheckNetworkConnection { get; set; }
        public Clients Clients { get; set; }
    }

    public class Clients
    {
        public string VideoServer { get; set; }
    }
}
