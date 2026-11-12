using Mfc.Health.Corner.Domain.Models;
using Mfc.Health.Corner.Persistence.Data;
using Mfc.Health.Corner.Persistence.Repository.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Persistence.Migrations
{
    public abstract class BaseMigration : IBaseMigration
    {
        protected readonly MongoDBConfig _settings = null;
       // protected readonly IServiceProvider _serviceProvider;
        public BaseMigration(
           MongoDBConfig settings,
            IServiceProvider serviceProvider
            ) 
        {
            _settings = settings;
           // _serviceProvider = serviceProvider;
        }

        public abstract Task Up();
        public abstract Task Down();

    }
}
