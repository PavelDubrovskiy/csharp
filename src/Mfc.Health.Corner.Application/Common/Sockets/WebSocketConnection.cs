using System.Net.WebSockets;

namespace Mfc.Health.Corner.Application.Common.Sockets
{
    public class WebSocketConnection
    {
        public string Id { get; set; }
        public string SocketType { get; set; }
        public WebSocket Socket { get; set; }
        public string Jwt { get; set; }
    }
}
