using Mfc.Health.Corner.Persistence.Init;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;

namespace Mfc.Health.Corner.Api.Filter
{
    public class AutomaticDataInitStartupFilter : IStartupFilter
    {
        private readonly IDbInitializer _dbInitializer;

        public AutomaticDataInitStartupFilter(IDbInitializer dbInitializer)
        {
            _dbInitializer = dbInitializer;
        }

        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                _dbInitializer.InitData();
                _dbInitializer.InitMigrations(app.ApplicationServices);
                next(app);
            };
        }
    }
}

