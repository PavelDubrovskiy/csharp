using Mfc.Health.Corner.Common;
using Mfc.Health.Corner.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Persistence.Repository.Interfaces
{
    public interface IDistrictRepository
    {
        Task<PagedCollection<District>> GetAllDistrictsAsync(int? pageNumber, int? pageSize, string name);
        Task<District> GetDistrictAsync(string id);
        Task<string> CreateDistrictAsync(District district);
        Task UpdateDistrictAsync(District district);
        Task<bool> DeleteDistrictByIdAsync(string id);
    }
}
