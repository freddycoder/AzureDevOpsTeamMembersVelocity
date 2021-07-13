using k8s;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSubstitute;
using System.Linq;

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
