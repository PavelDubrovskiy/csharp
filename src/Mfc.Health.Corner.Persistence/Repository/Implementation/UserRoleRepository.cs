using Mfc.Health.Corner.Domain.Models;
using Mfc.Health.Corner.Persistence.Data;
using Mfc.Health.Corner.Persistence.Repository.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Persistence.Repository.Implementation
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly DbContext _context = null;

        public UserRoleRepository(IOptions<MongoDBConfig> settings)
        {
            _context = new DbContext(settings);
        }

        public async Task<List<UserRole>> GetByIdsAsync(List<string> ids)
        {
            return await _context.UserRoles.Find(x => ids.Contains(x.Id)).ToListAsync();
        }

        public async Task<List<UserRole>> GetUserRolesByUserIdsAsync(List<string> userIds)
        {
            return await _context.UserRoles.Find(x => userIds.Contains(x.UserId)).ToListAsync();
        }

        public async Task<List<string>> GetRoleIdsByUserIdAsync(string userId)
        {
            var userRoles = await _context.UserRoles.Find(x => x.UserId == userId).ToListAsync();

            return userRoles.Select(x => x.RoleId).ToList();
        }

        public async Task<List<string>> GetUserIdsByRoleIdAsync(string roleId)
        {
            var userRoles = await _context.UserRoles.Find(x => x.RoleId == roleId).ToListAsync();
            return userRoles.Select(x => x.UserId).ToList();
        }

        public async Task<UserRole> CreateUserRoleAsync(UserRole role)
        {
            await _context.UserRoles.InsertOneAsync(role);
            return role;
        }

        public async Task CreateUserRolesAsync(List<UserRole> userRoles)
        {
            await _context.UserRoles.InsertManyAsync(userRoles);
        }

        public async Task DeleteUserRoleByUserIdAsync(string userId)
        {
            var userRoles = await _context.UserRoles.Find(x => x.UserId == userId).ToListAsync();

            var userRoleIds = userRoles.Select(x => x.Id);

            _context.UserRoles.DeleteMany(x => userRoleIds.Contains(x.Id));
        }

        public async Task DeleteUserRoleByRoleIdsAsync(List<string> roleIds, string userId)
        {
            await _context.UserRoles.DeleteManyAsync(x => x.UserId == userId && roleIds.Contains(x.RoleId));
        }
    }
}
