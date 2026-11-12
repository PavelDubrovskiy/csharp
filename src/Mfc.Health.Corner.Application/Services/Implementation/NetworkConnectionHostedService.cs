using Mfc.Health.Corner.Application.Services.Interfaces;
using Mfc.Health.Corner.Common;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Services.Implementation
{
    public class NetworkConnectionHostedService : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly IConnectionManager _webSocketConnectionManager;
        private readonly WebSocketsSettings _webSocketsSettings;
        private readonly ISocketMessager _socketMessager;


        public NetworkConnectionHostedService(
            IConnectionManager webSocketConnectionManager,
            IOptions<WebSocketsSettings> webSocketsSettingsOptions,
            ISocketMessager socketMessager)
        {
            _webSocketConnectionManager = webSocketConnectionManager;
            _webSocketsSettings = webSocketsSettingsOptions.Value;
            _socketMessager = socketMessager;
        }


        public async Task<bool> CheckConnection()
        {
            try
            {
                Ping myPing = new Ping();
                String host = "google.com";//to appsettings
                byte[] buffer = new byte[32];
                int timeout = 500;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = await myPing.SendPingAsync(host, timeout, buffer, pingOptions);
                return (reply.Status == IPStatus.Success);
            }
            catch (Exception)
            {
                return false;
            }
        }


        public Task StartAsync(CancellationToken stoppingToken)
        {

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(2));//to appsettings

            return Task.CompletedTask;
        }

        private async void DoWork(object state)
        {
            var connectionSockets = _webSocketConnectionManager.GetAll()
                .Where(x => x.SocketType == _webSocketsSettings
                .CheckNetworkConnection).ToList();
            if(connectionSockets.Count>0)
            {
                var result = (await CheckConnection()).ToString();
                foreach (var webSocket in connectionSockets)
                {
                    await _socketMessager.SendMessageAsync(webSocket.Socket, result);
                }
            }


        }

        public Task StopAsync(CancellationToken stoppingToken)
        {

            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

    }
}
