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
    class UserMedicalExaminationReceiveService : AbstractCommonReceiveService, IUserMedicalExaminationReceiveService
    {
        private readonly IMedicalExaminationRepository _medicalExaminationRepository;
        public UserMedicalExaminationReceiveService(IOptions<RammitMqSettings> rammitMqSettingsOptions,
            IMedicalExaminationRepository medicalExaminationRepository) : base(rammitMqSettingsOptions)
        {
            _medicalExaminationRepository = medicalExaminationRepository;
        }

        protected override string QueueName => nameof(UserMedicalExamination);

        protected override void ConfigureEndpoint(IRabbitMqReceiveEndpointConfigurator ep)
        {
            ep.Handler<UserMedicalExamination>(async context =>
            {
                try
                {
                    //TODO - add logs
                    var receivedUserMedicalExamination = context.Message;
                    await SaveReceivedInfo(receivedUserMedicalExamination);
                }
                catch (Exception ex)
                {
                    //TODO - add logs
                    var msg = ex.Message;
                    throw;
                }
            });
        }


        private async Task SaveReceivedInfo(UserMedicalExamination userMedicalExamination)
        {
            var localUserMedicalExamination = await _medicalExaminationRepository.GetMedicalExaminationById(userMedicalExamination.Id);
            if (localUserMedicalExamination == null)
            {
                await _medicalExaminationRepository.CreateMedicalExaminationAsync(userMedicalExamination);
            }
            else
            {
                await _medicalExaminationRepository.SaveExaminationAsync(userMedicalExamination);
            }
        }
    }
}
