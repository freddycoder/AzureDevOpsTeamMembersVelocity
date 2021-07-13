using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RichardSzalay.MockHttp;
using System;
using System.Linq;

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

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);

            builder.ConfigureServices(services =>
            {
                var descriptor = services.Single(d => d.ServiceType == typeof(OpenIdConnectHandler));

                services.Remove(descriptor);

                var open = services.AddTransient<OpenIdConnectHandler>(sp => 
                {
                    var option = sp.GetRequiredService<IOptionsMonitor<OpenIdConnectOptions>>();

                    var handler = new MockHttpMessageHandler();

                    option.CurrentValue.Backchannel = new System.Net.Http.HttpClient(handler);

                    return new OpenIdConnectHandler(
                        option,
                        sp.GetRequiredService<ILoggerFactory>(),
                        System.Text.Encodings.Web.HtmlEncoder.Default,
                        System.Text.Encodings.Web.UrlEncoder.Default,
                        sp.GetRequiredService<ISystemClock>());
                });
            });
        }
    }
}
