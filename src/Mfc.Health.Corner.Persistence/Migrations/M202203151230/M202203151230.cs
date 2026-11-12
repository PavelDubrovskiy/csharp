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

namespace Mfc.Health.Corner.Persistence.Migrations.M202203151230
{
    public class M202203151230 : BaseMigration, IM202203151230
    {
        private readonly IConfiguration _configuration;
        private readonly IDistrictRepository _districtRepository;
        private readonly IMfcCornerRepository _mfcCornerRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IHeadOfMfcRepository _headOfMfcRepository;
        private readonly IHeadOfDivisionRepository _headOfDivisionRepository;

        public M202203151230(
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
                if (bool.TryParse(_configuration["IsLocalMfcCorner"], out bool isLocalMfcCorner))
                {
                    if (!isLocalMfcCorner)
                    {
                        await InsertDITMfcCorner();
                        // не используется, так как у нас есть свой суперадмин.
                        //await InsertDITSuperAdmins();
                        await InsertDITAdmins();
                        await InsertDITHeadOfDivisions();
                        await InsertDITHeadOFMfc();
                    }
                }

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
                var collection = GetDatabase().GetCollection<BsonDocument>("CommandsDevice"); // ; ListCollections(new ListCollectionsOptions { Filter = filter });
                var documents = collection.Find(new BsonDocument()).ToList();
                foreach (var rootObject in documents)
                {
                    var group = rootObject.GetElement("Group").Value;
                    if (group.IsInt32)
                    {
                        var update = Builders<BsonDocument>.Update.Set("Group", group.AsInt32.ToString());
                        var filter = Builders<BsonDocument>.Filter.Eq("_id", (string)rootObject.GetElement("_id").Value);
                        var options = new UpdateOptions { IsUpsert = true };
                        await collection.UpdateOneAsync(filter, update, options);
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private async Task InsertDITSuperAdmins()
        {
            try
            {
                var superAdminRole = (await _roleRepository.GetAllRolesAsync()).Where(x => x.Name == "SuperAdmin").FirstOrDefault();
                using (var db = new admin_mdhContext(_configuration))
                {
                    var ditHeadOFMfcs = db.DblkIusers.Where(x => x.Igroup == 6);
                    foreach (var ditHeadOfMfc in ditHeadOFMfcs)
                    {
                        var user = ditHeadOfMfc.ToMfcCornerUser();

                        if (superAdminRole != null)
                        {
                            user = await _userRepository.CreateUserAsync(user);
                            UserRole userRole = new UserRole
                            {
                                RoleId = superAdminRole.Id,
                                UserId = user.Id
                            };
                            userRole = await _userRoleRepository.CreateUserRoleAsync(userRole);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private async Task InsertDITAdmins()
        {
            try
            {
                var adminRole = (await _roleRepository.GetAllRolesAsync())
                    .Where(x => x.Name == "Admin").FirstOrDefault();
                using (var db = new admin_mdhContext(_configuration))
                {
                    var ditAdmins = await db.DblkIusers
                        .Where(x => x.Igroup == 7 && x.Removed == false)
                        .ToListAsync();
                    foreach (var ditAdmin in ditAdmins)
                    {
                        var user = ditAdmin.ToMfcCornerUser();
                        if (adminRole != null)
                        {
                            user = await _userRepository.CreateUserAsync(user);
                            UserRole userRole = new UserRole
                            {
                                RoleId = adminRole.Id,
                                UserId = user.Id
                            };
                            
                            userRole = await _userRoleRepository.CreateUserRoleAsync(userRole);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private async Task InsertDITHeadOfDivisions()
        {
            try
            {
                var headRole = (await _roleRepository.GetAllRolesAsync()).
                    Where(x => x.Name == "HeadOfTheMfcDivision").FirstOrDefault();
                using (var db = new admin_mdhContext(_configuration))
                {
                    var ditHeadOfDivisions = await db.DblkIusers
                        .Where(x => x.Igroup == 5
                        && x.Removed == false
                        && x.Name != "admin1")
                        .ToListAsync();

                    foreach (var ditHeadOfDivision in ditHeadOfDivisions)
                    {
                        var user = ditHeadOfDivision.ToMfcCornerUser();
                        if (headRole != null)
                        {
                            var ditUserRole = await db.DblkIusersHasComplices
                                .Where(x => x.Iuser == ((int)ditHeadOfDivision.Id)).FirstOrDefaultAsync();

                            if (ditUserRole != null)
                            {
                                user = await _userRepository.CreateUserAsync(user);
                                var complex = await db.DblkComplices
                                .Where(x => x.Id == ditUserRole.Complex).FirstOrDefaultAsync();

                                if (complex != null)
                                {
                                    var mfcCorner = await _mfcCornerRepository.GetMfcByNameAsync(complex.Name);
                                    UserRole userRole = new UserRole
                                    {
                                        RoleId = headRole.Id,
                                        UserId = user.Id
                                    };

                                    userRole = await _userRoleRepository.CreateUserRoleAsync(userRole);

                                    var headOfDivision = new HeadOfDivision
                                    {
                                        DistrictId = mfcCorner.DistrictId,
                                        UserRoleId = userRole.Id
                                    };

                                    headOfDivision = await _headOfDivisionRepository.CreateHeadOfDivision(headOfDivision);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private async Task InsertDITHeadOFMfc()
        {
            try
            {
                var headRole = (await _roleRepository.GetAllRolesAsync()).Where(x => x.Name == "HeadOfMfc").FirstOrDefault();
                using (var db = new admin_mdhContext(_configuration))
                {
                    var ditHeadOFMfcs = await db.DblkIusers
                        .Where(x => x.Igroup == 6 && x.Removed == false)
                        .ToListAsync();
                    foreach (var ditHeadOfMfc in ditHeadOFMfcs)
                    {
                        var user = ditHeadOfMfc.ToMfcCornerUser();
                        if (headRole != null)
                        {
                            var ditUserRole = await db.DblkIusersHasComplices
                                .Where(x => x.Iuser == ((int)ditHeadOfMfc.Id)).FirstOrDefaultAsync();
                            if (ditUserRole != null)
                            {
                                var complex = await db.DblkComplices
                                    .Where(x => x.Id == ditUserRole.Complex).FirstOrDefaultAsync();
                                if (complex != null)
                                {
                                    var mfcCorner = await _mfcCornerRepository.GetMfcByNameAsync(complex.Name);
                                    user = await _userRepository.CreateUserAsync(user);
                                    var userRole = new UserRole
                                    {
                                        RoleId = headRole.Id,
                                        UserId = user.Id
                                    };

                                    userRole = await _userRoleRepository.CreateUserRoleAsync(userRole);
                                    var headOfMfc = new HeadOfMfc
                                    {
                                        MfcCornerId = mfcCorner.Id,
                                        UserRoleId = userRole.Id
                                    };
                                    
                                    headOfMfc = await _headOfMfcRepository.CreateHeadOfMfc(headOfMfc);
                                }
                            }
                            else
                            {
                                var adminRole = (await _roleRepository.GetAllRolesAsync()).Where(x => x.Name == "Admin").FirstOrDefault();
                                if (adminRole != null)
                                {
                                    user = await _userRepository.CreateUserAsync(user);
                                    var userRole = new UserRole
                                    {
                                        RoleId = adminRole.Id,
                                        UserId = user.Id
                                    };
                                    
                                    userRole = await _userRoleRepository.CreateUserRoleAsync(userRole);
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private async Task InsertDITMfcCorner()
        {
            try
            {
                List<MfcCorner> corners = new List<MfcCorner>();
                using (var db = new admin_mdhContext(_configuration))
                {
                    var districts = (await _districtRepository.GetAllDistrictsAsync(null, null, null)).Items;
                    var complexes = await db.DblkComplices.ToListAsync();
                    foreach (var complex in complexes)
                    {
                        string basePath = $"{complex.Name.Trim().Replace(" ", "_").CyrilicToLatin().ToLower()}-wss-proxy.mfchealth.ru";
                        MfcCorner corner = complex.ToMfcCorner(districts);
                        //
                        var result = await _mfcCornerRepository.CreateMfcAsync(corner);
                        //
                        corner.Id = result;
                        corners.Add(corner);
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
