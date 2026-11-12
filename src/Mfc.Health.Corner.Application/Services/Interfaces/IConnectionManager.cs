using Mfc.Health.Corner.Application.Common.Sockets;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Services.Interfaces
{
    public interface IConnectionManager
    {
        public WebSocket GetSocketById(string id);
        public ConcurrentBag<WebSocketConnection> GetAll();
        public string GetId(WebSocket socket);
        public string GetJwt(WebSocket socket);
        public void AddSocket(WebSocket socket, string type);
        void UpdateSocketJwt(string id, string jwt);
        public Task RemoveSocket(string id);
    }
}
