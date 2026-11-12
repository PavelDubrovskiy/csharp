using Mfc.Health.Corner.Domain.Models;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Persistence.Repository.Interfaces
{
    public interface ICommandDeviceRepository
    {
        Task CreateCommandDeviceAsync(CommandDevice commandDevice);
        Task<CommandDevice> GetFirstCommandAsync();
        Task DeleteCommandDeviceByGroupNameAsync(string id);
    }
}
