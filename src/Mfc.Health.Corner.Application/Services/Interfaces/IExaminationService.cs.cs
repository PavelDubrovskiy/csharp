using Mfc.Health.Corner.Application.Common;
using Mfc.Health.Corner.Application.Dto;
using Mfc.Health.Corner.Common;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Services.Interfaces
{
    public interface IExaminationService
    {
        Task<ExaminationResponseDto> ProcessDataFromControlDevice(CreateExamDto createExaminationDto);

        Task<ExaminationResponseDto> ProcessControlDeviceCommand(CreateExaminationDto createExaminationDto);
        Task SendStatusInfo(CreateExaminationDto createExaminationDto);
        Task SendEquipmentCondition(EquipmentConditionDto equipmentCondition);

        Task<OperationResult> FinishAllExaminations();

    }
}
