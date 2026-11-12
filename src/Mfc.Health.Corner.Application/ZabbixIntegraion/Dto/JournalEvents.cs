using Mfc.Health.Corner.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.ZabbixIntegraion.Dto
{
    public class JournalEvents
    {
        public string date { get; set; }
        public TotalInfo total { get; set; }
        //public int Errors { get; set; }
        //public int Warnings { get; set; }
        //public int Info { get; set; }
    }
}
