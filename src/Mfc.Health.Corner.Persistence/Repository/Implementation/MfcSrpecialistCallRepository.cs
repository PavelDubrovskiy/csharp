using Mfc.Health.Corner.Domain.Models;
using Mfc.Health.Corner.Persistence.Data;
using Mfc.Health.Corner.Persistence.Repository.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Persistence.Repository.Implementation
{
    public class MfcSrpecialistCallRepository : IMfcSrpecialistCallRepository
    {
        private readonly DbContext _context = null;

        public MfcSrpecialistCallRepository(IOptions<MongoDBConfig> settings)
        {
            _context = new DbContext(settings);
        }

        public async Task<MfcSrpecialistCall> CreateMfcSrpecialistCall(MfcSrpecialistCall mfcSrpecialistCall)
        {
            await _context.MfcSrpecialistCalls.InsertOneAsync(mfcSrpecialistCall);
            return mfcSrpecialistCall;
        }

        public async Task<MfcSrpecialistCall> GetMfcSrpecialistCallById(string id)
        {
            return await _context.MfcSrpecialistCalls.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
