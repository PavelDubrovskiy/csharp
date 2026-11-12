using Mfc.Health.Corner.Application.Dto;
using Mfc.Health.Corner.Application.Services.Interfaces;
using Mfc.Health.Corner.Domain.Models;
using Mfc.Health.Corner.Persistence.Repository.Interfaces;
using Mfc.Health.Corner.RabbitMqMessager.Sender.Interfaces;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Services.Implementation
{
    public class CommandDeviceService : ICommandDeviceService
    {
        private readonly ICommandDeviceRepository _commandDeviceRepository;
        private readonly IMassTransitCommonSender _massTransitCommonSender;

        public CommandDeviceService(ICommandDeviceRepository commandDeviceRepository,
            IMassTransitCommonSender massTransitCommonSender)
        {
            _commandDeviceRepository = commandDeviceRepository;
            _massTransitCommonSender = massTransitCommonSender;
        }

        public async Task CreateCommondDeviceAsync(CreateCommandDeviceDto createCommandDeviceDto)
        {
            var commandDevice = new CommandDevice
            {
                Group = createCommandDeviceDto.Group,
                Command = createCommandDeviceDto.Command
            };


            await _commandDeviceRepository.CreateCommandDeviceAsync(commandDevice);
            await _massTransitCommonSender.SendEntity(commandDevice);
        }
    }
}
