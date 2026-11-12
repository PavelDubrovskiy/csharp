using Mfc.Health.Corner.Application.Dto;
using Mfc.Health.Corner.Domain.Models;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Services.Interfaces
{
    public interface ICommandDeviceService
    {
        Task CreateCommondDeviceAsync(CreateCommandDeviceDto createCommandDeviceDto);
    }
}
