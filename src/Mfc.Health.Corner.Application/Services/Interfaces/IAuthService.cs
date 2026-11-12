using Mfc.Health.Corner.Application.Common;
using Mfc.Health.Corner.Application.Dto;
using Mfc.Health.Corner.Common;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<OperationResult<string>> AuthenticateAsync(LoginDto loginDto);
        Task<OperationResult> CheckUser(string jwt);
    }
}
