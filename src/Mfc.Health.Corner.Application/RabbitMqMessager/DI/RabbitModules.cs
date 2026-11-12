using Mfc.Health.Corner.RabbitMqMessager.ReceiveServices.Implementation;
using Mfc.Health.Corner.RabbitMqMessager.ReceiveServices.Interfaces;
using Mfc.Health.Corner.RabbitMqMessager.Sender.Implementation;
using Mfc.Health.Corner.RabbitMqMessager.Sender.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.RabbitMqMessager.DI
{
    public static class RabbitModules
    {
        public static void AddRabbitModules([NotNull] this IServiceCollection services, IConfiguration configuration)
        {

            if (bool.TryParse(configuration["IsLocalMfcCorner"], out bool isLocalMfcCorner))
            {
                services.AddSingleton<IMassTransitCommonSender, MassTransitCommonSender>();

                services.AddSingleton<IMfcCornerInitializationReceiveService, MfcCornerInitializationReceiveService>();
                services.AddSingleton<IMfcCornerReceiveService, MfcCornerReceiveService>();
                services.AddSingleton<IDistrictReceiveService, DistrictReceiveService>();
                services.AddSingleton<ICommandDeviceReceiveService, CommandDeviceReceiveService>();

                services.AddSingleton<IUserMedicalExaminationReceiveService, UserMedicalExaminationReceiveService>();
                services.AddSingleton<IMfcCorenerStatisticPerDayReceiveService, MfcCorenerStatisticPerDayReceiveService>();

            }
            else
            {
                throw new ApplicationException("Configuration error. Server Type not specified");
            }
        }

        private static void AddLocalMfcCornerRabbitModules([NotNull] this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IMfcCornerInitializationReceiveService, MfcCornerInitializationReceiveService>();
            services.AddSingleton<IMfcCornerReceiveService, MfcCornerReceiveService>();
            services.AddSingleton<IDistrictReceiveService, DistrictReceiveService>();
        }

        private static void AddServerRabbitModules([NotNull] this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IUserMedicalExaminationReceiveService, UserMedicalExaminationReceiveService>();

        }
    }
}
