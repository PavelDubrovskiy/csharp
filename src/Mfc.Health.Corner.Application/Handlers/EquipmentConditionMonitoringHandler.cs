
using Mfc.Health.Corner.Application.Services.Interfaces;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Handlers
{
    public class EquipmentConditionMonitoringHandler : WebSocketHandler
    {
        public EquipmentConditionMonitoringHandler(IConnectionManager webSocketConnectionManager,
            ISocketMessager socketMessager) : base(webSocketConnectionManager, socketMessager)
        {
        }
        public override async Task ReceiveAsync(WebSocket socket,
            WebSocketReceiveResult result, byte[] buffer)
        {
        }
    }
}
