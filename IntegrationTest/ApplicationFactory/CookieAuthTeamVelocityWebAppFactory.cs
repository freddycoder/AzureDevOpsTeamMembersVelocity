using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace IntegrationTest.ApplicationFactory
{
    public class CookieAuthTeamVelocityWebAppFactory<TStartup> : TeamVelocityWebAppFactory<TStartup> where TStartup : class
    {
        protected override IHostBuilder CreateHostBuilder()
        {
            return base.CreateHostBuilder()
                       .ConfigureHostConfiguration(config =>
                       {
                           config.AddCommandLine(new[] 
                           { 
                               "COOKIEAUTH_USER=test@integ.com" ,
                               "COOKIEAUTH_PASSWORD=123"
                           });
                       });
        }
    }
}
