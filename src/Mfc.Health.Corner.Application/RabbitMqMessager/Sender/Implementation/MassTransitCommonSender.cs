using GreenPipes;
using MassTransit;
using Mfc.Health.Corner.RabbitMqMessager.Models;
using Mfc.Health.Corner.RabbitMqMessager.Sender.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.RabbitMqMessager.Sender.Implementation
{
    public class MassTransitCommonSender : IMassTransitCommonSender
    {
        private IBusControl _messageBus;
        private readonly RammitMqSettings rammitMqSettings;

        public MassTransitCommonSender(IOptions<RammitMqSettings> rammitMqSettingsOptions)
        {
            rammitMqSettings = rammitMqSettingsOptions.Value;
        }

        private void InitMessageBus()
        {
            if (string.IsNullOrWhiteSpace(rammitMqSettings.Host) ||
                    string.IsNullOrWhiteSpace(rammitMqSettings.Username) ||
                    string.IsNullOrWhiteSpace(rammitMqSettings.Password))
            {
                throw new Exception($"{GetType().Name} configuration error. "
                    + "The following parameters are required: host, username, password, queueName");
            }

            if (_messageBus == null)
            {
                _messageBus = Bus.Factory.CreateUsingRabbitMq(sbc =>
                {
                    sbc.Host(rammitMqSettings.Host, h =>
                    {
                        h.Username(rammitMqSettings.Username);
                        h.Password(rammitMqSettings.Password);
                    });
                //    sbc.UseRepeat
                });
                _messageBus.ConnectPublishObserver(new PublishObserver());
                _messageBus.Start(TimeSpan.FromMilliseconds(4000));
            }
        }

        public async Task SendEntity<T>(T message) where T : class
        {
            try
            {
                InitMessageBus();
                //  var qq =  _messageBus.GetProbeResult();//.CheckHealth();
                //    if(qq.Status == BusHealthStatus.Healthy)
                //    {
                //  await _messageBus.Publish(message);
                //int secondsCount = 10;
                //var cancellationDelayTimeout = TimeSpan.FromSeconds(Convert.ToInt32(secondsCount));
                //using (var cts = new System.Threading.CancellationTokenSource(cancellationDelayTimeout))
                //{
                    await _messageBus.Publish(message);
               // }

                //}
                //else
                //{
                //    Console.WriteLine("Rabbit suka sdoh");
                //}
            }
            catch (Exception ex)
            {
                //TODO - add logs
                var msg = ex.Message;
                throw;
            }
        }

    }

    public class PublishObserver : IPublishObserver
    {
        public Task PrePublish<T>(PublishContext<T> context)
            where T : class
        {

            return Task.CompletedTask;
            // called right before the message is published (sent to exchange or topic)
        }

        public Task PostPublish<T>(PublishContext<T> context)
            where T : class
        {

            return Task.CompletedTask;
            // called after the message is published (and acked by the broker if RabbitMQ)
        }

        public Task PublishFault<T>(PublishContext<T> context, Exception exception)
            where T : class
        {
            var test = context.Message;


            return Task.CompletedTask;
            // called if there was an exception publishing the message
        }
    }
}
