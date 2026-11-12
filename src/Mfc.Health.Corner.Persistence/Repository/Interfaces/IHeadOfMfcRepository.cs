using Mfc.Health.Corner.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Persistence.Repository.Interfaces
{
    public interface IHeadOfMfcRepository
    {
        Task<HeadOfMfc> CreateHeadOfMfc(HeadOfMfc headOfMfc);

        Task<HeadOfMfc> GetHeadOfMfcById(string id);

        Task<HeadOfMfc> GetHeadOfMfcByUserRoleId(string userRoleId);

        Task DeleteHeadOfMfcByUserRoleId(string userRoleId);

        Task UpdateHeadOfMfAsync(HeadOfMfc headOfMfc);

    }
}
