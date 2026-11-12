using Mfc.Health.Corner.Application.Common;
using Mfc.Health.Corner.Application.Dto;
using Mfc.Health.Corner.Common;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Services.Interfaces
{
    public interface IMedicalExaminationService
    {
        Task<OperationResult<ExaminationDto>> CreateMedicalExaminationAsync(CreateMedicalExaminationDto userMedicalExamination);
        Task<OperationResult<FullDeviceDataDto>> GetExaminationFullDeviceDataById(string id);
        Task<OperationResult<LastExaminationAnalyzerBsmDto>> GetLastExaminationAnalyzerBsmData();
    }
}
