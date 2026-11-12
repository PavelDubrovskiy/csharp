using Mfc.Health.Corner.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Persistence.Repository.Interfaces
{
    public interface IUserRoleRepository
    {
        Task<List<UserRole>> GetByIdsAsync(List<string> ids);

        Task<UserRole> CreateUserRoleAsync(UserRole role);

        Task CreateUserRolesAsync(List<UserRole> userRoles);

        Task<List<string>> GetRoleIdsByUserIdAsync(string userId);

        Task<List<string>> GetUserIdsByRoleIdAsync(string roleId);

        Task<List<UserRole>> GetUserRolesByUserIdsAsync(List<string> userIds);

        Task DeleteUserRoleByUserIdAsync(string userId);

        Task DeleteUserRoleByRoleIdsAsync(List<string> roleIds, string userId);
    }
}
