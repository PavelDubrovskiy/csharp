using Mfc.Health.Corner.Application.Common;
using Mfc.Health.Corner.Application.Dto;
using Mfc.Health.Corner.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Services.Interfaces
{
    public interface IRoleService
    {
        Task<OperationResult<List<RoleDto>>> GetAllRolesAsync();
    }
}
