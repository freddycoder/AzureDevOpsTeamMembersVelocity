using k8s;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Xunit.Sdk;

namespace IntegrationTest.ApplicationFactory
{
    public class TeamVelocityWebAppFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        /// <summary>
        /// Use to apply configuration after the Startup class ConfigureServices has been called.
        /// </summary>
        /// <remarks>
        /// Microsoft documentation: https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-5.0#customize-webapplicationfactory
        /// </remarks>
        /// <param name="builder"></param>
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.Single(d => d.ServiceType == typeof(IKubernetes));

                services.Remove(descriptor);

                services.AddSingleton<IKubernetes>(sp => MockK8s.K8sClientFactory.CreateClientForIntegrationTest(new TestOutputHelper()));
            });
        }
    }
}
