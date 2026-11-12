using Mfc.Health.Corner.Application.Services.Interfaces;
using Mfc.Health.Corner.Common;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Websocket.Client;

namespace Mfc.Health.Corner.Application.Services.Implementation
{
    public class WebSocketClientService : IWebSocketClientService
    {
        private readonly IConfiguration _configuration;
        private readonly Uri _url;
        private readonly WebsocketClient client;

        public WebSocketClientService(IConfiguration configuration)
        {
            _configuration = configuration;
            var uriString = _configuration.GetSection(nameof(WebSocketsSettings))?
              .GetSection(nameof(WebSocketsSettings.Clients))?
              .GetSection(nameof(WebSocketsSettings.Clients.VideoServer))
              .Value ?? "ws://172.40.0.1:9091/";
            _url = new Uri(uriString);
            client = new WebsocketClient(_url);
            client.ReconnectTimeout = TimeSpan.FromSeconds(5);
            client.ReconnectionHappened.Subscribe(info =>
                Console.WriteLine($"Reconnection happened, type: {info.Type}"));

            client.MessageReceived.Subscribe(msg => Console.WriteLine($"Message received: {msg}"));
        }

        public async Task SendStatus(string statusMessage)
        {
            try
            {
                var exitEvent = new ManualResetEvent(false);

                object msg = new
                {
                    action = "CONNECT_SENDER",
                    status = statusMessage
                };
                if(!client.IsStarted)
                {
                   await  client.Start();
                }
                if(!client.IsRunning)
                {
                   await client.Reconnect();
                }

                client.Send(JsonConvert.SerializeObject(msg));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}