using System;
using Mfc.Health.Corner.Application.Common;
using System.Net;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Mfc.Health.Corner.Application.Handlers;
using Newtonsoft.Json;
using Mfc.Health.Corner.Common;

namespace Mfc.Health.Corner.Api.Middleware
{
    public class WebSocketManagerMiddleware
    {
        private readonly RequestDelegate _next;
        private WebSocketHandler _webSocketHandler { get; set; }

        public WebSocketManagerMiddleware(RequestDelegate next,
            WebSocketHandler webSocketHandler)
        {
            _next = next;
            _webSocketHandler = webSocketHandler;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                if (!httpContext.WebSockets.IsWebSocketRequest)
                {
                    return;
                }
                //httpContext.Request.Path.Value
                var socket = await httpContext.WebSockets.AcceptWebSocketAsync();
                await _webSocketHandler.OnConnected(socket, httpContext.Request.PathBase);

                await Receive(socket, async (result, buffer) =>
                {
                    if (result.MessageType == WebSocketMessageType.Text)
                    {
                        await _webSocketHandler.ReceiveAsync(socket, result, buffer);
                        return;
                    }
                    else if (result.MessageType == WebSocketMessageType.Binary)
                    {
                        return;
                    }
                    else if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await _webSocketHandler.OnDisconnected(socket);
                        return;
                    }

                });

                //TODO - investigate the Kestrel exception thrown when this is the last middleware
               // await _next.Invoke(httpContext);
            }
            catch(Exception ex)
            {
                //httpContext.Response.ContentType = "application/json";
                //httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var error = OperationResult.Error(ex);
                var errorSerializer = JsonConvert.SerializeObject(error);
                Console.WriteLine($"!Throw Exception!  {errorSerializer}");
                try
                {
                    await httpContext.Response.WriteAsync(errorSerializer);
                }
                catch(Exception e)
                {
                    error = OperationResult.Error(e);
                    errorSerializer = JsonConvert.SerializeObject(error);
                    Console.WriteLine( $"!!!!Exception in catch!!!!!!  {errorSerializer}");
                }        
            }
        }

        private async Task Receive(WebSocket socket, Action<WebSocketReceiveResult, byte[]> handleMessage)
        {
            var buffer = new byte[1024 * 8];

            while (socket.State == WebSocketState.Open)
            {
                var result = await socket.ReceiveAsync(buffer: new ArraySegment<byte>(buffer),
                    cancellationToken: CancellationToken.None);

                handleMessage(result, buffer);
            }
        }
    }
}
