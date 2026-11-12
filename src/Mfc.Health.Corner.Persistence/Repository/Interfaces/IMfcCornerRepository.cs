using Mfc.Health.Corner.Common;
using Mfc.Health.Corner.Domain.Models;
using System.Threading.Tasks;
using MongoDB.Driver.Core.Operations;
using System.Collections.Generic;
using System;

namespace Mfc.Health.Corner.Persistence.Repository.Interfaces
{
    public interface IMfcCornerRepository
    {
        Task<PagedCollection<MfcCorner>> GetAllMfcAsync(int pageNumber, int pageSize, string name, bool withoutDeleted = true);
        Task<List<MfcCorner>> GetAllMfcByDistrictIdAsync(string districtId);

        Task<List<MfcCorner>> GetAllMfcAsync(bool withoutDeleted = true);

        Task<MfcCorner> GetMfcAsync(string id);

        Task<MfcCorner> GetMfcByNameAsync(string name);

        Task<MfcCorner> GetLocalMfcAsync();

        Task<string> CreateMfcAsync(MfcCorner mfcCorner);

        Task UpdateMfcAsync(MfcCorner MfcCorner);

        Task UpdateMfcCornerEquipmentCondition(string mfcCornerId, EquipmentCondition equipmentCondition);

        Task<bool> DeleteMfcCornerByIdAsync(string id);
        Task HardDeleteMfcCornerByIdAsync(string id);


        Task<List<MfcCorner>> GetDivisionMfcCornersAsync(string districtId);

        Task<bool> IsMfcExistInCurrentDate(DateTime date, string mfcCornerId);
    }
}
