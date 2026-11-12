using Mfc.Health.Corner.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Persistence.Repository.Interfaces
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllRolesAsync();

        Task CreateRoleListAsync(List<Role> role);

        Task CreateRoleAsync(Role role);

        Task UpdateRoleAsync(Role role);

        Task<List<Role>> GetRolesByRoleNamesAsync(List<string> rolesNames);

        Task<List<Role>> GetRolesByIdsAsync(List<string> ids);
    }
}
