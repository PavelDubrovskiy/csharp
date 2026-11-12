using Mfc.Health.Corner.Domain.Models;
using Mfc.Health.Corner.Persistence.Data;
using Mfc.Health.Corner.Persistence.Init;
using Mfc.Health.Corner.Persistence.Repository.Implementation;
using Mfc.Health.Corner.Persistence.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Mfc.Health.Corner.Persistence
{
    public static class PersistenceModule
    {
        public static void AddPersistenceModule([NotNull] this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IEmailConfirmationTokenRepository, EmailConfirmationTokenRepository>();

            services.AddTransient<IMedExamMailSegmentRepository, MedExamMailSegmentRepository>();

            services.AddTransient<IMedicalExaminationRepository, MedicalExaminationRepository>();

            services.AddTransient<IMfcCornerRepository, MfcCornerRepository>();

            services.AddTransient<IRoleRepository, RoleRepository>();

            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<IUserRoleRepository, UserRoleRepository>();
            
            services.AddTransient<IMedicalExaminationRepository, MedicalExaminationRepository>();
            
            services.AddTransient<IDistrictRepository, DistrictRepository>();

            services.AddTransient<ICommandDeviceRepository, CommandDeviceRepository>();

            services.AddTransient<IHeadOfDivisionRepository, HeadOfDivisionRepository>();

            services.AddTransient<IHeadOfMfcRepository, HeadOfMfcRepository>();

            services.AddTransient<IMfcSrpecialistCallRepository, MfcSrpecialistCallRepository>();

            services.AddTransient<IUserManagementRepository, UserManagementRepository>();

            services.AddTransient<IMfcCorenerStatisticPerDayRepository, MfcCorenerStatisticPerDayRepository>();

            services.AddTransient<IDbInitializer, DbInitializer>();

            services.AddTransient<IMigrationVersionInfoRepository, MigrationVersionInfoRepository>();

            services.Configure<MongoDBConfig>(
               configuration.GetSection(nameof(MongoDBConfig)));
            services.Configure<DefaultAppsettingsUser>(
                configuration.GetSection(nameof(DefaultAppsettingsUser)));
        }
    }
}
