using Mfc.Health.Corner.Application.Common;
using Mfc.Health.Corner.Application.Dto;
using Mfc.Health.Corner.Common;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Services.Interfaces
{
    public interface IDistrictService
    {
        Task<OperationResult<string>> CreateDistricAsync(CreateDistrictDto createDistrictDto);
        Task<OperationResult> UpdateDistrictAsync(DistrictDto updateMfcDto);
        Task<OperationResult<DistrictDto>> GetDistrictByIdAsync(string id);
        Task<OperationResult<PagedCollection<DistrictDto>>> GetAllDistrictsAsync(int? pageNumber, int? pageSize, string name);
        Task<OperationResult> DeleteDistrictByIdAsync(string id);
    }
}
