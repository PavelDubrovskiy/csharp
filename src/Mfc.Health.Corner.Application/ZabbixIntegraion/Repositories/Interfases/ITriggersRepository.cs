using Mfc.Health.Corner.Application.Common;
using Mfc.Health.Corner.Application.ZabbixIntegraion.Dto;
using Mfc.Health.Corner.ZabbixIntegration.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.ZabbixIntegration.Repositories.Interfases
{
    public interface ITriggersRepository
    {
        Task<List<ZabbixTopTriggerDto>> GetTopTriggers();
        Task<List<JournalEventsTime>> GetEventLogByDay(DateTime start, DateTime end, List<string> mfcCornerIds);
        Task<List<JornalStatisticDto>> GetEventLogByPeriodFromHost(DateTime start, DateTime end, string mfcCornerId);
        Task<MfcCornerDeviceInfoDto> GetMfcCornerDeviceInfoDto(DateTime start, DateTime end, string mfcCornerId);
    }
}
