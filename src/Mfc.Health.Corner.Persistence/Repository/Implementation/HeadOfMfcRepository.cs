using Mfc.Health.Corner.Domain.Models;
using Mfc.Health.Corner.Persistence.Data;
using Mfc.Health.Corner.Persistence.Repository.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Persistence.Repository.Implementation
{
    public class HeadOfMfcRepository : IHeadOfMfcRepository
    {
        private readonly DbContext _context = null;

        public HeadOfMfcRepository(IOptions<MongoDBConfig> settings)
        {
            _context = new DbContext(settings);
        }

        public async Task<HeadOfMfc> CreateHeadOfMfc(HeadOfMfc headOfMfc)
        {
            await _context.HeadOfMfcs.InsertOneAsync(headOfMfc);
            return headOfMfc;
        }

        public async Task<HeadOfMfc> GetHeadOfMfcById(string id)
        {
            return await _context.HeadOfMfcs.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<HeadOfMfc> GetHeadOfMfcByUserRoleId(string userRoleId)
        {
            return await _context.HeadOfMfcs.Find(x => x.UserRoleId == userRoleId).FirstOrDefaultAsync();
        }

        public async Task DeleteHeadOfMfcByUserRoleId(string userRoleId)
        {
            await _context.HeadOfMfcs.DeleteManyAsync(x => x.UserRoleId == userRoleId);
        }

        public async Task UpdateHeadOfMfAsync(HeadOfMfc headOfMfc)
        {
            await _context.HeadOfMfcs.ReplaceOneAsync(x => x.Id == headOfMfc.Id, headOfMfc);
        }

    }
}
