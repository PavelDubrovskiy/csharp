using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.RabbitMqMessager.Receiver.Interfaces
{
    public interface ICommonReceiveService
    {
        void Start();
        void Stop();
    }
}
