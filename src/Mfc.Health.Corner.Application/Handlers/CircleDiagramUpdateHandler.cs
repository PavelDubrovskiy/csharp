using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Mfc.Health.Corner.Application.Common;
using Mfc.Health.Corner.Application.Services.Interfaces;
using Mfc.Health.Corner.Common.Extension;
using Newtonsoft.Json;

namespace Mfc.Health.Corner.Application.Handlers
{
    public class CircleDiagramUpdateHandler : WebSocketHandler
    {
        private readonly IDashBordService _dashBordService;
        public CircleDiagramUpdateHandler(IConnectionManager webSocketConnectionManager,
            IDashBordService dashBordService,
            ISocketMessager socketMessager
            ) : base(webSocketConnectionManager, socketMessager)
        {
            _dashBordService = dashBordService;
        }

        public override async Task ReceiveAsync(WebSocket socket, WebSocketReceiveResult result, byte[] buffer)
        {
            var bufferMessage = GetBufferMassege(result, buffer);

            Console.WriteLine(bufferMessage);

            if (bufferMessage.Contains("Bearer"))
            {
                var jwt = bufferMessage.GetJwtFromAuthorizationString();
                if (!string.IsNullOrWhiteSpace(jwt))
                {
                    var id = WebSocketConnectionManager.GetId(socket);
                    if (!String.IsNullOrWhiteSpace(id))
                    {
                        WebSocketConnectionManager.UpdateSocketJwt(id, jwt);
                        Console.WriteLine("jWT Added");

                    }
                }
            }
            else if (bufferMessage.Equals("mock"))
            {
                var jwt = WebSocketConnectionManager.GetJwt(socket);
                var circleDiagramsResult =
                    //OperationResult.Ok(); 
                    await _dashBordService.GetCircleDiagramsData(jwt);
                var responce = JsonConvert.SerializeObject(circleDiagramsResult);
                await _socketMessager.SendMessageAsync(socket, responce);
            }
        }

        private string GetBufferMassege(WebSocketReceiveResult result, byte[] buffer)
        {
            string text = Encoding.UTF8.GetString(buffer, 0, result.Count);
            return text;
        }

        //private string GetJwt(string authorizationHeader)
        //{
        //    if (!String.IsNullOrWhiteSpace(authorizationHeader))
        //    {
        //        return authorizationHeader.ToString().Replace("Bearer ", "");
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
    }
}
