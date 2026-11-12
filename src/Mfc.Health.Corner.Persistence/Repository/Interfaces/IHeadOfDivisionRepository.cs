using Mfc.Health.Corner.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Persistence.Repository.Interfaces
{
    public interface IHeadOfDivisionRepository
    {
        Task<HeadOfDivision> CreateHeadOfDivision(HeadOfDivision headOfDivision);
        Task<HeadOfDivision> GetHeadOfDivisionById(string id);
        Task<HeadOfDivision> GetHeadOfDivisionByUserRoleId(string id);
        Task DeleteHeadOfDivisionByUserRoleId(string userRoleId);
        Task UpdateHeadOfDivisionAsync(HeadOfDivision headOfDivision);
    }
}
