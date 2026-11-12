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
    public class HeadOfDivisionRepository : IHeadOfDivisionRepository
    {
        private readonly DbContext _context = null;

        public HeadOfDivisionRepository(IOptions<MongoDBConfig> settings)
        {
            _context = new DbContext(settings);
        }

        public async Task<HeadOfDivision> CreateHeadOfDivision(HeadOfDivision headOfDivision)
        {
            await _context.HeadOfDivisions.InsertOneAsync(headOfDivision);
            return headOfDivision;
        }

        public async Task<HeadOfDivision> GetHeadOfDivisionById(string id)
        {
            return await _context.HeadOfDivisions.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<HeadOfDivision> GetHeadOfDivisionByUserRoleId(string userRoleId)
        {
            return await _context.HeadOfDivisions.Find(x => x.UserRoleId == userRoleId).FirstOrDefaultAsync();
        }
        public async Task DeleteHeadOfDivisionByUserRoleId(string userRoleId)
        {
            await _context.HeadOfDivisions.DeleteManyAsync(x => x.UserRoleId == userRoleId);
        }

        public async Task UpdateHeadOfDivisionAsync(HeadOfDivision headOfDivision)
        {
            await _context.HeadOfDivisions.ReplaceOneAsync(x => x.Id == headOfDivision.Id, headOfDivision);
        }

    }
}
