using MassTransit;
using MassTransit.RabbitMqTransport;
using Mfc.Health.Corner.Domain.Models;
using Mfc.Health.Corner.Persistence.Repository.Interfaces;
using Mfc.Health.Corner.RabbitMqMessager.Models;
using Mfc.Health.Corner.RabbitMqMessager.Receiver.Implementation;
using Mfc.Health.Corner.RabbitMqMessager.ReceiveServices.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.RabbitMqMessager.ReceiveServices.Implementation
{
    public class CommandDeviceReceiveService : AbstractCommonReceiveService, ICommandDeviceReceiveService
    {
        private readonly ICommandDeviceRepository _commandDeviceRepository;
        private readonly IMfcCornerRepository _mfcCornerRepository;
        private readonly IConfiguration _configuration;

        public CommandDeviceReceiveService(IOptions<RammitMqSettings> rammitMqSettingsOptions,
            ICommandDeviceRepository commandDeviceRepository,
            IMfcCornerRepository mfcCornerRepository, IConfiguration configuration) : base(rammitMqSettingsOptions)
        {
            _commandDeviceRepository = commandDeviceRepository;
            _mfcCornerRepository = mfcCornerRepository;
            _configuration = configuration;
        }

        protected override string QueueName => nameof(CommandDevice);

        protected override void ConfigureEndpoint(IRabbitMqReceiveEndpointConfigurator ep)
        {
            ep.Handler<CommandDevice>(async context =>
            {
                try
                {
                    //TODO - add logs
                    var receivedCommandDevice = context.Message;
                    await SaveReceivedInfo(receivedCommandDevice);
                }
                catch (Exception ex)
                {
                    //TODO - add logs
                    var msg = ex.Message;
                    throw;
                }
            });
        }

        private async Task SaveReceivedInfo(CommandDevice receivedCommandDevice)
        {
            var localMfc = await _mfcCornerRepository.GetLocalMfcAsync();

            if (localMfc != null && localMfc.Ip.Equals(receivedCommandDevice.Group) )
            {
                await _commandDeviceRepository.CreateCommandDeviceAsync(receivedCommandDevice);
            }
        }

        //TODO Вынести в отдельный сервис
        private bool IsDataForCurrentMfcCorner(MfcCorner receivedCorner)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(receivedCorner.Ip))
                {
                    string mfcStartIdentifier = _configuration["LocalMfcStartIdentifier"];
                    if (!String.IsNullOrWhiteSpace(mfcStartIdentifier))
                    {
                        if (receivedCorner.Ip.Equals(mfcStartIdentifier))
                        {
                            return true;
                        }
                    }

                }
                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



    }
}
