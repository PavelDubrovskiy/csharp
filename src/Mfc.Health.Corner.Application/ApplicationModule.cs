using Mfc.Health.Corner.Application.Services.Implementation;
using Mfc.Health.Corner.Application.Services.Interfaces;
using Mfc.Health.Corner.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using Mfc.Health.Corner.Persistence.Repository.Interfaces;
using Mfc.Health.Corner.Persistence.Repository.Implementation;

namespace Mfc.Health.Corner.Application
{
    public static class ApplicationModule
    {
        public static void AddApplicationModule([NotNull] this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IAccountService, AccountService>();

            services.AddTransient<IAuthService, AuthService>();

            services.AddTransient<IEmailService, EmailService>();

            services.AddTransient<IMedicalExaminationService, MedicalExaminationService>();

            services.AddTransient<IMfcCornerService, MfcCornerService>();

            services.AddTransient<IRoleService, RoleService>();

            services.AddTransient<IUserIdentity, UserIdentity>();

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IUserService, UserService>();

            services.AddTransient<IMedicalTestService, MedicalTestService>();

            services.AddSingleton<IExaminationService, ExaminationService>();

            services.AddTransient<IComplexService, ComplexService>();

            services.AddTransient<IExpertService, ExpertService>();

            services.AddTransient<IExpertService, ExpertService>();

            services.AddTransient<IDistrictService, DistrictService>();
            
            services.AddTransient<ICommandDeviceService, CommandDeviceService>();

            services.AddSingleton<IDashBordService, DashBordService>();

            services.AddTransient<ISocketMessager, SocketMessager>();

            services.AddSingleton<IConnectionManager,ConnectionManager>();

            services.AddTransient<IMfcCornerStatisticService, MfcCornerStatisticService>();
            services.AddSingleton<IWebSocketClientService, WebSocketClientService>();
            services.AddPersistenceModule(configuration);
            services.AddHostedService<NetworkConnectionHostedService>();
        }
    }
}
