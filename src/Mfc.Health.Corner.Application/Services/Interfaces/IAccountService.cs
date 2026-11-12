using Mfc.Health.Corner.Application.Common;
using Mfc.Health.Corner.Application.Dto;
using Mfc.Health.Corner.Common;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Services.Interfaces
{
    public interface IAccountService
    {
        Task<OperationResult<string>> CreateAccountAsync(CreateUserDto registration, string jwt);

        Task<OperationResult> ConfirmEmailAsync(ConfirmEmailDto confirmEmailDto);

        Task<OperationResult> RecoveryPasswordAsync(RecoveryPasswordDto recoveryPasswordDto);

        Task<OperationResult> ChangePasswordAsync(ChangePasswordDto changePasswordDto);
    }
}
