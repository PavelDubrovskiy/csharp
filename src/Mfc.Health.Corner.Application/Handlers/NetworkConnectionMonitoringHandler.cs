using Mfc.Health.Corner.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Handlers
{
    public class NetworkConnectionMonitoringHandler : WebSocketHandler
    {
        public NetworkConnectionMonitoringHandler(IConnectionManager webSocketConnectionManager,
            ISocketMessager socketMessager) : base(webSocketConnectionManager, socketMessager)
        {
        }
        public override async Task ReceiveAsync(WebSocket socket,
            WebSocketReceiveResult result, byte[] buffer)
        {
        }
    }
}
