using Mfc.Health.Corner.Application.Common;
using Mfc.Health.Corner.Common;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Services.Interfaces
{
    public interface IEmailService
    {
        Task<OperationResult> SendEmailAsync(StandartEmailSettings standartSettings, string email, string subject, string message);

        Task<OperationResult> CheckSmtpConnection(StandartEmailSettings standartSettings);
    }
}
