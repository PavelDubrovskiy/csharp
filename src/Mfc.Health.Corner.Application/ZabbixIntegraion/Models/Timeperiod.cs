using System;
using System.Collections.Generic;

#nullable disable

namespace Mfc.Health.Corner.ZabbixIntegration
{
    public partial class Timeperiod
    {
        public Timeperiod()
        {
            MaintenancesWindows = new HashSet<MaintenancesWindow>();
        }

        public ulong Timeperiodid { get; set; }
        public int TimeperiodType { get; set; }
        public int Every { get; set; }
        public int Month { get; set; }
        public int Dayofweek { get; set; }
        public int Day { get; set; }
        public int StartTime { get; set; }
        public int Period { get; set; }
        public int StartDate { get; set; }

        public virtual ICollection<MaintenancesWindow> MaintenancesWindows { get; set; }
    }
}
