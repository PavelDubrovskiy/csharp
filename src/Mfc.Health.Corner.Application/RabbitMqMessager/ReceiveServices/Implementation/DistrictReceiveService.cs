using MassTransit;
using MassTransit.RabbitMqTransport;
using Mfc.Health.Corner.Domain.Models;
using Mfc.Health.Corner.Persistence.Repository.Interfaces;
using Mfc.Health.Corner.RabbitMqMessager.Models;
using Mfc.Health.Corner.RabbitMqMessager.Receiver.Implementation;
using Mfc.Health.Corner.RabbitMqMessager.ReceiveServices.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.RabbitMqMessager.ReceiveServices.Implementation
{
    public class DistrictReceiveService : AbstractCommonReceiveService, IDistrictReceiveService
    {
        private readonly IDistrictRepository _districtRepository;
        public DistrictReceiveService(IOptions<RammitMqSettings> rammitMqSettingsOptions,
            IDistrictRepository districtRepository) : base(rammitMqSettingsOptions)
        {
            _districtRepository = districtRepository;
        }

        protected override string QueueName => nameof(District);

        protected override void ConfigureEndpoint(IRabbitMqReceiveEndpointConfigurator ep)
        {
            ep.Handler<District>(async context =>
            {
                try
                {
                    //TODO - add logs
                    var receivedDistrict = context.Message;
                    await SaveReceivedInfo(receivedDistrict);
                }
                catch (Exception ex)
                {
                    //TODO - add logs
                    var msg = ex.Message;
                    throw;
                }
            });
        }

        private async Task SaveReceivedInfo(District receivedDistrict)
        {
            var localUserMedicalExamination = await _districtRepository.GetDistrictAsync(receivedDistrict.Id);
            if (localUserMedicalExamination == null)
            {
                await _districtRepository.CreateDistrictAsync(receivedDistrict);
            }
            else
            {
                await _districtRepository.UpdateDistrictAsync(receivedDistrict);
            }
        }

    }
}
