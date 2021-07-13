using AzureDevOpsTeamMembersVelocity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace IntegrationTest.ApplicationFactory
{
    public class MicrosoftIdentityTeamVelocityWebAppFactory<TStartup> : TeamVelocityWebAppFactory<TStartup> where TStartup : class
    {
        protected override IHostBuilder CreateHostBuilder()
        {
            return base.CreateHostBuilder()
                       .ConfigureHostConfiguration(config =>
                       {
                           config.AddCommandLine(new[]
                           {
                               "USE_IDENTITY=true"
                           });
                       });
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);

            builder.ConfigureServices(services =>
            {
                var descriptor = services.Single(d => d.ServiceType == typeof(DbContextOptions<IdentityContext>));

                services.Remove(descriptor);

                services.AddDbContext<IdentityContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                });

                var sp = services.BuildServiceProvider();

                using var scope = sp.CreateScope();

                var scopedServices = scope.ServiceProvider;

                var db = scopedServices.GetRequiredService<IdentityContext>();

                var logger = scopedServices.GetRequiredService<ILogger<MicrosoftIdentityTeamVelocityWebAppFactory<TStartup>>>();

                db.Database.EnsureCreated();

                try
                {
                    // Feed the database if needed
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred seeding the " +
                        "database with test messages. Error: {Message}", ex.Message);
                }
            });
        }
    }
}
