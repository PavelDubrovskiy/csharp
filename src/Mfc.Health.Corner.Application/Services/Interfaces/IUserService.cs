using Mfc.Health.Corner.Application.Common;
using Mfc.Health.Corner.Application.Dto;
using Mfc.Health.Corner.Common;
using Mfc.Health.Corner.Domain.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<OperationResult<PagedCollection<UserDto>>> GetAllUsersAsync(string name, int pageNumber, int pageSize);

        Task<OperationResult> UpdateUserAsync(UpdateUserDto updateUserDto);

        Task<OperationResult> DeleteUserByIdAsync(string id);

        Task<OperationResult<User>> GetUserByJwt(string jwt);

        Task<MemoryStream> ExportUserToXlsAsync(DateTime? startDate, DateTime? endDate);

        Task<OperationResult<UserDto>> GetCurrentUserAsync(string jwt);
    }
}
