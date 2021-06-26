using AzureDevOpsTeamMembersVelocity.Data;
using AzureDevOpsTeamMembersVelocity.Extensions;
using AzureDevOpsTeamMembersVelocity.Proxy;
using AzureDevOpsTeamMembersVelocity.Repository;
using AzureDevOpsTeamMembersVelocity.Services;
using Blazored.Modal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web.UI;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using static System.Environment;

namespace AzureDevOpsTeamMembersVelocity
{
    /// <summary>
    /// The startup class uses to build the application.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configuration of the app. Use when AzureAD authentication method is used.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Constructor of the startup class with the configuration object in parameter
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            if (string.Equals(GetEnvironmentVariable("Forwarded_headers"), bool.TrueString, StringComparison.OrdinalIgnoreCase))
            {
                services.Configure<ForwardedHeadersOptions>(options =>
                {
                    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;

                    foreach (var network in GetEnvironmentVariable("KNOW_NETWORKS")?.Split(';') ?? Array.Empty<string>())
                    {
                        var ipInfo = network.Split("/");

                        options.KnownNetworks.Add(new IPNetwork(IPAddress.Parse(ipInfo[0]), int.Parse(ipInfo[1])));
                    }
                });
            }

            var mvcBuilder = services.AddRazorPages();
            if (AddAuthentificationExtension.IsAzureADAuth())
            {
                mvcBuilder.AddMvcOptions(options =>
                {
                    var policy = new AuthorizationPolicyBuilder()
                                  .RequireAuthenticatedUser()
                                  .Build();
                    options.Filters.Add(new AuthorizeFilter(policy));
                }).AddMicrosoftIdentityUI();
            }
            services.AddServerSideBlazor();
            services.AddBlazoredModal();

            services.AddTeamMemberVelocityAutorisation(Configuration);

            services.AddDataProtection()
                    .PersistKeysToFileSystem(new DirectoryInfo(Directory.GetCurrentDirectory()))
                    .SetApplicationName(nameof(AzureDevOpsTeamMembersVelocity));
            
            services.AddScoped(sp =>
            {
                var client = new HttpClient();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return client;
            });

            services.AddSingleton<TeamMembersVelocitySettings>();
            services.AddScoped<DevOpsProxy>();
            services.AddScoped<IDevOpsProxy, DevOpsProxyCache>();
            services.AddScoped<DevOpsService>();
            services.AddScoped<VelocityService>();
            services.AddScoped<GitService>();
            services.AddScoped<NugetService>();
            services.AddSingleton<IVelocityRepository, VelocityRepository>();
            services.AddSingleton<IUserPreferenceRepository, UserPreferenceRepository>();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider, ILogger<Startup> logger)
        {
            if ((! string.Equals(GetEnvironmentVariable("USE_STARTUP_MIGRATION"), bool.FalseString, StringComparison.OrdinalIgnoreCase)) &&
                   string.Equals(GetEnvironmentVariable("USE_IDENTITY"), bool.TrueString, StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    var database = serviceProvider.GetRequiredService<IdentityContext>();

                    database.Database.Migrate();
                }
                catch (Exception e)
                {
                    logger.LogCritical(e, "An error occure during the migration of the database. The app will be able to start.");

                    throw;
                }
            }

            if (string.Equals(GetEnvironmentVariable("OVERRIDE_SCHEMA_TO_HTTPS"), bool.TrueString, StringComparison.CurrentCultureIgnoreCase))
            {
                app.Use(async (context, next) =>
                {
                    context.Request.Scheme = "https";

                    await next();
                });
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                if (string.Equals(GetEnvironmentVariable("Forwarded_headers"), bool.TrueString, StringComparison.OrdinalIgnoreCase))
                {
                    app.UseForwardedHeaders();

                    if ((string.Equals(GetEnvironmentVariable("Debug_headers"), bool.TrueString, StringComparison.OrdinalIgnoreCase)))
                    {
                        app.Use(async (context, next) =>
                        {
                            //context.Response.ContentType = "text/plain";

                            // Request method, scheme, and path
                            logger.LogDebug("Request Method: {Method}", context.Request.Method);
                            logger.LogDebug("Request Scheme: {Scheme}", context.Request.Scheme);
                            logger.LogDebug("Request Path: {Path}", context.Request.Path);

                            // Headers
                            foreach (var header in context.Request.Headers)
                            {
                                logger.LogDebug("Header: {Key}: {Value}", header.Key, header.Value);
                            }

                            // Connection: RemoteIp
                            logger.LogDebug("Request RemoteIp: {RemoteIpAddress}",
                                context.Connection.RemoteIpAddress);

                            await next();
                        });
                    }
                }
            }
            else
            {
                app.UseExceptionHandler("/Error");
                
                if (string.Equals(GetEnvironmentVariable("Forwarded_headers"), bool.TrueString, StringComparison.OrdinalIgnoreCase))
                {
                    app.UseForwardedHeaders();

                    if (string.Equals(GetEnvironmentVariable("Debug_headers"), bool.TrueString, StringComparison.OrdinalIgnoreCase))
                    {
                        app.Use(async (context, next) =>
                        {
                            //context.Response.ContentType = "text/plain";

                            // Request method, scheme, and path
                            logger.LogDebug("Request Method: {Method}", context.Request.Method);
                            logger.LogDebug("Request Scheme: {Scheme}", context.Request.Scheme);
                            logger.LogDebug("Request Path: {Path}", context.Request.Path);

                            // Headers
                            foreach (var header in context.Request.Headers)
                            {
                                logger.LogDebug("Header: {Key}: {Value}", header.Key, header.Value);
                            }

                            // Connection: RemoteIp
                            logger.LogDebug("Request RemoteIp: {RemoteIpAddress}",
                                context.Connection.RemoteIpAddress);

                            await next();
                        });
                    }
                }

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Frame-Options", GetEnvironmentVariable("X-FRAME-OPTIONS") ?? "DENY");
                context.Response.Headers.Add("X-Content-Type-Options", GetEnvironmentVariable("X-Content-Type-Options") ?? "nosniff");
                await next();
            });

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
