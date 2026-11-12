using MassTransit;
using MassTransit.RabbitMqTransport;
using Mfc.Health.Corner.Domain.Models;
using Mfc.Health.Corner.Persistence.Repository.Interfaces;
using Mfc.Health.Corner.RabbitMqMessager.Models;
using Mfc.Health.Corner.RabbitMqMessager.Receiver.Implementation;
using Mfc.Health.Corner.RabbitMqMessager.ReceiveServices.Interfaces;
using Mfc.Health.Corner.RabbitMqMessager.Sender.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.RabbitMqMessager.ReceiveServices.Implementation
{
    public class MfcCornerInitializationReceiveService : AbstractCommonReceiveService, IMfcCornerInitializationReceiveService
    {
        private readonly IMfcCornerRepository _mfcCornerRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly IConfiguration _configuration;
        private readonly IMfcCorenerStatisticPerDayRepository _mfcCorenerStatisticPerDayRepository;
        private readonly IMassTransitCommonSender _massTransitCommonSender;
        private readonly IMedicalExaminationRepository _medicalExaminationRepository;
        public MfcCornerInitializationReceiveService(
            IOptions<RammitMqSettings> rammitMqSettingsOptions,
            IMfcCornerRepository mfcCornerRepository,
            IDistrictRepository districtRepository,
            IMfcCorenerStatisticPerDayRepository mfcCorenerStatisticPerDayRepository,
            IMassTransitCommonSender massTransitCommonSender,
            IMedicalExaminationRepository medicalExaminationRepository,
            IConfiguration configuration) : base(rammitMqSettingsOptions)
        {
            _mfcCornerRepository = mfcCornerRepository;
            _districtRepository = districtRepository;
            _mfcCorenerStatisticPerDayRepository = mfcCorenerStatisticPerDayRepository;
            _massTransitCommonSender = massTransitCommonSender;
            _medicalExaminationRepository = medicalExaminationRepository;
            _configuration = configuration;
        }

        protected override string QueueName => nameof(MfcCornerInitialization);

        protected override void ConfigureEndpoint(IRabbitMqReceiveEndpointConfigurator ep)
        {
            ep.Handler<MfcCornerInitialization>(async context =>
            {
                try
                {
                    //TODO - add logs
                    var MfcCornerInitializationData = context.Message;

                    await InicializeDistricts(MfcCornerInitializationData);

                    if (IsDataForCurrentMfcCorner(MfcCornerInitializationData.LocalMfcCorner))
                    {
                        await InicializeLocalMfcCorner(MfcCornerInitializationData);
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

        private async Task UpdateAndResendMfcCornerData(MfcCornerInitialization MfcCornerInitializationData)
        {

            await _mfcCorenerStatisticPerDayRepository
                .UpdateAllStatisticMfcIds(MfcCornerInitializationData.LocalMfcCorner.Id);
            var allStatistic = await _mfcCorenerStatisticPerDayRepository
            .GetAllStatisticForMfcById(MfcCornerInitializationData.LocalMfcCorner.Id);
            foreach (var stat in allStatistic)
            {
                await _massTransitCommonSender.SendEntity(stat);
            }
            
            await _medicalExaminationRepository
                .UpdateAllExaminationcMfcIds(MfcCornerInitializationData.LocalMfcCorner.Id);
            var allExams = await _medicalExaminationRepository
            .GetAllExamsForMfcById(MfcCornerInitializationData.LocalMfcCorner.Id);
            foreach (var exam in allExams)
            {
                await _massTransitCommonSender.SendEntity(exam);
            }
        }

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

        private async Task InicializeDistricts(MfcCornerInitialization mfcCornerInitializationData)
        {
            if (mfcCornerInitializationData.Districts != null &&
                       mfcCornerInitializationData.Districts.Count > 0)
            {
                foreach (var district in mfcCornerInitializationData.Districts)
                {
                    var currentDistrict = await _districtRepository.GetDistrictAsync(district.Id);
                    if (currentDistrict == null)
                    {
                        await _districtRepository.CreateDistrictAsync(district);
                    }
                    else
                    {
                        await _districtRepository.UpdateDistrictAsync(district);
                    }
                }
            }
        }

        private async Task InicializeLocalMfcCorner(MfcCornerInitialization mfcCornerInitializationData)
        {
            try
            {
                var localMfc = await _mfcCornerRepository.GetLocalMfcAsync();
                if (localMfc == null || !localMfc.Id.Equals(mfcCornerInitializationData.LocalMfcCorner.Id))
                {
                    await _mfcCornerRepository.CreateMfcAsync(mfcCornerInitializationData.LocalMfcCorner);

                    if (localMfc != null && !localMfc.Id.Equals(mfcCornerInitializationData.LocalMfcCorner.Id))
                    {
                        await _mfcCornerRepository.HardDeleteMfcCornerByIdAsync(localMfc.Id);
                    }
                }
                else
                {
                    await _mfcCornerRepository.UpdateMfcAsync(mfcCornerInitializationData.LocalMfcCorner);
                }
                await UpdateAndResendMfcCornerData(mfcCornerInitializationData);
            }
            catch(Exception ex)
            {
                throw;
            }
            
        }
    }
}
