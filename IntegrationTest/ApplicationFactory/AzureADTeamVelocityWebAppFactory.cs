using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace IntegrationTest.ApplicationFactory
{
    public class AzureADTeamVelocityWebAppFactory<TStartup> : TeamVelocityWebAppFactory<TStartup> where TStartup : class
    {
        protected override IHostBuilder CreateHostBuilder()
        {
            return base.CreateHostBuilder()
                       .ConfigureHostConfiguration(config =>
                       {
                            config.AddCommandLine(new[]
                           {
                               $"AzureAD:ClientId={Guid.NewGuid()}",
                               $"AzureAD:TenantId={Guid.NewGuid()}"
                           });
                       });
        }
    }
}
