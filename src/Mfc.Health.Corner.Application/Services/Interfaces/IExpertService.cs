using System.Threading.Tasks;
using Mfc.Health.Corner.Application.Common;
using Mfc.Health.Corner.Application.Dto;
using Mfc.Health.Corner.Common;

namespace Mfc.Health.Corner.Application.Services.Interfaces
{
    public interface IExpertService
    {
        Task<OperationResult> CallSpecialist();
        Task<OperationResult> SendMedicalExaminationResults(string emailAddres);

        Task<OperationResult> MakeAppointmentWithDoctor();

        Task<OperationResult> SendToEmias();

    }
}
