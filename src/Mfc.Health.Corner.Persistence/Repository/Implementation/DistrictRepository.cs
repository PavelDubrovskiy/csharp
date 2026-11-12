using Mfc.Health.Corner.Common;
using Mfc.Health.Corner.Domain;
using Mfc.Health.Corner.Domain.Models;
using Mfc.Health.Corner.Persistence.Data;
using Mfc.Health.Corner.Persistence.Repository.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace Mfc.Health.Corner.Persistence.Repository.Implementation
{
    public class DistrictRepository : IDistrictRepository
    {
        private readonly DbContext _context = null;
        public DistrictRepository(IOptions<MongoDBConfig> settings)
        {
            _context = new DbContext(settings);
        }
        public async Task<string> CreateDistrictAsync(District district)
        {
            await _context.Districts.InsertOneAsync(district);
            return district.Id;
        }

        public async Task<bool> DeleteDistrictByIdAsync(string id)
        {
            var districtDeleted = await _context.Districts.DeleteOneAsync(x => x.Id == id);

            if (districtDeleted.IsAcknowledged)
            {
                var headOfDivisionsList = await _context.HeadOfDivisions.Find(x => x.DistrictId == id).ToListAsync();

                var cornersfilterBuilder = Builders<MfcCorner>.Filter.Where(x => x.DistrictId == id);
                var corners = await _context.MfcCorners.Find(cornersfilterBuilder).ToListAsync();

                var cornerIds = corners.Select(x => x.Id);

                var headOfMfcFilterBuilder = Builders<HeadOfMfc>.Filter.Where(x => cornerIds.Contains(x.MfcCornerId));
                var headOfMfc = await _context.HeadOfMfcs.Find(headOfMfcFilterBuilder).ToListAsync();

                var usermanagmentFilterBuilder = Builders<UserManagement>.Filter.Where(x => cornerIds.Contains(x.MfcCornerId));
                var userManagements = await _context.UserManagements.Find(usermanagmentFilterBuilder).ToListAsync();

                var userManagementsUserRoleIds = userManagements.Select(x => x.UserRoleId).ToList();
                var headOfDivisionsUserRoleIds = headOfDivisionsList.Select(x => x.UserRoleId).ToList();
                var headOfMfcUserRoleIds = headOfMfc.Select(x => x.UserRoleId).ToList();

                var commonUserRoleIds = headOfDivisionsUserRoleIds.Concat(userManagementsUserRoleIds).Concat(headOfMfcUserRoleIds).ToList();

                var userRolesfilterBuilder = Builders<UserRole>.Filter.Where(x => commonUserRoleIds.Contains(x.Id));
                var userRoles = await _context.UserRoles.Find(userRolesfilterBuilder).ToListAsync();
                var UserIds = userRoles.Select(x => x.UserId).ToList();
                var userRoleIds = userRoles.Select(x => x.Id).ToList();

                await _context.Users.DeleteManyAsync(x => UserIds.Contains(x.Id));
                await _context.UserRoles.DeleteManyAsync(x => userRoleIds.Contains(x.Id));
                await _context.HeadOfDivisions.DeleteManyAsync(x => x.DistrictId == id);
                await _context.MfcCorners.DeleteManyAsync(x => cornerIds.Contains(x.Id));


                return true;
            }
            return false;
        }

        public async Task<PagedCollection<District>> GetAllDistrictsAsync(int? pageNumber, int? pageSize, string name)
        {
            var filterBuilder = Builders<District>.Filter.Empty;
            var totalItems = _context.Districts.CountDocuments(filterBuilder);
            if (!string.IsNullOrEmpty(name))
            {
                filterBuilder = Builders<District>.Filter.Where(x => x.Name == name);
            }
            var districtQuery = _context.Districts.Find(filterBuilder);
            if (pageNumber != null && pageSize != null)
            {
                districtQuery = districtQuery.Skip((pageNumber - 1) * pageSize).Limit(pageSize);
            }
            var districts = await districtQuery.ToListAsync();
            PagedCollection<District> pageInfo = new PagedCollection<District> { Total = totalItems, Items = districts };
            return pageInfo;
        }

        public async Task<District> GetDistrictAsync(string id)
        {
            try
            {
                return await _context.Districts.Find(x => x.Id == id).FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task UpdateDistrictAsync(District district)
        {
            await _context.Districts.ReplaceOneAsync(x => x.Id == district.Id, district);
        }
    }
}
