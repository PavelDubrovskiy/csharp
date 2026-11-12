using Mfc.Health.Corner.Application.Common;
using Mfc.Health.Corner.Application.Dto;
using Mfc.Health.Corner.Common;
using Mfc.Health.Corner.ZabbixIntegration.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Services.Interfaces
{
    public interface IDashBordService
    {
        Task<OperationResult<CommonCircleDiagramData>> GetCircleDiagramsData(string jwt);
        Task<OperationResult<StockCountResearchDto>> GetStockDiagramByMedDevice(string jwt);
        Task<OperationResult<ResearchDynamicsDto>> GetResearchDynamics(string jwt);
        Task<OperationResult<List<CornerPopularityDto>>> GetMfcPopularityDataDto(string jwt);
        Task<OperationResult<UpdateResearchDynamicsDto>> UpdateResearchDynamics(string jwt);
        Task<OperationResult<UpdateStockCountResearchDto>> UpdateStockDiagramByMedDevice(string jwt);
        Task<OperationResult<List<ZabbixTopTriggerDto>>> GetTopTriggers(string jwt);
        Task<OperationResult<EventLog>> GetEventLog(string jwt, DateTime? eventLogDate = null);
        Task<OperationResult<List<JournalEventsTime>>> GetJournalEventsTimeByDate(string jwt, DateTime? eventLogDate = null);
        Task<OperationResult<SystemStatusDto>> GetSystemStatusInMinutes(string jwt);

    }
}
