using Mfc.Health.Corner.Application.Common;
using Mfc.Health.Corner.Application.Dto;
using Mfc.Health.Corner.Application.Services.Interfaces;
using Mfc.Health.Corner.Common;
using Mfc.Health.Corner.Persistence.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Services.Implementation
{
    public class RoleService : IRoleService
    {
        public readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<OperationResult<List<RoleDto>>> GetAllRolesAsync()
        {
            var roles = await _roleRepository.GetAllRolesAsync();

            var rolesList =  roles.Select(roles => new RoleDto()
            {
                Id = roles.Id,
                Name = roles.Name
            }).ToList();

            return OperationResult<RoleDto>.Ok(rolesList);
        }
    }
}
