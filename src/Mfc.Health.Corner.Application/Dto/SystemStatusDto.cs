using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Dto
{
    public class SystemStatusDto
    {
        public List<string> mfcCondition { get; set; }
        public List<BarChart> BarCharts { get; set;}
        public List<StackChart> StackCharts { get; set; }
        public List<MfcData> MfcDatas { get; set; }
    }

    public class MfcData
    {
        public string Name { get; set; }
        public List<StatusWithTime> Statuses { get; set; }
    }

    public class BarChart
    {
        public string group { get; set; }
        public int value { get; set; }
    }

    public class StackChart
    {
        public string group { get; set; }
        public int unwork { get; set; }
        public int work { get; set; }
    }

    public class StatusWithTime
    {
        public string group { get; set; }
        public int analyzer { get; set; }
        public int bsm { get; set; }
        public int gaz { get; set; }
        public int pulse { get; set; }
        public int bpbio { get; set; }
    }
}
