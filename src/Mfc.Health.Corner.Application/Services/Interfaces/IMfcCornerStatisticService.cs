using Mfc.Health.Corner.Application.Common;
using Mfc.Health.Corner.Application.Dto;
using Mfc.Health.Corner.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Services.Interfaces
{
    public interface IMfcCornerStatisticService
    {
        Task<OperationResult<MfcCornerStatisticByHoursDto>> GetMfcCornerStatisticByHours(string mfcCornerId);
        Task<OperationResult<MfcCornerStatisticsByWeekDto>> GetMfcCornerStatisticByWeek(string mfcCornerId);
        Task<OperationResult<MfcCornerStatisticsByMonthsDto>> GetMfcCornerStatisticByMonth(string mfcCornerId);
        Task<OperationResult<MfcCornerStatisticsByYearsDto>> GetMfcCornerStatisticByYears(string mfcCornerId);
        Task<OperationResult<DevicePopularityDto>> GetDevicePopularity(string mfcCornerId);
        Task<OperationResult<List<ExaminationInfoDto>>> GetLastTenExamination(string mfcCornerId);
        Task<OperationResult<ExaminationAverageValuesDto>> GetAverageValues(string mfcCornerId);
        Task<OperationResult<MfcCornersStatisticCounts>> GetStatisticCount(string mfcCornerId);
    }
}
