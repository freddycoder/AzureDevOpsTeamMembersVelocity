using AzureDevOpsTeamMembersVelocity.Extensions;
using AzureDevOpsTeamMembersVelocity.Hubs;
using AzureDevOpsTeamMembersVelocity.Model;
using k8s;
using k8s.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using MockK8s;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace IntegrationTest.Hubs
{
    public class HubCommunicationTest
    {
        [Fact]
        public async Task SignlaRTestSetup()
        {
            // Test setup to call SignalR Hub
            var webHostBuilder = new WebHostBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddAuthentication();

                    services.AddTeamMemberVelocityAutorisation(context.Configuration);
                    
                    services.AddSingleton<IKubernetes>(K8sClientFactory.CreateClientForIntegrationTest(new TestOutputHelper()));

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

            var connection = new HubConnectionBuilder()
                .WithUrl(
                    "http://localhost/K8sHub",
                    o => o.HttpMessageHandlerFactory = _ => server.CreateHandler())
                .Build();

            await connection.StartAsync();

            var channel = await connection.StreamAsChannelAsync<Pair<WatchEventType?, V1Namespace>>("Namespaces");

            Assert.True(channel.CanCount);
        }
    }
}
