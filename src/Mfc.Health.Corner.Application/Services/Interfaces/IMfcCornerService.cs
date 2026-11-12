using Mfc.Health.Corner.Application.Common;
using Mfc.Health.Corner.Application.Dto;
using Mfc.Health.Corner.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Services.Interfaces
{
    public interface IMfcCornerService
    {
        Task<PagedCollection<MfcCornerDto>> GetAllMfcAsync(int pageNumber, int pageSize, string name);
        
        Task<List<MfcCornerDto>> GetAllMfcByDistrictIdAsync(string districtId);

        Task<OperationResult<string>> CreateMfcAsync(CreateMfcCornerDto createMfcDto);

        Task<OperationResult> UpdateMfcAsync(UpdateMfcDto updateMfcDto);

        Task<OperationResult> DeleteMfcByIdAsync(string id);

        Task<OperationResult> Reinitialize(string id);
    }
}
