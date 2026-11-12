using Mfc.Health.Corner.Common;
using Mfc.Health.Corner.Domain.Models;
using Mfc.Health.Corner.Persistence.Data;
using Mfc.Health.Corner.Persistence.Repository.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Persistence.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _context = null;

        public UserRepository(IOptions<MongoDBConfig> settings)
        {
            _context = new DbContext(settings);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.Find(x => x.Email == email).FirstOrDefaultAsync();
        }

        public async Task<PagedCollection<User>> GetAllUsersByQueryAsync(string searchString, int pageNumber, int pageSize, bool withoutDeleted = true)
        {
            var filterBuilder = Builders<User>.Filter.Empty;

            if (withoutDeleted)
            {
                filterBuilder = !string.IsNullOrEmpty(searchString) ?
                    Builders<User>.Filter.Where(x =>
                    x.FullName.Contains(searchString) && x.DeletedAt == null ||
                    x.Phone.Contains(searchString) && x.DeletedAt == null ||
                    x.Email.Contains(searchString) && x.DeletedAt == null) :
                    Builders<User>.Filter.Where(x => x.DeletedAt == null);
            }
            else if (!string.IsNullOrEmpty(searchString))
            {
                filterBuilder &= Builders<User>.Filter.Where(x =>
                x.FullName.Contains(searchString) ||
                x.Phone.Contains(searchString) ||
                x.Email.Contains(searchString));
            }

            var totalItems = _context.Users.CountDocuments(filterBuilder);

            var users = await _context.Users.Find(filterBuilder)
                                           .Skip((pageNumber - 1) * pageSize)
                                           .Limit(pageSize).ToListAsync();

            PagedCollection<User> pageInfo = new PagedCollection<User> { Total = totalItems, Items = users };

            return pageInfo;
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            var user = await _context.Users.Find(x => x.Id == id).FirstOrDefaultAsync();

            if (user != null)
            {
                return user;
            }

            return null;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            user.CreatedAt = DateTime.UtcNow.Date;

            await _context.Users.InsertOneAsync(user);

            return user;
        }

        public async Task UpdateUserAsync(User user)
        {
            await _context.Users.ReplaceOneAsync(x => x.Id == user.Id, user);
        }

        public async Task<bool> DeleteUserByIdAsync(string id)
        {
            var user = await GetUserByIdAsync(id);

            if (user == null)
            {
                return false;
            }

            user.IsDeleted = true;

            user.DeletedAt = DateTime.UtcNow;

            await UpdateUserAsync(user);

            return true;
        }

        public async Task<List<User>> GetUsersByPeriodAsync(DateTime? startDate, DateTime? endDate)
        {

            var filterBuilder = startDate==null||endDate==null ? 
                Builders<User>.Filter.Where(x=> x.DeletedAt == null) :
                Builders<User>.Filter.Where(x => x.CreatedAt >= startDate.Value.Date && x.CreatedAt <= endDate.Value.Date&&x.DeletedAt==null);

            var users = await _context.Users.Find(filterBuilder).ToListAsync();

            return users;

        }
    }
}
