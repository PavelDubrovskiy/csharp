using Mfc.Health.Corner.Common;
using Mfc.Health.Corner.Domain.Models;
using Mfc.Health.Corner.Persistence.Data;
using Mfc.Health.Corner.Persistence.Migrations;
using Mfc.Health.Corner.Persistence.Repository.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Persistence.Init
{
    public class DbInitializer : IDbInitializer
    {
        private readonly IMigrationVersionInfoRepository _migrationVersionInfoRepository;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _appEnvironment;
        public MongoDBConfig _settings = null;
        private readonly DefaultAppsettingsUser _defaultAppsettingsUser = null;
        private readonly IUserRepository _userRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly DbContext _context = null;

        public DbInitializer(IOptions<MongoDBConfig> settings,
            IOptions<DefaultAppsettingsUser> defaultAppsettingsUser,
            IUserRepository userRepository,
            IWebHostEnvironment appEnvironment,
            IUserRoleRepository userRoleRepository,
            IRoleRepository roleRepository,
            IMigrationVersionInfoRepository migrationVersionInfoRepository,
            IOptions<MongoDBConfig> settingsOptions,
            IConfiguration configuration)
        {
            _appEnvironment = appEnvironment;
            _settings = settings.Value;
            _defaultAppsettingsUser = defaultAppsettingsUser.Value;
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _roleRepository = roleRepository;
            _migrationVersionInfoRepository = migrationVersionInfoRepository;
            _context = new DbContext(settingsOptions);
            _configuration = configuration;
        }


        public async Task InitMigrations(IServiceProvider serviceProvider)
        {
            try
            {
                var migrations = GetMigrations();

                if (migrations != null)
                {
                    var lastExecutedMigrationName = await GetLastDatabaseExecutedMigrationName();
                    if (!String.IsNullOrWhiteSpace(lastExecutedMigrationName))
                    {
                        var lastExecuted = migrations.Find(x => x.Name == lastExecutedMigrationName);
                        var startIndex = lastExecuted != null ? (migrations.IndexOf(lastExecuted)) + 1 : 0;
                        await ExecuteMigrations(migrations, serviceProvider, startIndex);
                    }
                    else
                    {
                        await ExecuteMigrations(migrations, serviceProvider, 0);
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

        }

        #region Migration methods

        private async Task ExecuteMigrations(List<MigrationData> migrations, IServiceProvider serviceProvider, int startindex)
        {
            try
            {
                for (int i = startindex; i < migrations.Count; i++)
                {
                    var migrationType = migrations[i].Type;
                    object[] args = new object[] { _settings, serviceProvider };
                    object migration = (BaseMigration)Activator.CreateInstance(migrationType, new object[] { _settings, serviceProvider });
                    await ((BaseMigration)migration).Up();
                    await _migrationVersionInfoRepository.CreateMigration(new MigrationVersionInfo
                    {
                        AppliedOn = DateTime.Now,
                        Name = migrationType.Name,
                        Version = (await _migrationVersionInfoRepository.GetMigrationCount()).ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private async Task<string> GetLastDatabaseExecutedMigrationName()
        {
            try
            {
                var versionCollection = CollectionExistsAsync("MigrationVersionInfo");
                if (versionCollection)
                {
                    var migration = await _migrationVersionInfoRepository.GetLastMigrationVersionInfo();
                    return migration.Name;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return null;
            }

        }

        private List<MigrationData> GetMigrations()
        {
            var exportedTypes = Assembly.GetAssembly(typeof(BaseMigration)).ExportedTypes;
            List<MigrationData> migrations = new List<MigrationData>();
            foreach (var type in exportedTypes)
            {
                if (type.GetTypeInfo().BaseType == typeof(BaseMigration))
                {
                    var migration = GetMigrationDataByMigrationType(type);
                    migrations.Add(migration);
                }
            }
            return migrations.Count == 0 ? null : migrations.OrderBy(x => x.CreationDate).ToList();
        }

        private MigrationData GetMigrationDataByMigrationType(Type type)
        {
            var datestring = type.Name.
                ToLower().TrimStart('m')
                .Insert(4, "-").Insert(7, "-")
                .Insert(10, " ").Insert(13, ":");
            DateTime migrastionDate = DateTime.ParseExact(datestring, "yyyy-MM-dd HH:mm",
                System.Globalization.CultureInfo.InvariantCulture);
            var data = new MigrationData
            {
                CreationDate = migrastionDate,
                Name = type.Name,
                Type = type
            };
            return data;
        }

        #endregion


        public async Task InitData()
        {
            try
            {

                if (bool.TryParse(_configuration["IsLocalMfcCorner"], out bool isLocalMfcCorner))
                {
                    if (!isLocalMfcCorner)
                    {
                        await InitDistricts();
                    }
                    await InitRoles();
                    await InitAppsettingsUser();
                }
                else
                {
                    throw new Exception("Configuration error. Server Type not specified");
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                throw;
            }
        }

        #region Data Initialization methods 

        private async Task InitRoles()
        {
            var roleCollection = CollectionExistsAsync("Roles");

            if (!roleCollection)
            {
                var path = _appEnvironment.WebRootPath;

                var rolesPath = Path.Combine(path, "Roles.json");

                var jsonString = System.IO.File.ReadAllText(rolesPath);

                var items = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(jsonString);

                var roles = items.Select(x => new Role() { Name = x });

                await _roleRepository.CreateRoleListAsync(roles.ToList());
            }

        }
        private async Task InitDistricts()
        {
            //var districtsCollection = CollectionExistsAsync("Districts");

            //if (!districtsCollection)
            //{
            var path = _appEnvironment.WebRootPath;

            var districtPath = Path.Combine(path, "Districts.json");

            var jsonString = File.ReadAllText(districtPath);

            var districts = Newtonsoft.Json.JsonConvert.DeserializeObject<List<District>>(jsonString);

            foreach (var district in districts)
            {
                var existedDistrict = await _context.Districts.Find(x => x.Id == district.Id).FirstOrDefaultAsync();
                if (existedDistrict == null)
                {
                    await _context.Districts.InsertOneAsync(district);
                }
            }
            //}
        }
        private async Task InitAppsettingsUser()
        {
            var usersCollection = CollectionExistsAsync("Users");
            if (_defaultAppsettingsUser != null)
            {
                if (!usersCollection)
                {
                    await CreateAppsettingsUser();
                }
                else
                {
                    var user = await _userRepository.GetUserByIdAsync(_defaultAppsettingsUser.Id);

                    if (user == null)
                    {
                        await CreateAppsettingsUser();
                    }
                    else
                    {
                        var currentUser = await _userRepository.GetUserByIdAsync(_defaultAppsettingsUser.Id);
                        currentUser.Email = _defaultAppsettingsUser.Email;
                        currentUser.Login = _defaultAppsettingsUser.Login;
                        currentUser.Password = BCrypt.Net.BCrypt.HashPassword(_defaultAppsettingsUser.Password);
                        await _userRepository.UpdateUserAsync(currentUser);
                    }
                }
            }
            else
            {
                throw new Exception("Configuration error. Default appsettings user not configured");
            }
        }
        private async Task CreateAppsettingsUser()
        {
            var user = new User
            {
                Id = _defaultAppsettingsUser.Id,
                Email = _defaultAppsettingsUser.Email,
                Login = _defaultAppsettingsUser.Login,
                Password = BCrypt.Net.BCrypt.HashPassword(_defaultAppsettingsUser.Password)
            };

            user = await _userRepository.CreateUserAsync(user);
            var superAdminRole =
                (await _roleRepository.GetRolesByRoleNamesAsync(new List<string> { "SuperAdmin" })).FirstOrDefault();

            var userRole = new UserRole
            {
                UserId = user.Id,
                RoleId = superAdminRole.Id
            };
            await _context.UserRoles.InsertOneAsync(userRole);
            await _userRepository.UpdateUserAsync(user);
        }

        #region not execited methods (Old)
        private async Task InitUsers()
        {
            var usersCollection = CollectionExistsAsync("Users");

            if (!usersCollection)
            {
                var path = _appEnvironment.WebRootPath;

                var userPath = Path.Combine(path, "Users.json");

                var jsonString = System.IO.File.ReadAllText(userPath);

                var userJson = Newtonsoft.Json.JsonConvert.DeserializeObject<UserJson>(jsonString);

                var passwordHash = PasswordHasher.HashPassword(userJson.Password);

                var user = new User
                {
                    Email = userJson.Email,
                    Login = userJson.Login,
                    Password = passwordHash,
                };

                user = await _userRepository.CreateUserAsync(user);

                var roles = await _roleRepository.GetRolesByRoleNamesAsync(userJson.RoleNames);

                var rolesId = roles.Select(x => x.Id).ToList();

                var userRoles = rolesId.Select(x => new UserRole() { UserId = user.Id, RoleId = x });

                foreach (var userRole in userRoles)
                {
                    await _context.UserRoles.InsertOneAsync(userRole);
                }

                await _userRepository.UpdateUserAsync(user);
            }
        }
        private async Task InitMedExamMailSegments()
        {

            var path = _appEnvironment.WebRootPath;

            var medExamMailSegmentPath = Path.Combine(path, "MedExamMailSegment.json");

            var medExamMailSegmentString = File.ReadAllText(medExamMailSegmentPath);

            var medExamMailSegments = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MedExamMailSegment>>(medExamMailSegmentString);

            var medExamMailSegmentCollection = CollectionExistsAsync("MedExamMailSegments");

            if (!medExamMailSegmentCollection)
            {
                foreach (var medExamMailSegment in medExamMailSegments)
                {
                    await _context.MedExamMailSegments.InsertOneAsync(medExamMailSegment);
                }
            }
            else
            {
                foreach (var medExamMailSegment in medExamMailSegments)
                {
                    var currentSegment = await _context.MedExamMailSegments
                    .Find(x => x.SegmentName == medExamMailSegment.SegmentName)
                    .FirstOrDefaultAsync();
                    if (currentSegment != null)
                    {
                        await _context.MedExamMailSegments
                            .ReplaceOneAsync(x => x.SegmentName == medExamMailSegment.SegmentName, medExamMailSegment);
                    }
                    else
                    {
                        await _context.MedExamMailSegments.InsertOneAsync(medExamMailSegment);
                    }
                }
            }
        }

        #endregion

        #endregion


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
