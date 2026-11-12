using Mfc.Health.Corner.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Persistence.Repository.Interfaces
{
    public interface IUserManagementRepository
    {
        Task<UserManagement> CreateUserManagement(UserManagement userManagement);
        Task<UserManagement> GetUserManagementById(string id);
        Task<UserManagement> GetUserManagementUserRoleId(string userRoleId);
        Task DeleteUserManagementByUserRoleId(string userRoleId);
        Task UpdateuserManagementAsync(UserManagement userManagement);
    }
}
