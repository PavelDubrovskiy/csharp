using Mfc.Health.Corner.Domain.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Mfc.Health.Corner.Persistence.Data
{
    public class DbContext
    {
        private readonly IMongoDatabase _database = null;

        public DbContext(IOptions<MongoDBConfig> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);

            if (client != null)
            {
                _database = client.GetDatabase(settings.Value.Database);
            }
        }

        public IMongoCollection<User> Users => _database.GetCollection<User>("Users");

        public IMongoCollection<EmailConfirmationToken> EmailConfirmationTokens => _database.GetCollection<EmailConfirmationToken>("EmailConfirmationTokens");

        public IMongoCollection<UserMedicalExamination> UserMedicalExaminations => _database.GetCollection<UserMedicalExamination>("UserMedicalExaminations");

        public IMongoCollection<Role> Roles => _database.GetCollection<Role>("Roles");

        public IMongoCollection<MfcCorner> MfcCorners => _database.GetCollection<MfcCorner>("MfcCorners");

        public IMongoCollection<UserRole> UserRoles => _database.GetCollection<UserRole>("UserRoles");

        public IMongoCollection<MedExamMailSegment> MedExamMailSegments => _database.GetCollection<MedExamMailSegment>("MedExamMailSegments");

        public IMongoCollection<District> Districts => _database.GetCollection<District>("Districts");

        public IMongoCollection<CommandDevice> CommandsDevice => _database.GetCollection<CommandDevice>("CommandsDevice");

        public IMongoCollection<MfcSrpecialistCall> MfcSrpecialistCalls => _database.GetCollection <MfcSrpecialistCall>("MfcSrpecialistCalls");

        public IMongoCollection<HeadOfDivision> HeadOfDivisions => _database.GetCollection<HeadOfDivision>("HeadOfDivisions");

        public IMongoCollection<HeadOfMfc> HeadOfMfcs => _database.GetCollection<HeadOfMfc>("HeadOfMfcs");

        public IMongoCollection<UserManagement> UserManagements => _database.GetCollection<UserManagement>("UserManagements");

        public IMongoCollection<MfcCorenerStatisticPerDay> MfcCorenerStatisticPerDays => _database.GetCollection<MfcCorenerStatisticPerDay>("MfcCorenerStatisticPerDays");

        public IMongoCollection<MigrationVersionInfo> MigrationVersionInfo => _database.GetCollection<MigrationVersionInfo>("MigrationVersionInfo");

    }
}
