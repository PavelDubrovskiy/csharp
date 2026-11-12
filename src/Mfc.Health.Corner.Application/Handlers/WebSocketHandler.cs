using System.Net.WebSockets;
using System.Threading.Tasks;
using Mfc.Health.Corner.Application.Services.Interfaces;

namespace Mfc.Health.Corner.Application.Handlers
{
    public abstract class WebSocketHandler
    {
        protected private readonly IConnectionManager WebSocketConnectionManager;
        protected private readonly ISocketMessager _socketMessager;

        public WebSocketHandler(IConnectionManager webSocketConnectionManager,
            ISocketMessager socketMessager)
        {
            WebSocketConnectionManager = webSocketConnectionManager;
            _socketMessager = socketMessager;
        }

        protected WebSocketHandler(IConnectionManager webSocketConnectionManager)
        {
            WebSocketConnectionManager = webSocketConnectionManager;
        }

        public virtual async Task OnConnected(WebSocket socket, string type)
        {
            WebSocketConnectionManager.AddSocket(socket, type);
        }

        public virtual async Task OnDisconnected(WebSocket socket)
        {
            string id = WebSocketConnectionManager.GetId(socket);
            if (!string.IsNullOrWhiteSpace(id))
            {
                await WebSocketConnectionManager.RemoveSocket(id);
            }
        }

        public async Task SendMessageAsync(WebSocket socket, string message)
        {
            await _socketMessager.SendMessageAsync(socket, message);
        }

        public async Task SendMessageAsync(string socketId, string message)
        {
            await _socketMessager.SendMessageAsync(WebSocketConnectionManager.GetSocketById(socketId), message);
        }

        //TODO - decide if exposing the message string is better than exposing the result and buffer
        public abstract Task ReceiveAsync(WebSocket socket, WebSocketReceiveResult result, byte[] buffer);
    }
}
