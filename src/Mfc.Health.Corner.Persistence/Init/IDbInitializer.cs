using System;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Persistence.Init
{
    public interface IDbInitializer
    {
        Task InitData();
        Task InitMigrations(IServiceProvider serviceProvider );
    }
}
