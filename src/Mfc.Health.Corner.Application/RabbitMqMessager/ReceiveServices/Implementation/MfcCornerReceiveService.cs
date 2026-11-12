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
using System.Net;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.RabbitMqMessager.ReceiveServices.Implementation
{
    public class MfcCornerReceiveService : AbstractCommonReceiveService, IMfcCornerReceiveService
    {
        private readonly IMfcCornerRepository _mfcCornerRepository;
        private readonly IConfiguration _configuration;

        public MfcCornerReceiveService(IOptions<RammitMqSettings> rammitMqSettingsOptions,
            IMfcCornerRepository mfcCornerRepository,
            IConfiguration configuration) : base(rammitMqSettingsOptions) 
        {
            _mfcCornerRepository = mfcCornerRepository;
            _configuration = configuration;
        }

        protected override string QueueName => nameof(MfcCorner);

        protected override void ConfigureEndpoint(IRabbitMqReceiveEndpointConfigurator ep)
        {
            ep.Handler<MfcCorner>(async context =>
            {
                try
                {
                    //TODO - add logs
                    var receivedCorner = context.Message;
                    if(IsDataForCurrentMfcCorner(receivedCorner))
                    {
                        await SaveReceivedInfo(receivedCorner);
                    }
                }
                catch (Exception ex)
                {
                    //TODO - add logs
                    var msg = ex.Message;
                    throw;
                }
            });
        }

        //TODO Вынести в отдельный сервис
        private bool IsDataForCurrentMfcCorner(MfcCorner receivedCorner)
        {
            try
            {
                if(!string.IsNullOrWhiteSpace( receivedCorner.Ip))
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
            catch(Exception ex)
            {
                throw;
            }
        }

        private async Task SaveReceivedInfo(MfcCorner receivedCorner)
        {
            var localMfc = await _mfcCornerRepository.GetLocalMfcAsync();
            if (localMfc == null)
            {
                 await _mfcCornerRepository.CreateMfcAsync(receivedCorner);
            }
            else
            {
                await _mfcCornerRepository.UpdateMfcAsync(receivedCorner);
            }
        }
    }
}
