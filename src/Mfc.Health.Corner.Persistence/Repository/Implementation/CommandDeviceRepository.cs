using Mfc.Health.Corner.Domain.Models;
using Mfc.Health.Corner.Persistence.Data;
using Mfc.Health.Corner.Persistence.Repository.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Persistence.Repository.Implementation
{
    public class CommandDeviceRepository : ICommandDeviceRepository
    {
        private readonly DbContext _context = null;

        public CommandDeviceRepository(IOptions<MongoDBConfig> settings)
        {
            _context = new DbContext(settings);
        }

        public async Task CreateCommandDeviceAsync(CommandDevice commandDevice)
        {
            await _context.CommandsDevice.InsertOneAsync(commandDevice);
        }

        public async Task<CommandDevice> GetFirstCommandAsync()
        {
            return await _context.CommandsDevice.AsQueryable().FirstOrDefaultAsync();
        }

        public async Task DeleteCommandDeviceByGroupNameAsync(string id)
        {
            await _context.CommandsDevice.DeleteOneAsync(x => x.Id == id);
        }
    }
}
