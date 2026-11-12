using Mfc.Health.Corner.Domain.Models;
using Mfc.Health.Corner.Persistence.Data;
using Mfc.Health.Corner.Persistence.Repository.Interfaces;
using Microsoft.Extensions.Options;
using System;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Persistence.Repository.Implementation
{
    class MigrationVersionInfoRepository : IMigrationVersionInfoRepository
    {
        private readonly DbContext _context = null;
        public MigrationVersionInfoRepository(IOptions<MongoDBConfig> settings)
        {
            _context = new DbContext(settings);
        }

        public async Task CreateMigration(MigrationVersionInfo migration)
        {
            await _context.MigrationVersionInfo.InsertOneAsync(migration);
        }

        public async Task<MigrationVersionInfo> GetLastMigrationVersionInfo()
        {
            try
            {
                var result = await _context.MigrationVersionInfo.AsQueryable()
                    .OrderByDescending(x => x.AppliedOn).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return null;
            }
        }

        public async Task<long> GetMigrationCount()
        {
            var filterBuilder = Builders<MigrationVersionInfo>.Filter.Empty;
            return await _context.MigrationVersionInfo.CountDocumentsAsync(filterBuilder);
        }
    }
}
