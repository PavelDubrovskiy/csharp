using Mfc.Health.Corner.Persistence.Data;
using Mfc.Health.Corner.Persistence.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Mfc.Health.Corner.Persistence.Data.DIT;
using System.Collections.Generic;
using Mfc.Health.Corner.Domain.Models;
using Mfc.Health.Corner.Common.Extension;
using Mfc.Health.Corner.Persistence.Migrations.M202203151230;

namespace Mfc.Health.Corner.Persistence.Migrations.M202205041957
{
    public class M202205041957 : BaseMigration, IM202203151230
    {
        private readonly IConfiguration _configuration;
        private readonly IDistrictRepository _districtRepository;
        private readonly IMfcCornerRepository _mfcCornerRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IHeadOfMfcRepository _headOfMfcRepository;
        private readonly IHeadOfDivisionRepository _headOfDivisionRepository;

        public M202205041957(
            MongoDBConfig settings,
            IServiceProvider serviceProvider)
            : base(settings, serviceProvider)
        {
            _configuration = serviceProvider.GetService<IConfiguration>();
            _districtRepository = serviceProvider.GetService<IDistrictRepository>();
            _mfcCornerRepository = serviceProvider.GetService<IMfcCornerRepository>();
            _userRepository = serviceProvider.GetService<IUserRepository>();
            _headOfMfcRepository = serviceProvider.GetService<IHeadOfMfcRepository>();
            _headOfDivisionRepository = serviceProvider.GetService<IHeadOfDivisionRepository>();
            _roleRepository = serviceProvider.GetService<IRoleRepository>();
            _userRoleRepository = serviceProvider.GetService<IUserRoleRepository>();
        }


        public override Task Down()
        {
            throw new NotImplementedException();
        }

        public override async Task Up()
        {
            try
            {
                await UpdateGroupField();

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

        }

        private async Task UpdateGroupField()
        {
            try
            {
                var collection = GetDatabase().GetCollection<BsonDocument>("UserMedicalExaminations");;
                var documents = collection.Find(new BsonDocument()).ToList();
                foreach (var rootObject in documents)
                {
                    var exam = rootObject.GetElement("Examination").Value ?? null;
                    if(!exam.IsBsonNull)
                    {
                        var group = rootObject.GetElement("Examination").Value?.AsBsonDocument?.GetElement("Group").Value ?? null;
                        if (group.IsInt32)
                        {
                            var update = Builders<BsonDocument>.Update.Set("Examination.Group", group.AsInt32.ToString());
                            var filter = Builders<BsonDocument>.Filter.Eq("_id", rootObject.GetElement("_id").Value);
                            var options = new UpdateOptions { IsUpsert = true };
                            await collection.UpdateOneAsync(filter, update, options);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }


        public bool CollectionExistsAsync(string collectionName)
        {
            var filter = new BsonDocument("name", collectionName);

            var collections = GetDatabase().ListCollections(new ListCollectionsOptions { Filter = filter });

            return collections.Any();
        }

        private IMongoDatabase GetDatabase()
        {
            MongoClient mongoClient = new MongoClient(_settings.ConnectionString);

            var database = mongoClient.GetDatabase(_settings.Database);

            return database;
        }


    }
}
