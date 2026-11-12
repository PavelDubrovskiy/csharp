using Mfc.Health.Corner.Domain.Models;
using Mfc.Health.Corner.Persistence.Data;
using Mfc.Health.Corner.Persistence.Repository.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Persistence.Repository.Implementation
{
    public class UserManagementRepository : IUserManagementRepository
    {
        private readonly DbContext _context = null;

        public UserManagementRepository(IOptions<MongoDBConfig> settings)
        {
            _context = new DbContext(settings);
        }

        public async Task<UserManagement> CreateUserManagement(UserManagement userManagement)
        {
            await _context.UserManagements.InsertOneAsync(userManagement);
            return userManagement;
        }

        public async Task<UserManagement> GetUserManagementById(string id)
        {
            return await _context.UserManagements.Find(x => x.Id == id).FirstOrDefaultAsync();

        }

        public async Task<UserManagement> GetUserManagementUserRoleId(string userRoleId)
        {
            return await _context.UserManagements.Find(x => x.UserRoleId == userRoleId).FirstOrDefaultAsync();
        }
        public async Task DeleteUserManagementByUserRoleId(string userRoleId)
        {
           await _context.UserManagements.DeleteManyAsync(x => x.UserRoleId == userRoleId);
        }
        public async Task UpdateuserManagementAsync(UserManagement userManagement)
        {
            await _context.UserManagements.ReplaceOneAsync(x => x.Id == userManagement.Id, userManagement);
        }
    }
}
