using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Mfc.Health.Corner.Application.Handlers;
using Mfc.Health.Corner.Application.Services.Implementation;
using Mfc.Health.Corner.Application.Services.Interfaces;

namespace Mfc.Health.Corner.WebSockets.Handlers
{
    public class StartTestHandler : WebSocketHandler
    {
        private readonly IMedicalTestService _medicalTestService;
        public StartTestHandler(IConnectionManager webSocketConnectionManager,
            IMedicalTestService medicalTestService,
            ISocketMessager socketMessager
            ) : base(webSocketConnectionManager, socketMessager)
        {
            _medicalTestService = medicalTestService;
        }

        public override async Task ReceiveAsync(WebSocket socket, WebSocketReceiveResult result, byte[] buffer)
        {
            try
            {
                var bufferMessage = GetBufferMassege(result, buffer);

                if (bufferMessage == "success")
                {
                    var successResult =  await _medicalTestService.IsShowedUpdate();
                    var msg = Newtonsoft.Json.JsonConvert.SerializeObject(successResult);
                    await _socketMessager.SendMessageAsync(socket, msg);
                }

                else if(bufferMessage == "finish")
                {
                    await _medicalTestService.FinishExamination();
                }
                else
                {
                    var processDataResult = await _medicalTestService.ProcessMedicalTests();
                    var responce = Newtonsoft.Json.JsonConvert.SerializeObject(processDataResult);
                    await _socketMessager.SendMessageAsync(socket, responce);
                }
            }
            catch(Exception ex)
            {
                throw;
            }

           
        }

        private string GetBufferMassege(WebSocketReceiveResult result, byte[] buffer)
        {
            string text = Encoding.UTF8.GetString(buffer, 0, result.Count);
            return text;
        }
    }
}
