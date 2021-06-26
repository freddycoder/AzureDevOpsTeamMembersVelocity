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
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web.UI;
using System;
using System.IO;
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
            services.AddScoped<IDevOpsProxy, DevOpsProxy>();
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
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
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
                    var logger = serviceProvider.GetRequiredService<ILogger<Startup>>();

                    logger.LogCritical(e, "An error occure during the migration of the database. The app will be able to start.");

                    throw;
                }
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
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
