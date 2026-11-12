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
    public class MfcCornerRepository : IMfcCornerRepository
    {
        private readonly DbContext _context = null;

        public MfcCornerRepository(IOptions<MongoDBConfig> settings)
        {
            _context = new DbContext(settings);
        }

        public async Task<PagedCollection<MfcCorner>> GetAllMfcAsync(int pageNumber, int pageSize, string name, bool withoutDeleted = true)
        {
            var filterBuilder = Builders<MfcCorner>.Filter.Empty;

            if (withoutDeleted)
            {
                filterBuilder = !string.IsNullOrEmpty(name) ?
                    Builders<MfcCorner>.Filter.Where(x => x.Name == name && x.DeletedAt == null) :
                    Builders<MfcCorner>.Filter.Where(x => x.DeletedAt == null);
            }
            else if (!string.IsNullOrEmpty(name))
            {
                filterBuilder = Builders<MfcCorner>.Filter.Where(x => x.Name == name);
            }

            var totalItems = _context.MfcCorners.CountDocuments(filterBuilder);

            var users = await _context.MfcCorners.Find(filterBuilder)
                                           .Skip((pageNumber - 1) * pageSize)
                                           .Limit(pageSize).ToListAsync();

            PagedCollection<MfcCorner> pageInfo = new PagedCollection<MfcCorner> { Total = totalItems, Items = users };

            return pageInfo;
        }

        public async Task<string> CreateMfcAsync(MfcCorner mfcCorner)
        {
            await _context.MfcCorners.InsertOneAsync(mfcCorner);

            return mfcCorner.Id;
        }

        public async Task UpdateMfcAsync(MfcCorner mfcCorner)
        {
            await _context.MfcCorners.ReplaceOneAsync(x => x.Id == mfcCorner.Id, mfcCorner);
        }

        public async Task<MfcCorner> GetMfcAsync(string id)
        {
            return await _context.MfcCorners.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateMfcCornerEquipmentCondition(string mfcCornerId, EquipmentCondition equipmentCondition)
        {
            var mfcCorner = await GetMfcAsync(mfcCornerId);
            mfcCorner.EquipmentCondition = equipmentCondition;
            await _context.MfcCorners.ReplaceOneAsync(x => x.Id == mfcCornerId, mfcCorner);
        }

        public async Task<MfcCorner> GetLocalMfcAsync()
        {
            return await _context.MfcCorners.AsQueryable().FirstOrDefaultAsync();
        }

        public async Task<List<MfcCorner>> GetAllMfcAsync(bool withoutDeleted = true)
        {
            var filterBuilder = withoutDeleted ?
                Builders<MfcCorner>.Filter.Where(x => x.DeletedAt == null) :
                Builders<MfcCorner>.Filter.Empty;
            var mfcList = await _context.MfcCorners.Find(filterBuilder).ToListAsync();
            return mfcList;
        }

        public async Task<bool> DeleteMfcCornerByIdAsync(string id)
        {
            var mfc = await GetMfcAsync(id);

            if (mfc == null)
            {
                return false;
            }

            mfc.DeletedAt = DateTime.UtcNow;

            await UpdateMfcAsync(mfc);

            return true;
        }

        public async Task<List<MfcCorner>> GetDivisionMfcCornersAsync(string districtId)
        {
            var divisionMfcCorners = await _context.MfcCorners.Find(x => x.DistrictId == districtId && x.DeletedAt == null).ToListAsync();
            return divisionMfcCorners;
        }

        public async Task<bool> IsMfcExistInCurrentDate(DateTime date, string mfcCornerId)
        {
            var mfcCorner = await _context.MfcCorners.Find(x => x.Id == mfcCornerId && x.CreatedAt <= date).FirstOrDefaultAsync();
            return mfcCorner != null;
        }

        public async Task<List<MfcCorner>> GetAllMfcByDistrictIdAsync(string districtId)
        {
            var mfcCorners = await _context.MfcCorners.Find(x => x.DistrictId == districtId && x.DeletedAt==null).ToListAsync();
            return mfcCorners;
        }

        public async Task<MfcCorner> GetMfcByNameAsync(string name)
        {
            var mfcCorner = await _context.MfcCorners.Find(x => x.Name == name).FirstOrDefaultAsync();
            return mfcCorner;
        }

        public async Task HardDeleteMfcCornerByIdAsync(string id)
        {
            await _context.MfcCorners.DeleteOneAsync(x => x.Id == id);
        }
    }
}
