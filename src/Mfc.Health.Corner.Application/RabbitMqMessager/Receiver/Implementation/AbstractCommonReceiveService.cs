using System;
using MassTransit;
using MassTransit.RabbitMqTransport;
using Mfc.Health.Corner.RabbitMqMessager.Models;
using Mfc.Health.Corner.RabbitMqMessager.Receiver.Interfaces;
using Microsoft.Extensions.Options;

namespace Mfc.Health.Corner.RabbitMqMessager.Receiver.Implementation
{
    public abstract class AbstractCommonReceiveService : ICommonReceiveService
    {

        #region private readonly & constructor
        private IBusControl bus;
        private readonly RammitMqSettings rammitMqSettings;

        public AbstractCommonReceiveService(IOptions<RammitMqSettings> rammitMqSettingsOptions)
        {
            rammitMqSettings = rammitMqSettingsOptions.Value;
        }
        #endregion

        #region protected abstract
        protected abstract string QueueName { get; }
        protected abstract void ConfigureEndpoint(IRabbitMqReceiveEndpointConfigurator ep);
        #endregion

        public void Start()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(rammitMqSettings.Host) ||
                    string.IsNullOrWhiteSpace(rammitMqSettings.Username) ||
                    string.IsNullOrWhiteSpace(rammitMqSettings.Password))
                {
                    throw new Exception($"{this.GetType().Name} configuration error. "
                        + "The following parameters are required: host, username, password, queueName");
                }

                bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
                {
                    sbc.Host(
                        rammitMqSettings.Host,  h =>
                    {
                        h.Username(rammitMqSettings.Username);
                        h.Password(rammitMqSettings.Password);
                    });
                    sbc.ReceiveEndpoint(QueueName, ConfigureEndpoint);
                });

                bus.Start();
            }
            catch (Exception ex)
            {
                //TODO - add logs
                var msg = ex.Message;
                throw;
            }
        }

        public void Stop()
        {
            try
            {
                if (bus != null)
                {
                    bus.Stop();
                }
            }
            catch (Exception ex)
            {
                //TODO - add logs
                var msg = ex.Message;
                throw;
            }
        }
    }
}
