using AzureDevOpsTeamMembersVelocity.Extensions;
using AzureDevOpsTeamMembersVelocity.Hubs;
using k8s;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MockK8s;
using System;
using System.Net.Http;
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
            builder.ConfigureServices((context, services) =>
            {
                // Mock kubernetes
                services.RemoveAll(typeof(IKubernetes));

                var k8sClient = K8sClientFactory.CreateClientForIntegrationTest(new TestOutputHelper());

                services.AddSingleton(sp => k8sClient);

                // Provide Func for SignlaR connections
                var webHostBuilder = new WebHostBuilder()
                    .ConfigureServices(services =>
                    {
                        services.AddAuthentication();

                        services.AddTeamMemberVelocityAutorisation(context.Configuration);

                        services.AddSingleton<IKubernetes>(k8sClient);

                        services.AddSignalR();
                    })
                    .Configure(app =>
                    {
                        app.UseRouting();

                        app.UseAuthentication();

                        app.UseAuthorization();

                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapHub<LogStreamHub>("/GetPodLog");
                            endpoints.MapHub<K8SHub>("/K8sHub");
                        });
                    });

                var server = new TestServer(webHostBuilder);

                services.AddSingleton<Func<HttpMessageHandler, HttpMessageHandler>>(_ => server.CreateHandler());
            });
        }
    }
}
