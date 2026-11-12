using Mfc.Health.Corner.Domain.Models;
using Mfc.Health.Corner.Persistence.Data;
using Mfc.Health.Corner.Persistence.Repository.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Persistence.Repository.Implementation
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DbContext _context = null;

        public RoleRepository(IOptions<MongoDBConfig> settings)
        {
            _context = new DbContext(settings);
        }

        public async Task<List<Role>> GetAllRolesAsync()
        {
            return await _context.Roles.Find(x => true).ToListAsync();
        }

        public async Task CreateRoleListAsync(List<Role> role)
        {
            await _context.Roles.InsertManyAsync(role);
        }

        public async Task CreateRoleAsync(Role role)
        {
            await _context.Roles.InsertOneAsync(role);
        }

        public async Task UpdateRoleAsync(Role role)
        {
            await _context.Roles.ReplaceOneAsync(x => x.Id == role.Id, role);
        }

        public async Task<List<Role>> GetRolesByRoleNamesAsync(List<string> rolesNames)
        {
            return await _context.Roles.Find(x => rolesNames.Contains(x.Name)).ToListAsync();
        }

        public async Task<List<Role>> GetRolesByIdsAsync(List<string> ids)
        {
            return await _context.Roles.Find(x => ids.Contains(x.Id)).ToListAsync();
        }
    }
}
