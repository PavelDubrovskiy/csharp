using System.Net.WebSockets;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Services.Interfaces
{
    public interface ISocketMessager
    {
        public Task SendMessageAsync(WebSocket socket, string message);
    }
}
