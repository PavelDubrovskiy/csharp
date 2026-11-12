using Mfc.Health.Corner.ZabbixIntegration.Repositories.Implementations;
using Mfc.Health.Corner.ZabbixIntegration.Repositories.Interfases;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;


namespace Mfc.Health.Corner.ZabbixIntegration.DI
{
    public static class ZabbixIntegrationModules
    {
        public static void AddZabbixIntegrationModules(
            [NotNull] this IServiceCollection services,
            IConfiguration configuration)
        {

            //string connection = configuration.GetConnectionString("ZabbixConnectionString");
            //if (string.IsNullOrWhiteSpace(connection))
            //{
            //    services.AddDbContext<zabbixserverContext>();
            //}
            //else
            //{
            //    services.AddDbContext<zabbixserverContext>(
            //        optionsBuilder =>
            //        optionsBuilder.UseMySql(
            //            configuration.GetConnectionString("ZabbixConnectionString"),
            //            ServerVersion.Parse("10.3.28-mariadb"))
            //        );
            //}


            services.AddTransient<ITriggersRepository, TriggersRepository>();
        }
    }
}
