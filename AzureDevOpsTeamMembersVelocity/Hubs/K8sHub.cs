using AzureDevOpsTeamMembersVelocity.Model;
using k8s;
using k8s.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
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

        /// <summary>
        /// Constructor with dependencies
        /// </summary>
        /// <param name="client"></param>
        public K8sHub(IKubernetes client)
        {
            _kubernetesClient = client;
        }

        /// <summary>
        /// Get namespaces and watch for changes
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async IAsyncEnumerable<Pair<WatchEventType?, V1Namespace>> Namespaces([EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var initialNamespaces = await _kubernetesClient.ListNamespaceAsync(cancellationToken: cancellationToken);

            foreach (var n in initialNamespaces.Items)
            {
                yield return new (null, n);
            }

            var watcher = _kubernetesClient.ListNamespaceWithHttpMessagesAsync(watch: true, cancellationToken: cancellationToken);

            await foreach (var (type, item) in watcher.WatchAsync<V1Namespace, V1NamespaceList>())
            {
                yield return new(type, item);
            }
        }

        /// <summary>
        /// Get deployments list and watch deployments for change
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async IAsyncEnumerable<Pair<WatchEventType?, V1Deployment>> Deployments([EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var initialNamespaces = await _kubernetesClient.ListDeploymentForAllNamespacesAsync(cancellationToken: cancellationToken);

            foreach (var n in initialNamespaces.Items)
            {
                yield return new (null, n);
            }

            var watcher = _kubernetesClient.ListDeploymentForAllNamespacesWithHttpMessagesAsync(watch: true, cancellationToken: cancellationToken);

            await foreach (var (type, item) in watcher.WatchAsync<V1Deployment, V1DeploymentList>())
            {
                yield return new(type, item);
            }
        }

        /// <summary>
        /// Get pods list and watch pods for changes
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async IAsyncEnumerable<Pair<WatchEventType?, V1Pod>> Pods([EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var initialNamespaces = await _kubernetesClient.ListPodForAllNamespacesAsync(cancellationToken: cancellationToken);

            foreach (var n in initialNamespaces.Items)
            {
                yield return new (null, n);
            }

            var watcher = _kubernetesClient.ListPodForAllNamespacesWithHttpMessagesAsync(watch: true, cancellationToken: cancellationToken);

            await foreach (var (type, item) in watcher.WatchAsync<V1Pod, V1PodList>())
            {
                yield return new(type, item);
            }
        }
    }
}
