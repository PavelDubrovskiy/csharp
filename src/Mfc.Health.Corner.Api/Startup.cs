using Mfc.Health.Corner.Api.Middleware;
using Mfc.Health.Corner.Application;
using Mfc.Health.Corner.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using Mfc.Health.Corner.RabbitMqMessager.Models;
using Mfc.Health.Corner.RabbitMqMessager.ReceiveServices.Interfaces;
using System;
using Mfc.Health.Corner.RabbitMqMessager.DI;
using Mfc.Health.Corner.WebSockets.Handlers;
using Mfc.Health.Corner.Application.Handlers;
using System.Linq;
using Mfc.Health.Corner.ZabbixIntegration.DI;
using System.Reflection;
using System.IO;

namespace Mfc.Health.Corner.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);



            services.AddApplicationModule(Configuration);
            services.AddRabbitModules(Configuration);
            services.AddZabbixIntegrationModules(Configuration);


            services.AddWebSocketManager();

            services.Configure<WebSiteLinks>(
                Configuration.GetSection(nameof(WebSiteLinks)));

            services.Configure<ApplicationSettings>(
                Configuration.GetSection(nameof(ApplicationSettings)));

            services.Configure<EmailSettings>(
                Configuration.GetSection(nameof(EmailSettings)));

            services.Configure<ExamResultSendMailSettings>(
                Configuration.GetSection(nameof(ExamResultSendMailSettings)));

            services.Configure<TelegramBotSettings>(
                Configuration.GetSection(nameof(TelegramBotSettings)));

            services.Configure<SendStatusInfoSettings>(
                Configuration.GetSection(nameof(SendStatusInfoSettings)));

            services.Configure<WebSocketsSettings>(
                Configuration.GetSection(nameof(WebSocketsSettings)));

            services.Configure<RammitMqSettings>(
                Configuration.GetSection(nameof(RammitMqSettings)));

            var authOptionsConfiguration = Configuration.GetSection("Auth");

            services.Configure<AuthOptions>(authOptionsConfiguration);

            var autOp = Configuration.GetSection("Auth").Get<AuthOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = autOp.Issuer,
                        ValidateAudience = true,
                        ValidAudience = autOp.Audience,
                        ValidateLifetime = true,
                        IssuerSigningKey = autOp.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true,
                    };
                });

            var origins = this.Configuration.GetSection("OriginPathBases")?.GetChildren()?.Select(x => x.Value)?.ToArray() ?? null;
            if (origins != null && origins.Length > 0)
            {
                services.AddCors(options =>
                {
                    options.AddPolicy("CorsPolicy",
                        builder => builder.WithOrigins(origins)
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials());
                });
            }
            else
            {
                services.AddCors(options =>
                {
                    options.AddPolicy("CorsPolicy",
                        builder => builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader());
                });
            }



            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

               

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                },
                                Scheme = "oauth2",
                                Name = "Bearer",
                                In = ParameterLocation.Header,

                            },
                            new List<string>()
                        }
                    });

                c.SwaggerDoc("v1", new OpenApiInfo 
                { Title = "Mfc.Health.Corner.Api",
                    Version = "v1",
                    Description = "Mfc.Health.Corner API"
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.EnableAnnotations();
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime hostApplicationLifetime)
        {
            var serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            var serviceProvider = serviceScopeFactory.CreateScope().ServiceProvider;

            var mfcCornerInitializationReceiveService = serviceProvider.GetRequiredService<IMfcCornerInitializationReceiveService>();
            var mfcCornerReceiveService = serviceProvider.GetRequiredService<IMfcCornerReceiveService>();
            var districtReceiveService = serviceProvider.GetRequiredService<IDistrictReceiveService>();
            var userMedicalExaminationReceiveService = serviceProvider.GetRequiredService<IUserMedicalExaminationReceiveService>();
            var commandDeviceReceiveService = serviceProvider.GetRequiredService<ICommandDeviceReceiveService>();
            var mfcCorenerStatisticPerDayReceiveService = serviceProvider.GetRequiredService<IMfcCorenerStatisticPerDayReceiveService>();

            if (bool.TryParse(Configuration["IsLocalMfcCorner"], out bool isLocalMfcCorner))
            {
                hostApplicationLifetime.ApplicationStarted.Register(() =>
                {
                    if (isLocalMfcCorner)
                    {
                        mfcCornerInitializationReceiveService.Start();
                        mfcCornerReceiveService.Start();
                        districtReceiveService.Start();
                        commandDeviceReceiveService.Start();
                    }
                    else
                    {
                        userMedicalExaminationReceiveService.Start();
                        mfcCorenerStatisticPerDayReceiveService.Start();
                    }

                });
                hostApplicationLifetime.ApplicationStopping.Register(() =>
                {
                    if (isLocalMfcCorner)
                    {
                        mfcCornerInitializationReceiveService.Stop();
                        mfcCornerReceiveService.Stop();
                        districtReceiveService.Stop();
                        commandDeviceReceiveService.Stop();
                    }
                    else
                    {
                        userMedicalExaminationReceiveService.Stop();
                        mfcCorenerStatisticPerDayReceiveService.Stop();
                    }
                });
            }
            else
            {
                throw new ApplicationException("Configuration error. Server Type not specified");
            }

            app.UseWebSockets();

            app.MapWebSocketManager(
                Configuration.GetSection(nameof(WebSocketsSettings))
                .GetSection(nameof(WebSocketsSettings.SendCommandDeviceStatusPathBase)).Value /* "/getEquipmentCondition"*/,
                serviceProvider.GetService<EquipmentConditionMonitoringHandler>());

            app.MapWebSocketManager(
                Configuration.GetSection(nameof(WebSocketsSettings))
                .GetSection(nameof(WebSocketsSettings.StartExaminationPathBase)).Value   /*"/testStart"*/,
                serviceProvider.GetService<StartTestHandler>()
                );

            app.MapWebSocketManager(
               Configuration.GetSection(nameof(WebSocketsSettings))
               .GetSection(nameof(WebSocketsSettings.CircleDiagramUpdate)).Value   /*"/dashboard/CircleDiagramUpdate"*/,
               serviceProvider.GetService<CircleDiagramUpdateHandler>()
               );

            app.MapWebSocketManager(
               Configuration.GetSection(nameof(WebSocketsSettings))
               .GetSection(nameof(WebSocketsSettings.MfcPopularityDataUpdate)).Value   /*"/dashboard/MfcPopularityDataUpdate"*/,
               serviceProvider.GetService<MfcPopularityDataUpdateHandler>()
               );

            app.MapWebSocketManager(
               Configuration.GetSection(nameof(WebSocketsSettings))
               .GetSection(nameof(WebSocketsSettings.ResearchDynamicsUpdate)).Value   /*"/dashboard/ResearchDynamicsUpdate"*/,
               serviceProvider.GetService<ResearchDynamicsUpdateHandler>()
               );

            app.MapWebSocketManager(
                Configuration.GetSection(nameof(WebSocketsSettings))
                .GetSection(nameof(WebSocketsSettings.StockDiagramByMedDeviceUpdate)).Value   /*"/dashboard/StockDiagramByMedDeviceUpdate"*/,
                serviceProvider.GetService<StockDiagramByMedDeviceUpdateHandler>()
                );

            app.MapWebSocketManager(
                Configuration.GetSection(nameof(WebSocketsSettings))
                .GetSection(nameof(WebSocketsSettings.CheckNetworkConnection)).Value /* "/isAvaliableNetworkConnection"*/,
                serviceProvider.GetService<NetworkConnectionMonitoringHandler>());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger(c =>
                {
                    c.SerializeAsV2 = true;
                });
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mfc.Health.Corner.Api v1"));
            }
            else
            {
                //app.UseHttpsRedirection();
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireCors("CorsPolicy"); ;
            });

            Console.WriteLine($"!!!! Application Started !!!!!!");
        }
    }
}
