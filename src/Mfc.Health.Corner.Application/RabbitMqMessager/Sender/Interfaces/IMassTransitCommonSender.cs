using System.Threading.Tasks;

namespace Mfc.Health.Corner.RabbitMqMessager.Sender.Interfaces
{
    public interface IMassTransitCommonSender
    {
        Task SendEntity<T>(T message) where T : class;
    }
}
