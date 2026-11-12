using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.ZabbixIntegraion.Dto
{
    public class MfcCornerDeviceInfoDto
    {
        public string Host { get; set; }
        public List<DeviceInfoWithTimeDto> Data { get; set; }
    }

    public class DeviceInfoWithTimeDto
    {
        public DateTime DateTime { get; set; }
        public DeviceStatusInfo DeviceStatusInfo { get; set; }
    }

    public class DeviceStatusInfo
    {
        public bool BPBIO { get; set; }
        public bool BSM { get; set; }
        public bool ANALYZER { get; set; }
        public bool GAZ { get; set; }
        public bool PULSE { get; set; }
        public string SYSTEM_STATUS { get; set; }

    }
}
