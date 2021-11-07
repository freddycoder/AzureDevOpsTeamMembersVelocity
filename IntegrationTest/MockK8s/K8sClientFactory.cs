using k8s;
using Xunit.Abstractions;

namespace IntegrationTest.MockK8s
{
    public static class K8sClientFactory
    {
        public static IKubernetes CreateClientForIntegrationTest(ITestOutputHelper testOutput)
        {
            var server = new MockKubeApiServer(testOutput);

            var client = new Kubernetes(new KubernetesClientConfiguration { Host = server.Uri.ToString() });

            return client;
        }
    }
}
