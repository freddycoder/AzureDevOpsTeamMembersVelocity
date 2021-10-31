using AzureDevOpsTeamMembersVelocity.Model;
using k8s;
using k8s.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace AzureDevOpsTeamMembersVelocity.Hubs
{
    /// <summary>
    /// K8sHub to get informations and get notify for changes
    /// </summary>
    [Authorize]
    public class K8sHub : Hub
    {
        private readonly IKubernetes _kubernetesClient;
        private readonly ILogger<K8sHub> _logger;

        /// <summary>
        /// Constructor with dependencies
        /// </summary>
        /// <param name="client"></param>
        /// <param name="logger"></param>
        public K8sHub(IKubernetes client, ILogger<K8sHub> logger)
        {
            _kubernetesClient = client;
            _logger = logger;
        }

        /// <summary>
        /// Get namespaces and watch for changes
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async IAsyncEnumerable<Pair<WatchEventType?, V1Namespace>> Namespaces([EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var watcher = _kubernetesClient.ListNamespaceWithHttpMessagesAsync(watch: true, cancellationToken: cancellationToken);

            await foreach (var (type, item) in watcher.WatchAsync<V1Namespace, V1NamespaceList>())
            {
                yield return new(type, item);
            }

            _logger.LogInformation($"Method {nameof(Namespaces)} is done");
        }

        /// <summary>
        /// Get deployments list and watch deployments for change
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async IAsyncEnumerable<Pair<WatchEventType?, V1Deployment>> Deployments([EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var watcher = _kubernetesClient.ListDeploymentForAllNamespacesWithHttpMessagesAsync(watch: true, cancellationToken: cancellationToken);

            await foreach (var (type, item) in watcher.WatchAsync<V1Deployment, V1DeploymentList>())
            {
                yield return new(type, item);
            }

            _logger.LogInformation($"Method {nameof(Deployments)} is done");
        }

        /// <summary>
        /// Get pods list and watch pods for changes
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async IAsyncEnumerable<Pair<WatchEventType?, V1Pod>> Pods([EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var watcher = _kubernetesClient.ListPodForAllNamespacesWithHttpMessagesAsync(watch: true, cancellationToken: cancellationToken);

            await foreach (var (type, item) in watcher.WatchAsync<V1Pod, V1PodList>())
            {
                yield return new(type, item);
            }

            _logger.LogInformation($"Method {nameof(Pods)} is done");
        }
    }
}
