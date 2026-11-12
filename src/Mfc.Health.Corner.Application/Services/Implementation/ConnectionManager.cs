using Mfc.Health.Corner.Application.Common.Sockets;
using Mfc.Health.Corner.Application.Services.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Services.Implementation
{
    public class ConnectionManager : IConnectionManager
    {
        private ConcurrentBag<WebSocketConnection> _sockets = new ConcurrentBag<WebSocketConnection>();

        public WebSocket GetSocketById(string id)
        {
            return _sockets.FirstOrDefault(p => p.Id == id &&
            p.Socket.State == WebSocketState.Open).Socket;
        }

        public ConcurrentBag<WebSocketConnection> GetAll()
        {
            return _sockets;
        }

        public string GetId(WebSocket socket)
        {
            var collectionSocket = _sockets.Where(p => p.Socket == socket).FirstOrDefault();
            if(collectionSocket!=null)
            {
                return collectionSocket.Id;
            }
            return null;
        }
        public void AddSocket(WebSocket socket, string type)
        {
            var addedSocket = new WebSocketConnection
            {
                Id = CreateConnectionId(),
                SocketType = type,
                Socket = socket
            };
            _sockets.Add(addedSocket);
        }

        public async Task RemoveSocket(string id)
        {
            var removedSocket = _sockets.Where(s => s.Id == id).FirstOrDefault();
            if (removedSocket != null)
            {
                //_sockets.RemoveAt(_sockets.IndexOf(removedSocket));

                var qq = new ConcurrentBag<WebSocketConnection>();
                foreach(var el in _sockets)
                {
                    if(el!= removedSocket)
                    {
                        qq.Add(el);
                    }
                }
                _sockets.Clear();
                _sockets = qq;
                await removedSocket.Socket.CloseAsync(closeStatus: WebSocketCloseStatus.NormalClosure,
                    statusDescription: "Closed by the ConnectionManager",
                    cancellationToken: CancellationToken.None);
            }
        }
        public void UpdateSocketJwt(string id, string jwt)
        {
            foreach (var el in _sockets)
            {
                if(el.Id == id)
                {
                    el.Jwt = jwt;
                }
            }
        }


        private string CreateConnectionId()
        {
            return Guid.NewGuid().ToString();
        }

        public string GetJwt(WebSocket socket)
        {
            var sc = _sockets.Where(p => p.Socket == socket).FirstOrDefault();
            return sc!=null? sc.Jwt : null;
        }
    }
}