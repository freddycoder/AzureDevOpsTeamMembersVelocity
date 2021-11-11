using k8s;
using k8s.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Nito.AsyncEx;
using System.Linq;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace MockK8s
{
    public static class K8SClientFactory
    {
        private static readonly string AddedNamespaceStreamLine = BuildWatchEventStreamLine(WatchEventType.Added, MockKubeApiServer.MockNamespaceResponse);
        private static readonly string AddedDeploymentStreamLine = BuildWatchEventStreamLine(WatchEventType.Added, MockKubeApiServer.MockDeploymentReponse);
        private static readonly string AddedPodStreamLine = BuildWatchEventStreamLine(WatchEventType.Added, MockKubeApiServer.MockPodResponse);

        public static IKubernetes CreateClientForIntegrationTest(ITestOutputHelper? testOutput = null)
        {
            var created = new AsyncManualResetEvent(false);

            var server = new MockKubeApiServer(testOutput,
            async httpContext =>
            {
                // block until reponse watcher obj created
                await created.WaitAsync().ConfigureAwait(false);
                await WriteStreamLine(httpContext, AddedNamespaceStreamLine).ConfigureAwait(false);
                await WriteStreamLine(httpContext, AddedDeploymentStreamLine).ConfigureAwait(false);
                await WriteStreamLine(httpContext, AddedPodStreamLine).ConfigureAwait(false);
                return false;
            });

            var client = new Kubernetes(new KubernetesClientConfiguration 
            { 
                Host = server.Uri.ToString() 
            });

            return client;
        }

        private static string BuildWatchEventStreamLine(WatchEventType eventType, string response)
        {
            var corev1PodList = JsonConvert.DeserializeObject<V1PodList>(response);
            return JsonConvert.SerializeObject(
                new Watcher<V1Pod>.WatchEvent { Type = eventType, Object = corev1PodList.Items.First() },
                new StringEnumConverter());
        }

        private static async Task WriteStreamLine(HttpContext httpContext, string reponseLine)
        {
            const string crlf = "\r\n";
            await httpContext.Response.WriteAsync(reponseLine.Replace(crlf, "")).ConfigureAwait(false);
            await httpContext.Response.WriteAsync(crlf).ConfigureAwait(false);
            await httpContext.Response.Body.FlushAsync().ConfigureAwait(false);
        }
    }
}
