using Mfc.Health.Corner.Common;
using Mfc.Health.Corner.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Persistence.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<PagedCollection<User>> GetAllUsersByQueryAsync(string name, int pageNumber, int pageSize, bool withoutDeleted = true);

        Task<User> GetUserByIdAsync(string id);

        Task<User> CreateUserAsync(User user);

        Task UpdateUserAsync(User user);

        Task<bool> DeleteUserByIdAsync(string id);

        Task<User> GetUserByEmailAsync(string email);

        Task<List<User>> GetUsersByPeriodAsync(DateTime? startDate, DateTime? endDate);
    }
}
