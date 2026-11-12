using System.Reflection;
using Mfc.Health.Corner.Application.Handlers;
using Mfc.Health.Corner.WebSockets.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Mfc.Health.Corner.Api.Middleware
{
    public static class WebSocketManagerExtensions
    {
        public static IServiceCollection AddWebSocketManager(this IServiceCollection services)
        {
            //services.AddTransient<ConnectionManager>();
            var exportedTypes = Assembly.GetAssembly(typeof(WebSocketHandler)).ExportedTypes;
            foreach (var type in exportedTypes)
            {
                if (type.GetTypeInfo().BaseType == typeof(WebSocketHandler))
                {
                    services.AddSingleton(type);
                }
            }

            return services;
        }

        public static IApplicationBuilder MapWebSocketManager(this IApplicationBuilder app,
            PathString path,
            WebSocketHandler handler)
        {
            return app.Map(path, (_app) => _app.UseMiddleware<WebSocketManagerMiddleware>(handler));
        }
    }
}