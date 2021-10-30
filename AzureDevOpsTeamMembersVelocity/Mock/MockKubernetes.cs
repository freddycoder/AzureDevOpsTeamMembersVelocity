using k8s;
using k8s.Models;
using Microsoft.Rest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace AzureDevOpsTeamMembersVelocity.Mock
{
    /// <summary>
    /// Implementation of IKubernetes for devlopping the app in environment
    /// without access to kubernetes cluster
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class MockKubernetes : IKubernetes
    {
        // Custom mocking
        private V1NamespaceList _namespaceList = new()
        {
            Items = new List<V1Namespace>
            {
                NewNamespace("MockNamespace1"),
                NewNamespace("MockNamespace2"),
                NewNamespace("MockNamespace3")
            }
        };

        private static V1Namespace NewNamespace(string name)
        {
            return new V1Namespace(V1Namespace.KubeApiVersion, V1Namespace.KubeKind, new V1ObjectMeta
            {
                Name = name,
                CreationTimestamp = DateTime.Now
            }, new V1NamespaceSpec(), new V1NamespaceStatus
            {
                Phase = "Ready"
            });
        }

        private V1DeploymentList _deploymentList = new V1DeploymentList
        {
            Items = new List<V1Deployment>
            {
                NewDeployment("MockDeployment1"),
                NewDeployment("MockDeployment2"),
                NewDeployment("MockDeployment3"),
            }
        };

        private static V1Deployment NewDeployment(string name)
        {
            return new V1Deployment(V1Namespace.KubeApiVersion, V1Namespace.KubeKind, new V1ObjectMeta
            {
                Name = name,
                NamespaceProperty = "MockNamespace1",
                CreationTimestamp = DateTime.Now
            }, null, new V1DeploymentStatus
            {
                
            });
        }

        private V1PodList _podList = new V1PodList
        {
            Items = new List<V1Pod>()
        };

        private CancellationTokenSource _tokenSource = new CancellationTokenSource();

        private Task _backgroundProcess;

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public MockKubernetes()
        {
            var token = _tokenSource.Token;

            _backgroundProcess = Task.Run(async () =>
            {
                while (!token.IsCancellationRequested)
                {
                    await Task.Delay(10000, token);

                    _deploymentList.Items.RemoveAt(0);

                    _deploymentList.Items.Add(NewDeployment($"MockDeployment-{Guid.NewGuid()}"));
                }
            }, token);
        }

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _tokenSource.Cancel();

                    try
                    {
                        _backgroundProcess.Wait();
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine(e.Message);
                        Console.Error.WriteLine(e.StackTrace);
                    }
                }

                _backgroundProcess.Dispose();
                _tokenSource.Dispose();
                disposedValue = true;
            }
        }

        void IDisposable.Dispose()
        {
            // Ne changez pas ce code. Placez le code de nettoyage dans la méthode 'Dispose(bool disposing)'
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        // Implementation of IKubernetes

        public Uri BaseUri { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public JsonSerializerSettings SerializationSettings => throw new NotImplementedException();

        public JsonSerializerSettings DeserializationSettings => throw new NotImplementedException();

        public ServiceClientCredentials Credentials => throw new NotImplementedException();

        public HttpClient HttpClient => throw new NotImplementedException();

        public Task<HttpOperationResponse<string>> GetServiceAccountIssuerOpenIDConfigurationWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIVersions>> GetAPIVersionsWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIGroupList>> GetAPIVersions1WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIResourceList>> GetAPIResourcesWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIResourceList>> GetAPIResources1WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIResourceList>> GetAPIResources2WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIResourceList>> GetAPIResources3WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIResourceList>> GetAPIResources4WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIResourceList>> GetAPIResources5WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIResourceList>> GetAPIResources6WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIResourceList>> GetAPIResources7WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIResourceList>> GetAPIResources8WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIResourceList>> GetAPIResources9WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIResourceList>> GetAPIResources10WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIResourceList>> GetAPIResources11WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIResourceList>> GetAPIResources12WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIResourceList>> GetAPIResources13WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIResourceList>> GetAPIResources14WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIResourceList>> GetAPIResources15WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIResourceList>> GetAPIResources16WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIResourceList>> GetAPIResources17WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIResourceList>> GetAPIResources18WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIResourceList>> GetAPIResources19WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIResourceList>> GetAPIResources20WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIResourceList>> GetAPIResources21WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIResourceList>> GetAPIResources22WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIResourceList>> GetAPIResources23WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIResourceList>> GetAPIResources24WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIResourceList>> GetAPIResources25WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIResourceList>> GetAPIResources26WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIResourceList>> GetAPIResources27WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIResourceList>> GetAPIResources28WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIResourceList>> GetAPIResources29WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIResourceList>> GetAPIResources30WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIResourceList>> GetAPIResources31WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIResourceList>> GetAPIResources32WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ComponentStatusList>> ListComponentStatusWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ComponentStatus>> ReadComponentStatusWithHttpMessagesAsync(string name, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ConfigMapList>> ListConfigMapForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1EndpointsList>> ListEndpointsForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Corev1EventList>> ListEventForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Eventsv1EventList>> ListEventForAllNamespaces1WithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1EventList>> ListEventForAllNamespaces2WithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1LimitRangeList>> ListLimitRangeForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1NamespaceList>> ListNamespaceWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(new HttpOperationResponse<V1NamespaceList>
            {
                Body = _namespaceList
            });
        }

        public Task<HttpOperationResponse<V1Namespace>> CreateNamespaceWithHttpMessagesAsync(V1Namespace body, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Binding>> CreateNamespacedBindingWithHttpMessagesAsync(V1Binding body, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionNamespacedConfigMapWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ConfigMapList>> ListNamespacedConfigMapWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ConfigMap>> CreateNamespacedConfigMapWithHttpMessagesAsync(V1ConfigMap body, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteNamespacedConfigMapWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ConfigMap>> ReadNamespacedConfigMapWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ConfigMap>> PatchNamespacedConfigMapWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ConfigMap>> ReplaceNamespacedConfigMapWithHttpMessagesAsync(V1ConfigMap body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionNamespacedEndpointsWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1EndpointsList>> ListNamespacedEndpointsWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Endpoints>> CreateNamespacedEndpointsWithHttpMessagesAsync(V1Endpoints body, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteNamespacedEndpointsWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Endpoints>> ReadNamespacedEndpointsWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Endpoints>> PatchNamespacedEndpointsWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Endpoints>> ReplaceNamespacedEndpointsWithHttpMessagesAsync(V1Endpoints body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionNamespacedEventWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionNamespacedEvent1WithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionNamespacedEvent2WithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Corev1EventList>> ListNamespacedEventWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Eventsv1EventList>> ListNamespacedEvent1WithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1EventList>> ListNamespacedEvent2WithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Corev1Event>> CreateNamespacedEventWithHttpMessagesAsync(Corev1Event body, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Eventsv1Event>> CreateNamespacedEvent1WithHttpMessagesAsync(Eventsv1Event body, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1Event>> CreateNamespacedEvent2WithHttpMessagesAsync(V1beta1Event body, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteNamespacedEventWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteNamespacedEvent1WithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteNamespacedEvent2WithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Corev1Event>> ReadNamespacedEventWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Eventsv1Event>> ReadNamespacedEvent1WithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1Event>> ReadNamespacedEvent2WithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Corev1Event>> PatchNamespacedEventWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Eventsv1Event>> PatchNamespacedEvent1WithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1Event>> PatchNamespacedEvent2WithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Corev1Event>> ReplaceNamespacedEventWithHttpMessagesAsync(Corev1Event body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Eventsv1Event>> ReplaceNamespacedEvent1WithHttpMessagesAsync(Eventsv1Event body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1Event>> ReplaceNamespacedEvent2WithHttpMessagesAsync(V1beta1Event body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionNamespacedLimitRangeWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1LimitRangeList>> ListNamespacedLimitRangeWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1LimitRange>> CreateNamespacedLimitRangeWithHttpMessagesAsync(V1LimitRange body, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteNamespacedLimitRangeWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1LimitRange>> ReadNamespacedLimitRangeWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1LimitRange>> PatchNamespacedLimitRangeWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1LimitRange>> ReplaceNamespacedLimitRangeWithHttpMessagesAsync(V1LimitRange body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionNamespacedPersistentVolumeClaimWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PersistentVolumeClaimList>> ListNamespacedPersistentVolumeClaimWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PersistentVolumeClaim>> CreateNamespacedPersistentVolumeClaimWithHttpMessagesAsync(V1PersistentVolumeClaim body, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PersistentVolumeClaim>> DeleteNamespacedPersistentVolumeClaimWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PersistentVolumeClaim>> ReadNamespacedPersistentVolumeClaimWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PersistentVolumeClaim>> PatchNamespacedPersistentVolumeClaimWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PersistentVolumeClaim>> ReplaceNamespacedPersistentVolumeClaimWithHttpMessagesAsync(V1PersistentVolumeClaim body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PersistentVolumeClaim>> ReadNamespacedPersistentVolumeClaimStatusWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PersistentVolumeClaim>> PatchNamespacedPersistentVolumeClaimStatusWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PersistentVolumeClaim>> ReplaceNamespacedPersistentVolumeClaimStatusWithHttpMessagesAsync(V1PersistentVolumeClaim body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionNamespacedPodWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PodList>> ListNamespacedPodWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(new HttpOperationResponse<V1PodList>
            {
                Body = _podList
            });
        }

        public Task<HttpOperationResponse<V1Pod>> CreateNamespacedPodWithHttpMessagesAsync(V1Pod body, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Pod>> DeleteNamespacedPodWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Pod>> ReadNamespacedPodWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Pod>> PatchNamespacedPodWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Pod>> ReplaceNamespacedPodWithHttpMessagesAsync(V1Pod body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectGetNamespacedPodAttachWithHttpMessagesAsync(string name, string namespaceParameter, string container = null, bool? stderr = null, bool? stdin = null, bool? stdout = null, bool? tty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectPostNamespacedPodAttachWithHttpMessagesAsync(string name, string namespaceParameter, string container = null, bool? stderr = null, bool? stdin = null, bool? stdout = null, bool? tty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Binding>> CreateNamespacedPodBindingWithHttpMessagesAsync(V1Binding body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Pod>> ReadNamespacedPodEphemeralcontainersWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Pod>> PatchNamespacedPodEphemeralcontainersWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Pod>> ReplaceNamespacedPodEphemeralcontainersWithHttpMessagesAsync(V1Pod body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Eviction>> CreateNamespacedPodEvictionWithHttpMessagesAsync(V1Eviction body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectGetNamespacedPodExecWithHttpMessagesAsync(string name, string namespaceParameter, string command = null, string container = null, bool? stderr = null, bool? stdin = null, bool? stdout = null, bool? tty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectPostNamespacedPodExecWithHttpMessagesAsync(string name, string namespaceParameter, string command = null, string container = null, bool? stderr = null, bool? stdin = null, bool? stdout = null, bool? tty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ReadNamespacedPodLogWithHttpMessagesAsync(string name, string namespaceParameter, string container = null, bool? follow = null, bool? insecureSkipTLSVerifyBackend = null, int? limitBytes = null, bool? pretty = null, bool? previous = null, int? sinceSeconds = null, int? tailLines = null, bool? timestamps = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectGetNamespacedPodPortforwardWithHttpMessagesAsync(string name, string namespaceParameter, int? ports = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectPostNamespacedPodPortforwardWithHttpMessagesAsync(string name, string namespaceParameter, int? ports = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectDeleteNamespacedPodProxyWithHttpMessagesAsync(string name, string namespaceParameter, string path = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectGetNamespacedPodProxyWithHttpMessagesAsync(string name, string namespaceParameter, string path = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectHeadNamespacedPodProxyWithHttpMessagesAsync(string name, string namespaceParameter, string path = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectPatchNamespacedPodProxyWithHttpMessagesAsync(string name, string namespaceParameter, string path = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectPostNamespacedPodProxyWithHttpMessagesAsync(string name, string namespaceParameter, string path = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectPutNamespacedPodProxyWithHttpMessagesAsync(string name, string namespaceParameter, string path = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectDeleteNamespacedPodProxyWithPathWithHttpMessagesAsync(string name, string namespaceParameter, string path, string path1 = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectGetNamespacedPodProxyWithPathWithHttpMessagesAsync(string name, string namespaceParameter, string path, string path1 = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectHeadNamespacedPodProxyWithPathWithHttpMessagesAsync(string name, string namespaceParameter, string path, string path1 = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectPatchNamespacedPodProxyWithPathWithHttpMessagesAsync(string name, string namespaceParameter, string path, string path1 = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectPostNamespacedPodProxyWithPathWithHttpMessagesAsync(string name, string namespaceParameter, string path, string path1 = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectPutNamespacedPodProxyWithPathWithHttpMessagesAsync(string name, string namespaceParameter, string path, string path1 = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Pod>> ReadNamespacedPodStatusWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Pod>> PatchNamespacedPodStatusWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Pod>> ReplaceNamespacedPodStatusWithHttpMessagesAsync(V1Pod body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionNamespacedPodTemplateWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PodTemplateList>> ListNamespacedPodTemplateWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PodTemplate>> CreateNamespacedPodTemplateWithHttpMessagesAsync(V1PodTemplate body, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PodTemplate>> DeleteNamespacedPodTemplateWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PodTemplate>> ReadNamespacedPodTemplateWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PodTemplate>> PatchNamespacedPodTemplateWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PodTemplate>> ReplaceNamespacedPodTemplateWithHttpMessagesAsync(V1PodTemplate body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionNamespacedReplicationControllerWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ReplicationControllerList>> ListNamespacedReplicationControllerWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ReplicationController>> CreateNamespacedReplicationControllerWithHttpMessagesAsync(V1ReplicationController body, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteNamespacedReplicationControllerWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ReplicationController>> ReadNamespacedReplicationControllerWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ReplicationController>> PatchNamespacedReplicationControllerWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ReplicationController>> ReplaceNamespacedReplicationControllerWithHttpMessagesAsync(V1ReplicationController body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Scale>> ReadNamespacedReplicationControllerScaleWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Scale>> PatchNamespacedReplicationControllerScaleWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Scale>> ReplaceNamespacedReplicationControllerScaleWithHttpMessagesAsync(V1Scale body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ReplicationController>> ReadNamespacedReplicationControllerStatusWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ReplicationController>> PatchNamespacedReplicationControllerStatusWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ReplicationController>> ReplaceNamespacedReplicationControllerStatusWithHttpMessagesAsync(V1ReplicationController body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionNamespacedResourceQuotaWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ResourceQuotaList>> ListNamespacedResourceQuotaWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ResourceQuota>> CreateNamespacedResourceQuotaWithHttpMessagesAsync(V1ResourceQuota body, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ResourceQuota>> DeleteNamespacedResourceQuotaWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ResourceQuota>> ReadNamespacedResourceQuotaWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ResourceQuota>> PatchNamespacedResourceQuotaWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ResourceQuota>> ReplaceNamespacedResourceQuotaWithHttpMessagesAsync(V1ResourceQuota body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ResourceQuota>> ReadNamespacedResourceQuotaStatusWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ResourceQuota>> PatchNamespacedResourceQuotaStatusWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ResourceQuota>> ReplaceNamespacedResourceQuotaStatusWithHttpMessagesAsync(V1ResourceQuota body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionNamespacedSecretWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1SecretList>> ListNamespacedSecretWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Secret>> CreateNamespacedSecretWithHttpMessagesAsync(V1Secret body, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteNamespacedSecretWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Secret>> ReadNamespacedSecretWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Secret>> PatchNamespacedSecretWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Secret>> ReplaceNamespacedSecretWithHttpMessagesAsync(V1Secret body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionNamespacedServiceAccountWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ServiceAccountList>> ListNamespacedServiceAccountWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ServiceAccount>> CreateNamespacedServiceAccountWithHttpMessagesAsync(V1ServiceAccount body, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ServiceAccount>> DeleteNamespacedServiceAccountWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ServiceAccount>> ReadNamespacedServiceAccountWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ServiceAccount>> PatchNamespacedServiceAccountWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ServiceAccount>> ReplaceNamespacedServiceAccountWithHttpMessagesAsync(V1ServiceAccount body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Authenticationv1TokenRequest>> CreateNamespacedServiceAccountTokenWithHttpMessagesAsync(Authenticationv1TokenRequest body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ServiceList>> ListNamespacedServiceWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Service>> CreateNamespacedServiceWithHttpMessagesAsync(V1Service body, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteNamespacedServiceWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Service>> ReadNamespacedServiceWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Service>> PatchNamespacedServiceWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Service>> ReplaceNamespacedServiceWithHttpMessagesAsync(V1Service body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectDeleteNamespacedServiceProxyWithHttpMessagesAsync(string name, string namespaceParameter, string path = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectGetNamespacedServiceProxyWithHttpMessagesAsync(string name, string namespaceParameter, string path = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectHeadNamespacedServiceProxyWithHttpMessagesAsync(string name, string namespaceParameter, string path = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectPatchNamespacedServiceProxyWithHttpMessagesAsync(string name, string namespaceParameter, string path = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectPostNamespacedServiceProxyWithHttpMessagesAsync(string name, string namespaceParameter, string path = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectPutNamespacedServiceProxyWithHttpMessagesAsync(string name, string namespaceParameter, string path = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectDeleteNamespacedServiceProxyWithPathWithHttpMessagesAsync(string name, string namespaceParameter, string path, string path1 = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectGetNamespacedServiceProxyWithPathWithHttpMessagesAsync(string name, string namespaceParameter, string path, string path1 = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectHeadNamespacedServiceProxyWithPathWithHttpMessagesAsync(string name, string namespaceParameter, string path, string path1 = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectPatchNamespacedServiceProxyWithPathWithHttpMessagesAsync(string name, string namespaceParameter, string path, string path1 = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectPostNamespacedServiceProxyWithPathWithHttpMessagesAsync(string name, string namespaceParameter, string path, string path1 = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectPutNamespacedServiceProxyWithPathWithHttpMessagesAsync(string name, string namespaceParameter, string path, string path1 = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Service>> ReadNamespacedServiceStatusWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Service>> PatchNamespacedServiceStatusWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Service>> ReplaceNamespacedServiceStatusWithHttpMessagesAsync(V1Service body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteNamespaceWithHttpMessagesAsync(string name, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Namespace>> ReadNamespaceWithHttpMessagesAsync(string name, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Namespace>> PatchNamespaceWithHttpMessagesAsync(V1Patch body, string name, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Namespace>> ReplaceNamespaceWithHttpMessagesAsync(V1Namespace body, string name, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Namespace>> ReplaceNamespaceFinalizeWithHttpMessagesAsync(V1Namespace body, string name, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Namespace>> ReadNamespaceStatusWithHttpMessagesAsync(string name, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Namespace>> PatchNamespaceStatusWithHttpMessagesAsync(V1Patch body, string name, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Namespace>> ReplaceNamespaceStatusWithHttpMessagesAsync(V1Namespace body, string name, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionNodeWithHttpMessagesAsync(V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1NodeList>> ListNodeWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Node>> CreateNodeWithHttpMessagesAsync(V1Node body, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteNodeWithHttpMessagesAsync(string name, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Node>> ReadNodeWithHttpMessagesAsync(string name, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Node>> PatchNodeWithHttpMessagesAsync(V1Patch body, string name, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Node>> ReplaceNodeWithHttpMessagesAsync(V1Node body, string name, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectDeleteNodeProxyWithHttpMessagesAsync(string name, string path = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectGetNodeProxyWithHttpMessagesAsync(string name, string path = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectHeadNodeProxyWithHttpMessagesAsync(string name, string path = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectPatchNodeProxyWithHttpMessagesAsync(string name, string path = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectPostNodeProxyWithHttpMessagesAsync(string name, string path = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectPutNodeProxyWithHttpMessagesAsync(string name, string path = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectDeleteNodeProxyWithPathWithHttpMessagesAsync(string name, string path, string path1 = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectGetNodeProxyWithPathWithHttpMessagesAsync(string name, string path, string path1 = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectHeadNodeProxyWithPathWithHttpMessagesAsync(string name, string path, string path1 = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectPatchNodeProxyWithPathWithHttpMessagesAsync(string name, string path, string path1 = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectPostNodeProxyWithPathWithHttpMessagesAsync(string name, string path, string path1 = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<Stream>> ConnectPutNodeProxyWithPathWithHttpMessagesAsync(string name, string path, string path1 = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Node>> ReadNodeStatusWithHttpMessagesAsync(string name, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Node>> PatchNodeStatusWithHttpMessagesAsync(V1Patch body, string name, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Node>> ReplaceNodeStatusWithHttpMessagesAsync(V1Node body, string name, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PersistentVolumeClaimList>> ListPersistentVolumeClaimForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionPersistentVolumeWithHttpMessagesAsync(V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PersistentVolumeList>> ListPersistentVolumeWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PersistentVolume>> CreatePersistentVolumeWithHttpMessagesAsync(V1PersistentVolume body, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PersistentVolume>> DeletePersistentVolumeWithHttpMessagesAsync(string name, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PersistentVolume>> ReadPersistentVolumeWithHttpMessagesAsync(string name, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PersistentVolume>> PatchPersistentVolumeWithHttpMessagesAsync(V1Patch body, string name, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PersistentVolume>> ReplacePersistentVolumeWithHttpMessagesAsync(V1PersistentVolume body, string name, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PersistentVolume>> ReadPersistentVolumeStatusWithHttpMessagesAsync(string name, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PersistentVolume>> PatchPersistentVolumeStatusWithHttpMessagesAsync(V1Patch body, string name, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PersistentVolume>> ReplacePersistentVolumeStatusWithHttpMessagesAsync(V1PersistentVolume body, string name, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PodList>> ListPodForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PodTemplateList>> ListPodTemplateForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ReplicationControllerList>> ListReplicationControllerForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ResourceQuotaList>> ListResourceQuotaForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1SecretList>> ListSecretForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ServiceAccountList>> ListServiceAccountForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ServiceList>> ListServiceForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIGroup>> GetAPIGroupWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIGroup>> GetAPIGroup1WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIGroup>> GetAPIGroup2WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIGroup>> GetAPIGroup3WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIGroup>> GetAPIGroup4WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIGroup>> GetAPIGroup5WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIGroup>> GetAPIGroup6WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIGroup>> GetAPIGroup7WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIGroup>> GetAPIGroup8WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIGroup>> GetAPIGroup9WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIGroup>> GetAPIGroup10WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIGroup>> GetAPIGroup11WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIGroup>> GetAPIGroup12WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIGroup>> GetAPIGroup13WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIGroup>> GetAPIGroup14WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIGroup>> GetAPIGroup15WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIGroup>> GetAPIGroup16WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIGroup>> GetAPIGroup17WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIGroup>> GetAPIGroup18WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIGroup>> GetAPIGroup19WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionMutatingWebhookConfigurationWithHttpMessagesAsync(V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1MutatingWebhookConfigurationList>> ListMutatingWebhookConfigurationWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1MutatingWebhookConfiguration>> CreateMutatingWebhookConfigurationWithHttpMessagesAsync(V1MutatingWebhookConfiguration body, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteMutatingWebhookConfigurationWithHttpMessagesAsync(string name, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1MutatingWebhookConfiguration>> ReadMutatingWebhookConfigurationWithHttpMessagesAsync(string name, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1MutatingWebhookConfiguration>> PatchMutatingWebhookConfigurationWithHttpMessagesAsync(V1Patch body, string name, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1MutatingWebhookConfiguration>> ReplaceMutatingWebhookConfigurationWithHttpMessagesAsync(V1MutatingWebhookConfiguration body, string name, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionValidatingWebhookConfigurationWithHttpMessagesAsync(V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ValidatingWebhookConfigurationList>> ListValidatingWebhookConfigurationWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ValidatingWebhookConfiguration>> CreateValidatingWebhookConfigurationWithHttpMessagesAsync(V1ValidatingWebhookConfiguration body, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteValidatingWebhookConfigurationWithHttpMessagesAsync(string name, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ValidatingWebhookConfiguration>> ReadValidatingWebhookConfigurationWithHttpMessagesAsync(string name, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ValidatingWebhookConfiguration>> PatchValidatingWebhookConfigurationWithHttpMessagesAsync(V1Patch body, string name, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ValidatingWebhookConfiguration>> ReplaceValidatingWebhookConfigurationWithHttpMessagesAsync(V1ValidatingWebhookConfiguration body, string name, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionCustomResourceDefinitionWithHttpMessagesAsync(V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1CustomResourceDefinitionList>> ListCustomResourceDefinitionWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1CustomResourceDefinition>> CreateCustomResourceDefinitionWithHttpMessagesAsync(V1CustomResourceDefinition body, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCustomResourceDefinitionWithHttpMessagesAsync(string name, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1CustomResourceDefinition>> ReadCustomResourceDefinitionWithHttpMessagesAsync(string name, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1CustomResourceDefinition>> PatchCustomResourceDefinitionWithHttpMessagesAsync(V1Patch body, string name, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1CustomResourceDefinition>> ReplaceCustomResourceDefinitionWithHttpMessagesAsync(V1CustomResourceDefinition body, string name, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1CustomResourceDefinition>> ReadCustomResourceDefinitionStatusWithHttpMessagesAsync(string name, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1CustomResourceDefinition>> PatchCustomResourceDefinitionStatusWithHttpMessagesAsync(V1Patch body, string name, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1CustomResourceDefinition>> ReplaceCustomResourceDefinitionStatusWithHttpMessagesAsync(V1CustomResourceDefinition body, string name, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionAPIServiceWithHttpMessagesAsync(V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIServiceList>> ListAPIServiceWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIService>> CreateAPIServiceWithHttpMessagesAsync(V1APIService body, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteAPIServiceWithHttpMessagesAsync(string name, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIService>> ReadAPIServiceWithHttpMessagesAsync(string name, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIService>> PatchAPIServiceWithHttpMessagesAsync(V1Patch body, string name, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIService>> ReplaceAPIServiceWithHttpMessagesAsync(V1APIService body, string name, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIService>> ReadAPIServiceStatusWithHttpMessagesAsync(string name, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIService>> PatchAPIServiceStatusWithHttpMessagesAsync(V1Patch body, string name, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1APIService>> ReplaceAPIServiceStatusWithHttpMessagesAsync(V1APIService body, string name, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ControllerRevisionList>> ListControllerRevisionForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1DaemonSetList>> ListDaemonSetForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1DeploymentList>> ListDeploymentForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(new HttpOperationResponse<V1DeploymentList>
            {
                Body = _deploymentList
            });
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionNamespacedControllerRevisionWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ControllerRevisionList>> ListNamespacedControllerRevisionWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ControllerRevision>> CreateNamespacedControllerRevisionWithHttpMessagesAsync(V1ControllerRevision body, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteNamespacedControllerRevisionWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ControllerRevision>> ReadNamespacedControllerRevisionWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ControllerRevision>> PatchNamespacedControllerRevisionWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ControllerRevision>> ReplaceNamespacedControllerRevisionWithHttpMessagesAsync(V1ControllerRevision body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionNamespacedDaemonSetWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1DaemonSetList>> ListNamespacedDaemonSetWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1DaemonSet>> CreateNamespacedDaemonSetWithHttpMessagesAsync(V1DaemonSet body, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteNamespacedDaemonSetWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1DaemonSet>> ReadNamespacedDaemonSetWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1DaemonSet>> PatchNamespacedDaemonSetWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1DaemonSet>> ReplaceNamespacedDaemonSetWithHttpMessagesAsync(V1DaemonSet body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1DaemonSet>> ReadNamespacedDaemonSetStatusWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1DaemonSet>> PatchNamespacedDaemonSetStatusWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1DaemonSet>> ReplaceNamespacedDaemonSetStatusWithHttpMessagesAsync(V1DaemonSet body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionNamespacedDeploymentWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1DeploymentList>> ListNamespacedDeploymentWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Deployment>> CreateNamespacedDeploymentWithHttpMessagesAsync(V1Deployment body, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteNamespacedDeploymentWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Deployment>> ReadNamespacedDeploymentWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Deployment>> PatchNamespacedDeploymentWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Deployment>> ReplaceNamespacedDeploymentWithHttpMessagesAsync(V1Deployment body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Scale>> ReadNamespacedDeploymentScaleWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Scale>> PatchNamespacedDeploymentScaleWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Scale>> ReplaceNamespacedDeploymentScaleWithHttpMessagesAsync(V1Scale body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Deployment>> ReadNamespacedDeploymentStatusWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Deployment>> PatchNamespacedDeploymentStatusWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Deployment>> ReplaceNamespacedDeploymentStatusWithHttpMessagesAsync(V1Deployment body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionNamespacedReplicaSetWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ReplicaSetList>> ListNamespacedReplicaSetWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ReplicaSet>> CreateNamespacedReplicaSetWithHttpMessagesAsync(V1ReplicaSet body, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteNamespacedReplicaSetWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ReplicaSet>> ReadNamespacedReplicaSetWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ReplicaSet>> PatchNamespacedReplicaSetWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ReplicaSet>> ReplaceNamespacedReplicaSetWithHttpMessagesAsync(V1ReplicaSet body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Scale>> ReadNamespacedReplicaSetScaleWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Scale>> PatchNamespacedReplicaSetScaleWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Scale>> ReplaceNamespacedReplicaSetScaleWithHttpMessagesAsync(V1Scale body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ReplicaSet>> ReadNamespacedReplicaSetStatusWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ReplicaSet>> PatchNamespacedReplicaSetStatusWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ReplicaSet>> ReplaceNamespacedReplicaSetStatusWithHttpMessagesAsync(V1ReplicaSet body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionNamespacedStatefulSetWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1StatefulSetList>> ListNamespacedStatefulSetWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1StatefulSet>> CreateNamespacedStatefulSetWithHttpMessagesAsync(V1StatefulSet body, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteNamespacedStatefulSetWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1StatefulSet>> ReadNamespacedStatefulSetWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1StatefulSet>> PatchNamespacedStatefulSetWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1StatefulSet>> ReplaceNamespacedStatefulSetWithHttpMessagesAsync(V1StatefulSet body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Scale>> ReadNamespacedStatefulSetScaleWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Scale>> PatchNamespacedStatefulSetScaleWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Scale>> ReplaceNamespacedStatefulSetScaleWithHttpMessagesAsync(V1Scale body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1StatefulSet>> ReadNamespacedStatefulSetStatusWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1StatefulSet>> PatchNamespacedStatefulSetStatusWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1StatefulSet>> ReplaceNamespacedStatefulSetStatusWithHttpMessagesAsync(V1StatefulSet body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ReplicaSetList>> ListReplicaSetForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1StatefulSetList>> ListStatefulSetForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1TokenReview>> CreateTokenReviewWithHttpMessagesAsync(V1TokenReview body, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1LocalSubjectAccessReview>> CreateNamespacedLocalSubjectAccessReviewWithHttpMessagesAsync(V1LocalSubjectAccessReview body, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1SelfSubjectAccessReview>> CreateSelfSubjectAccessReviewWithHttpMessagesAsync(V1SelfSubjectAccessReview body, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1SelfSubjectRulesReview>> CreateSelfSubjectRulesReviewWithHttpMessagesAsync(V1SelfSubjectRulesReview body, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1SubjectAccessReview>> CreateSubjectAccessReviewWithHttpMessagesAsync(V1SubjectAccessReview body, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1HorizontalPodAutoscalerList>> ListHorizontalPodAutoscalerForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V2beta1HorizontalPodAutoscalerList>> ListHorizontalPodAutoscalerForAllNamespaces1WithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V2beta2HorizontalPodAutoscalerList>> ListHorizontalPodAutoscalerForAllNamespaces2WithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionNamespacedHorizontalPodAutoscalerWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionNamespacedHorizontalPodAutoscaler1WithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionNamespacedHorizontalPodAutoscaler2WithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1HorizontalPodAutoscalerList>> ListNamespacedHorizontalPodAutoscalerWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V2beta1HorizontalPodAutoscalerList>> ListNamespacedHorizontalPodAutoscaler1WithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V2beta2HorizontalPodAutoscalerList>> ListNamespacedHorizontalPodAutoscaler2WithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1HorizontalPodAutoscaler>> CreateNamespacedHorizontalPodAutoscalerWithHttpMessagesAsync(V1HorizontalPodAutoscaler body, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V2beta1HorizontalPodAutoscaler>> CreateNamespacedHorizontalPodAutoscaler1WithHttpMessagesAsync(V2beta1HorizontalPodAutoscaler body, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V2beta2HorizontalPodAutoscaler>> CreateNamespacedHorizontalPodAutoscaler2WithHttpMessagesAsync(V2beta2HorizontalPodAutoscaler body, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteNamespacedHorizontalPodAutoscalerWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteNamespacedHorizontalPodAutoscaler1WithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteNamespacedHorizontalPodAutoscaler2WithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1HorizontalPodAutoscaler>> ReadNamespacedHorizontalPodAutoscalerWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V2beta1HorizontalPodAutoscaler>> ReadNamespacedHorizontalPodAutoscaler1WithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V2beta2HorizontalPodAutoscaler>> ReadNamespacedHorizontalPodAutoscaler2WithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1HorizontalPodAutoscaler>> PatchNamespacedHorizontalPodAutoscalerWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V2beta1HorizontalPodAutoscaler>> PatchNamespacedHorizontalPodAutoscaler1WithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V2beta2HorizontalPodAutoscaler>> PatchNamespacedHorizontalPodAutoscaler2WithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1HorizontalPodAutoscaler>> ReplaceNamespacedHorizontalPodAutoscalerWithHttpMessagesAsync(V1HorizontalPodAutoscaler body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V2beta1HorizontalPodAutoscaler>> ReplaceNamespacedHorizontalPodAutoscaler1WithHttpMessagesAsync(V2beta1HorizontalPodAutoscaler body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V2beta2HorizontalPodAutoscaler>> ReplaceNamespacedHorizontalPodAutoscaler2WithHttpMessagesAsync(V2beta2HorizontalPodAutoscaler body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1HorizontalPodAutoscaler>> ReadNamespacedHorizontalPodAutoscalerStatusWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V2beta1HorizontalPodAutoscaler>> ReadNamespacedHorizontalPodAutoscalerStatus1WithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V2beta2HorizontalPodAutoscaler>> ReadNamespacedHorizontalPodAutoscalerStatus2WithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1HorizontalPodAutoscaler>> PatchNamespacedHorizontalPodAutoscalerStatusWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V2beta1HorizontalPodAutoscaler>> PatchNamespacedHorizontalPodAutoscalerStatus1WithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V2beta2HorizontalPodAutoscaler>> PatchNamespacedHorizontalPodAutoscalerStatus2WithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1HorizontalPodAutoscaler>> ReplaceNamespacedHorizontalPodAutoscalerStatusWithHttpMessagesAsync(V1HorizontalPodAutoscaler body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V2beta1HorizontalPodAutoscaler>> ReplaceNamespacedHorizontalPodAutoscalerStatus1WithHttpMessagesAsync(V2beta1HorizontalPodAutoscaler body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V2beta2HorizontalPodAutoscaler>> ReplaceNamespacedHorizontalPodAutoscalerStatus2WithHttpMessagesAsync(V2beta2HorizontalPodAutoscaler body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1CronJobList>> ListCronJobForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1CronJobList>> ListCronJobForAllNamespaces1WithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1JobList>> ListJobForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionNamespacedCronJobWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionNamespacedCronJob1WithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1CronJobList>> ListNamespacedCronJobWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1CronJobList>> ListNamespacedCronJob1WithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1CronJob>> CreateNamespacedCronJobWithHttpMessagesAsync(V1CronJob body, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1CronJob>> CreateNamespacedCronJob1WithHttpMessagesAsync(V1beta1CronJob body, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteNamespacedCronJobWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteNamespacedCronJob1WithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1CronJob>> ReadNamespacedCronJobWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1CronJob>> ReadNamespacedCronJob1WithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1CronJob>> PatchNamespacedCronJobWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1CronJob>> PatchNamespacedCronJob1WithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1CronJob>> ReplaceNamespacedCronJobWithHttpMessagesAsync(V1CronJob body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1CronJob>> ReplaceNamespacedCronJob1WithHttpMessagesAsync(V1beta1CronJob body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1CronJob>> ReadNamespacedCronJobStatusWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1CronJob>> ReadNamespacedCronJobStatus1WithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1CronJob>> PatchNamespacedCronJobStatusWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1CronJob>> PatchNamespacedCronJobStatus1WithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1CronJob>> ReplaceNamespacedCronJobStatusWithHttpMessagesAsync(V1CronJob body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1CronJob>> ReplaceNamespacedCronJobStatus1WithHttpMessagesAsync(V1beta1CronJob body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionNamespacedJobWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1JobList>> ListNamespacedJobWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Job>> CreateNamespacedJobWithHttpMessagesAsync(V1Job body, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteNamespacedJobWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Job>> ReadNamespacedJobWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Job>> PatchNamespacedJobWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Job>> ReplaceNamespacedJobWithHttpMessagesAsync(V1Job body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Job>> ReadNamespacedJobStatusWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Job>> PatchNamespacedJobStatusWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Job>> ReplaceNamespacedJobStatusWithHttpMessagesAsync(V1Job body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionCertificateSigningRequestWithHttpMessagesAsync(V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1CertificateSigningRequestList>> ListCertificateSigningRequestWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1CertificateSigningRequest>> CreateCertificateSigningRequestWithHttpMessagesAsync(V1CertificateSigningRequest body, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCertificateSigningRequestWithHttpMessagesAsync(string name, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1CertificateSigningRequest>> ReadCertificateSigningRequestWithHttpMessagesAsync(string name, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1CertificateSigningRequest>> PatchCertificateSigningRequestWithHttpMessagesAsync(V1Patch body, string name, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1CertificateSigningRequest>> ReplaceCertificateSigningRequestWithHttpMessagesAsync(V1CertificateSigningRequest body, string name, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1CertificateSigningRequest>> ReadCertificateSigningRequestApprovalWithHttpMessagesAsync(string name, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1CertificateSigningRequest>> PatchCertificateSigningRequestApprovalWithHttpMessagesAsync(V1Patch body, string name, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1CertificateSigningRequest>> ReplaceCertificateSigningRequestApprovalWithHttpMessagesAsync(V1CertificateSigningRequest body, string name, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1CertificateSigningRequest>> ReadCertificateSigningRequestStatusWithHttpMessagesAsync(string name, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1CertificateSigningRequest>> PatchCertificateSigningRequestStatusWithHttpMessagesAsync(V1Patch body, string name, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1CertificateSigningRequest>> ReplaceCertificateSigningRequestStatusWithHttpMessagesAsync(V1CertificateSigningRequest body, string name, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1LeaseList>> ListLeaseForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionNamespacedLeaseWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1LeaseList>> ListNamespacedLeaseWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Lease>> CreateNamespacedLeaseWithHttpMessagesAsync(V1Lease body, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteNamespacedLeaseWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Lease>> ReadNamespacedLeaseWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Lease>> PatchNamespacedLeaseWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Lease>> ReplaceNamespacedLeaseWithHttpMessagesAsync(V1Lease body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1EndpointSliceList>> ListEndpointSliceForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1EndpointSliceList>> ListEndpointSliceForAllNamespaces1WithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionNamespacedEndpointSliceWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionNamespacedEndpointSlice1WithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1EndpointSliceList>> ListNamespacedEndpointSliceWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1EndpointSliceList>> ListNamespacedEndpointSlice1WithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1EndpointSlice>> CreateNamespacedEndpointSliceWithHttpMessagesAsync(V1EndpointSlice body, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1EndpointSlice>> CreateNamespacedEndpointSlice1WithHttpMessagesAsync(V1beta1EndpointSlice body, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteNamespacedEndpointSliceWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteNamespacedEndpointSlice1WithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1EndpointSlice>> ReadNamespacedEndpointSliceWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1EndpointSlice>> ReadNamespacedEndpointSlice1WithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1EndpointSlice>> PatchNamespacedEndpointSliceWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1EndpointSlice>> PatchNamespacedEndpointSlice1WithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1EndpointSlice>> ReplaceNamespacedEndpointSliceWithHttpMessagesAsync(V1EndpointSlice body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1EndpointSlice>> ReplaceNamespacedEndpointSlice1WithHttpMessagesAsync(V1beta1EndpointSlice body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionFlowSchemaWithHttpMessagesAsync(V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1FlowSchemaList>> ListFlowSchemaWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1FlowSchema>> CreateFlowSchemaWithHttpMessagesAsync(V1beta1FlowSchema body, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteFlowSchemaWithHttpMessagesAsync(string name, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1FlowSchema>> ReadFlowSchemaWithHttpMessagesAsync(string name, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1FlowSchema>> PatchFlowSchemaWithHttpMessagesAsync(V1Patch body, string name, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1FlowSchema>> ReplaceFlowSchemaWithHttpMessagesAsync(V1beta1FlowSchema body, string name, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1FlowSchema>> ReadFlowSchemaStatusWithHttpMessagesAsync(string name, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1FlowSchema>> PatchFlowSchemaStatusWithHttpMessagesAsync(V1Patch body, string name, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1FlowSchema>> ReplaceFlowSchemaStatusWithHttpMessagesAsync(V1beta1FlowSchema body, string name, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionPriorityLevelConfigurationWithHttpMessagesAsync(V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1PriorityLevelConfigurationList>> ListPriorityLevelConfigurationWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1PriorityLevelConfiguration>> CreatePriorityLevelConfigurationWithHttpMessagesAsync(V1beta1PriorityLevelConfiguration body, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeletePriorityLevelConfigurationWithHttpMessagesAsync(string name, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1PriorityLevelConfiguration>> ReadPriorityLevelConfigurationWithHttpMessagesAsync(string name, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1PriorityLevelConfiguration>> PatchPriorityLevelConfigurationWithHttpMessagesAsync(V1Patch body, string name, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1PriorityLevelConfiguration>> ReplacePriorityLevelConfigurationWithHttpMessagesAsync(V1beta1PriorityLevelConfiguration body, string name, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1PriorityLevelConfiguration>> ReadPriorityLevelConfigurationStatusWithHttpMessagesAsync(string name, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1PriorityLevelConfiguration>> PatchPriorityLevelConfigurationStatusWithHttpMessagesAsync(V1Patch body, string name, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1PriorityLevelConfiguration>> ReplacePriorityLevelConfigurationStatusWithHttpMessagesAsync(V1beta1PriorityLevelConfiguration body, string name, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionStorageVersionWithHttpMessagesAsync(V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1StorageVersionList>> ListStorageVersionWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1StorageVersion>> CreateStorageVersionWithHttpMessagesAsync(V1alpha1StorageVersion body, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteStorageVersionWithHttpMessagesAsync(string name, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1StorageVersion>> ReadStorageVersionWithHttpMessagesAsync(string name, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1StorageVersion>> PatchStorageVersionWithHttpMessagesAsync(V1Patch body, string name, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1StorageVersion>> ReplaceStorageVersionWithHttpMessagesAsync(V1alpha1StorageVersion body, string name, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1StorageVersion>> ReadStorageVersionStatusWithHttpMessagesAsync(string name, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1StorageVersion>> PatchStorageVersionStatusWithHttpMessagesAsync(V1Patch body, string name, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1StorageVersion>> ReplaceStorageVersionStatusWithHttpMessagesAsync(V1alpha1StorageVersion body, string name, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionIngressClassWithHttpMessagesAsync(V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1IngressClassList>> ListIngressClassWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1IngressClass>> CreateIngressClassWithHttpMessagesAsync(V1IngressClass body, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteIngressClassWithHttpMessagesAsync(string name, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1IngressClass>> ReadIngressClassWithHttpMessagesAsync(string name, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1IngressClass>> PatchIngressClassWithHttpMessagesAsync(V1Patch body, string name, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1IngressClass>> ReplaceIngressClassWithHttpMessagesAsync(V1IngressClass body, string name, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1IngressList>> ListIngressForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionNamespacedIngressWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1IngressList>> ListNamespacedIngressWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Ingress>> CreateNamespacedIngressWithHttpMessagesAsync(V1Ingress body, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteNamespacedIngressWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Ingress>> ReadNamespacedIngressWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Ingress>> PatchNamespacedIngressWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Ingress>> ReplaceNamespacedIngressWithHttpMessagesAsync(V1Ingress body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Ingress>> ReadNamespacedIngressStatusWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Ingress>> PatchNamespacedIngressStatusWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Ingress>> ReplaceNamespacedIngressStatusWithHttpMessagesAsync(V1Ingress body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionNamespacedNetworkPolicyWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1NetworkPolicyList>> ListNamespacedNetworkPolicyWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1NetworkPolicy>> CreateNamespacedNetworkPolicyWithHttpMessagesAsync(V1NetworkPolicy body, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteNamespacedNetworkPolicyWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1NetworkPolicy>> ReadNamespacedNetworkPolicyWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1NetworkPolicy>> PatchNamespacedNetworkPolicyWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1NetworkPolicy>> ReplaceNamespacedNetworkPolicyWithHttpMessagesAsync(V1NetworkPolicy body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1NetworkPolicyList>> ListNetworkPolicyForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionRuntimeClassWithHttpMessagesAsync(V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionRuntimeClass1WithHttpMessagesAsync(V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionRuntimeClass2WithHttpMessagesAsync(V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1RuntimeClassList>> ListRuntimeClassWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1RuntimeClassList>> ListRuntimeClass1WithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1RuntimeClassList>> ListRuntimeClass2WithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1RuntimeClass>> CreateRuntimeClassWithHttpMessagesAsync(V1RuntimeClass body, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1RuntimeClass>> CreateRuntimeClass1WithHttpMessagesAsync(V1alpha1RuntimeClass body, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1RuntimeClass>> CreateRuntimeClass2WithHttpMessagesAsync(V1beta1RuntimeClass body, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteRuntimeClassWithHttpMessagesAsync(string name, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteRuntimeClass1WithHttpMessagesAsync(string name, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteRuntimeClass2WithHttpMessagesAsync(string name, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1RuntimeClass>> ReadRuntimeClassWithHttpMessagesAsync(string name, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1RuntimeClass>> ReadRuntimeClass1WithHttpMessagesAsync(string name, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1RuntimeClass>> ReadRuntimeClass2WithHttpMessagesAsync(string name, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1RuntimeClass>> PatchRuntimeClassWithHttpMessagesAsync(V1Patch body, string name, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1RuntimeClass>> PatchRuntimeClass1WithHttpMessagesAsync(V1Patch body, string name, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1RuntimeClass>> PatchRuntimeClass2WithHttpMessagesAsync(V1Patch body, string name, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1RuntimeClass>> ReplaceRuntimeClassWithHttpMessagesAsync(V1RuntimeClass body, string name, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1RuntimeClass>> ReplaceRuntimeClass1WithHttpMessagesAsync(V1alpha1RuntimeClass body, string name, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1RuntimeClass>> ReplaceRuntimeClass2WithHttpMessagesAsync(V1beta1RuntimeClass body, string name, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionNamespacedPodDisruptionBudgetWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionNamespacedPodDisruptionBudget1WithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PodDisruptionBudgetList>> ListNamespacedPodDisruptionBudgetWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1PodDisruptionBudgetList>> ListNamespacedPodDisruptionBudget1WithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PodDisruptionBudget>> CreateNamespacedPodDisruptionBudgetWithHttpMessagesAsync(V1PodDisruptionBudget body, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1PodDisruptionBudget>> CreateNamespacedPodDisruptionBudget1WithHttpMessagesAsync(V1beta1PodDisruptionBudget body, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteNamespacedPodDisruptionBudgetWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteNamespacedPodDisruptionBudget1WithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PodDisruptionBudget>> ReadNamespacedPodDisruptionBudgetWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1PodDisruptionBudget>> ReadNamespacedPodDisruptionBudget1WithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PodDisruptionBudget>> PatchNamespacedPodDisruptionBudgetWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1PodDisruptionBudget>> PatchNamespacedPodDisruptionBudget1WithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PodDisruptionBudget>> ReplaceNamespacedPodDisruptionBudgetWithHttpMessagesAsync(V1PodDisruptionBudget body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1PodDisruptionBudget>> ReplaceNamespacedPodDisruptionBudget1WithHttpMessagesAsync(V1beta1PodDisruptionBudget body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PodDisruptionBudget>> ReadNamespacedPodDisruptionBudgetStatusWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1PodDisruptionBudget>> ReadNamespacedPodDisruptionBudgetStatus1WithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PodDisruptionBudget>> PatchNamespacedPodDisruptionBudgetStatusWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1PodDisruptionBudget>> PatchNamespacedPodDisruptionBudgetStatus1WithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PodDisruptionBudget>> ReplaceNamespacedPodDisruptionBudgetStatusWithHttpMessagesAsync(V1PodDisruptionBudget body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1PodDisruptionBudget>> ReplaceNamespacedPodDisruptionBudgetStatus1WithHttpMessagesAsync(V1beta1PodDisruptionBudget body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PodDisruptionBudgetList>> ListPodDisruptionBudgetForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1PodDisruptionBudgetList>> ListPodDisruptionBudgetForAllNamespaces1WithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionPodSecurityPolicyWithHttpMessagesAsync(V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1PodSecurityPolicyList>> ListPodSecurityPolicyWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1PodSecurityPolicy>> CreatePodSecurityPolicyWithHttpMessagesAsync(V1beta1PodSecurityPolicy body, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1PodSecurityPolicy>> DeletePodSecurityPolicyWithHttpMessagesAsync(string name, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1PodSecurityPolicy>> ReadPodSecurityPolicyWithHttpMessagesAsync(string name, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1PodSecurityPolicy>> PatchPodSecurityPolicyWithHttpMessagesAsync(V1Patch body, string name, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1PodSecurityPolicy>> ReplacePodSecurityPolicyWithHttpMessagesAsync(V1beta1PodSecurityPolicy body, string name, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionClusterRoleBindingWithHttpMessagesAsync(V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionClusterRoleBinding1WithHttpMessagesAsync(V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ClusterRoleBindingList>> ListClusterRoleBindingWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1ClusterRoleBindingList>> ListClusterRoleBinding1WithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ClusterRoleBinding>> CreateClusterRoleBindingWithHttpMessagesAsync(V1ClusterRoleBinding body, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1ClusterRoleBinding>> CreateClusterRoleBinding1WithHttpMessagesAsync(V1alpha1ClusterRoleBinding body, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteClusterRoleBindingWithHttpMessagesAsync(string name, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteClusterRoleBinding1WithHttpMessagesAsync(string name, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ClusterRoleBinding>> ReadClusterRoleBindingWithHttpMessagesAsync(string name, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1ClusterRoleBinding>> ReadClusterRoleBinding1WithHttpMessagesAsync(string name, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ClusterRoleBinding>> PatchClusterRoleBindingWithHttpMessagesAsync(V1Patch body, string name, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1ClusterRoleBinding>> PatchClusterRoleBinding1WithHttpMessagesAsync(V1Patch body, string name, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ClusterRoleBinding>> ReplaceClusterRoleBindingWithHttpMessagesAsync(V1ClusterRoleBinding body, string name, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1ClusterRoleBinding>> ReplaceClusterRoleBinding1WithHttpMessagesAsync(V1alpha1ClusterRoleBinding body, string name, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionClusterRoleWithHttpMessagesAsync(V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionClusterRole1WithHttpMessagesAsync(V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ClusterRoleList>> ListClusterRoleWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1ClusterRoleList>> ListClusterRole1WithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ClusterRole>> CreateClusterRoleWithHttpMessagesAsync(V1ClusterRole body, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1ClusterRole>> CreateClusterRole1WithHttpMessagesAsync(V1alpha1ClusterRole body, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteClusterRoleWithHttpMessagesAsync(string name, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteClusterRole1WithHttpMessagesAsync(string name, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ClusterRole>> ReadClusterRoleWithHttpMessagesAsync(string name, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1ClusterRole>> ReadClusterRole1WithHttpMessagesAsync(string name, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ClusterRole>> PatchClusterRoleWithHttpMessagesAsync(V1Patch body, string name, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1ClusterRole>> PatchClusterRole1WithHttpMessagesAsync(V1Patch body, string name, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1ClusterRole>> ReplaceClusterRoleWithHttpMessagesAsync(V1ClusterRole body, string name, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1ClusterRole>> ReplaceClusterRole1WithHttpMessagesAsync(V1alpha1ClusterRole body, string name, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionNamespacedRoleBindingWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionNamespacedRoleBinding1WithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1RoleBindingList>> ListNamespacedRoleBindingWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1RoleBindingList>> ListNamespacedRoleBinding1WithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1RoleBinding>> CreateNamespacedRoleBindingWithHttpMessagesAsync(V1RoleBinding body, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1RoleBinding>> CreateNamespacedRoleBinding1WithHttpMessagesAsync(V1alpha1RoleBinding body, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteNamespacedRoleBindingWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteNamespacedRoleBinding1WithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1RoleBinding>> ReadNamespacedRoleBindingWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1RoleBinding>> ReadNamespacedRoleBinding1WithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1RoleBinding>> PatchNamespacedRoleBindingWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1RoleBinding>> PatchNamespacedRoleBinding1WithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1RoleBinding>> ReplaceNamespacedRoleBindingWithHttpMessagesAsync(V1RoleBinding body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1RoleBinding>> ReplaceNamespacedRoleBinding1WithHttpMessagesAsync(V1alpha1RoleBinding body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionNamespacedRoleWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionNamespacedRole1WithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1RoleList>> ListNamespacedRoleWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1RoleList>> ListNamespacedRole1WithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Role>> CreateNamespacedRoleWithHttpMessagesAsync(V1Role body, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1Role>> CreateNamespacedRole1WithHttpMessagesAsync(V1alpha1Role body, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteNamespacedRoleWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteNamespacedRole1WithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Role>> ReadNamespacedRoleWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1Role>> ReadNamespacedRole1WithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Role>> PatchNamespacedRoleWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1Role>> PatchNamespacedRole1WithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Role>> ReplaceNamespacedRoleWithHttpMessagesAsync(V1Role body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1Role>> ReplaceNamespacedRole1WithHttpMessagesAsync(V1alpha1Role body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1RoleBindingList>> ListRoleBindingForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1RoleBindingList>> ListRoleBindingForAllNamespaces1WithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1RoleList>> ListRoleForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1RoleList>> ListRoleForAllNamespaces1WithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionPriorityClassWithHttpMessagesAsync(V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionPriorityClass1WithHttpMessagesAsync(V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PriorityClassList>> ListPriorityClassWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1PriorityClassList>> ListPriorityClass1WithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PriorityClass>> CreatePriorityClassWithHttpMessagesAsync(V1PriorityClass body, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1PriorityClass>> CreatePriorityClass1WithHttpMessagesAsync(V1alpha1PriorityClass body, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeletePriorityClassWithHttpMessagesAsync(string name, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeletePriorityClass1WithHttpMessagesAsync(string name, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PriorityClass>> ReadPriorityClassWithHttpMessagesAsync(string name, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1PriorityClass>> ReadPriorityClass1WithHttpMessagesAsync(string name, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PriorityClass>> PatchPriorityClassWithHttpMessagesAsync(V1Patch body, string name, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1PriorityClass>> PatchPriorityClass1WithHttpMessagesAsync(V1Patch body, string name, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1PriorityClass>> ReplacePriorityClassWithHttpMessagesAsync(V1PriorityClass body, string name, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1PriorityClass>> ReplacePriorityClass1WithHttpMessagesAsync(V1alpha1PriorityClass body, string name, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionCSIDriverWithHttpMessagesAsync(V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1CSIDriverList>> ListCSIDriverWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1CSIDriver>> CreateCSIDriverWithHttpMessagesAsync(V1CSIDriver body, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1CSIDriver>> DeleteCSIDriverWithHttpMessagesAsync(string name, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1CSIDriver>> ReadCSIDriverWithHttpMessagesAsync(string name, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1CSIDriver>> PatchCSIDriverWithHttpMessagesAsync(V1Patch body, string name, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1CSIDriver>> ReplaceCSIDriverWithHttpMessagesAsync(V1CSIDriver body, string name, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionCSINodeWithHttpMessagesAsync(V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1CSINodeList>> ListCSINodeWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1CSINode>> CreateCSINodeWithHttpMessagesAsync(V1CSINode body, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1CSINode>> DeleteCSINodeWithHttpMessagesAsync(string name, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1CSINode>> ReadCSINodeWithHttpMessagesAsync(string name, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1CSINode>> PatchCSINodeWithHttpMessagesAsync(V1Patch body, string name, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1CSINode>> ReplaceCSINodeWithHttpMessagesAsync(V1CSINode body, string name, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionStorageClassWithHttpMessagesAsync(V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1StorageClassList>> ListStorageClassWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1StorageClass>> CreateStorageClassWithHttpMessagesAsync(V1StorageClass body, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1StorageClass>> DeleteStorageClassWithHttpMessagesAsync(string name, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1StorageClass>> ReadStorageClassWithHttpMessagesAsync(string name, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1StorageClass>> PatchStorageClassWithHttpMessagesAsync(V1Patch body, string name, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1StorageClass>> ReplaceStorageClassWithHttpMessagesAsync(V1StorageClass body, string name, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionVolumeAttachmentWithHttpMessagesAsync(V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionVolumeAttachment1WithHttpMessagesAsync(V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1VolumeAttachmentList>> ListVolumeAttachmentWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1VolumeAttachmentList>> ListVolumeAttachment1WithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1VolumeAttachment>> CreateVolumeAttachmentWithHttpMessagesAsync(V1VolumeAttachment body, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1VolumeAttachment>> CreateVolumeAttachment1WithHttpMessagesAsync(V1alpha1VolumeAttachment body, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1VolumeAttachment>> DeleteVolumeAttachmentWithHttpMessagesAsync(string name, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1VolumeAttachment>> DeleteVolumeAttachment1WithHttpMessagesAsync(string name, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1VolumeAttachment>> ReadVolumeAttachmentWithHttpMessagesAsync(string name, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1VolumeAttachment>> ReadVolumeAttachment1WithHttpMessagesAsync(string name, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1VolumeAttachment>> PatchVolumeAttachmentWithHttpMessagesAsync(V1Patch body, string name, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1VolumeAttachment>> PatchVolumeAttachment1WithHttpMessagesAsync(V1Patch body, string name, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1VolumeAttachment>> ReplaceVolumeAttachmentWithHttpMessagesAsync(V1VolumeAttachment body, string name, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1VolumeAttachment>> ReplaceVolumeAttachment1WithHttpMessagesAsync(V1alpha1VolumeAttachment body, string name, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1VolumeAttachment>> ReadVolumeAttachmentStatusWithHttpMessagesAsync(string name, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1VolumeAttachment>> PatchVolumeAttachmentStatusWithHttpMessagesAsync(V1Patch body, string name, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1VolumeAttachment>> ReplaceVolumeAttachmentStatusWithHttpMessagesAsync(V1VolumeAttachment body, string name, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1CSIStorageCapacityList>> ListCSIStorageCapacityForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1CSIStorageCapacityList>> ListCSIStorageCapacityForAllNamespaces1WithHttpMessagesAsync(bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionNamespacedCSIStorageCapacityWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteCollectionNamespacedCSIStorageCapacity1WithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body = null, string continueParameter = null, string dryRun = null, string fieldSelector = null, int? gracePeriodSeconds = null, string labelSelector = null, int? limit = null, bool? orphanDependents = null, string propagationPolicy = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1CSIStorageCapacityList>> ListNamespacedCSIStorageCapacityWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1CSIStorageCapacityList>> ListNamespacedCSIStorageCapacity1WithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1CSIStorageCapacity>> CreateNamespacedCSIStorageCapacityWithHttpMessagesAsync(V1alpha1CSIStorageCapacity body, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1CSIStorageCapacity>> CreateNamespacedCSIStorageCapacity1WithHttpMessagesAsync(V1beta1CSIStorageCapacity body, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteNamespacedCSIStorageCapacityWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1Status>> DeleteNamespacedCSIStorageCapacity1WithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body = null, string dryRun = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1CSIStorageCapacity>> ReadNamespacedCSIStorageCapacityWithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1CSIStorageCapacity>> ReadNamespacedCSIStorageCapacity1WithHttpMessagesAsync(string name, string namespaceParameter, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1CSIStorageCapacity>> PatchNamespacedCSIStorageCapacityWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1CSIStorageCapacity>> PatchNamespacedCSIStorageCapacity1WithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? force = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1alpha1CSIStorageCapacity>> ReplaceNamespacedCSIStorageCapacityWithHttpMessagesAsync(V1alpha1CSIStorageCapacity body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<V1beta1CSIStorageCapacity>> ReplaceNamespacedCSIStorageCapacity1WithHttpMessagesAsync(V1beta1CSIStorageCapacity body, string name, string namespaceParameter, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse> LogFileListHandlerWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse> LogFileHandlerWithHttpMessagesAsync(string logpath, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<string>> GetServiceAccountIssuerOpenIDKeysetWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<VersionInfo>> GetCodeWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<object>> CreateNamespacedCustomObjectWithHttpMessagesAsync(object body, string group, string version, string namespaceParameter, string plural, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<object>> DeleteCollectionNamespacedCustomObjectWithHttpMessagesAsync(string group, string version, string namespaceParameter, string plural, V1DeleteOptions body = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, string dryRun = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<object>> ListNamespacedCustomObjectWithHttpMessagesAsync(string group, string version, string namespaceParameter, string plural, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<object>> CreateClusterCustomObjectWithHttpMessagesAsync(object body, string group, string version, string plural, string dryRun = null, string fieldManager = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<object>> DeleteCollectionClusterCustomObjectWithHttpMessagesAsync(string group, string version, string plural, V1DeleteOptions body = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, string dryRun = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<object>> ListClusterCustomObjectWithHttpMessagesAsync(string group, string version, string plural, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, bool? pretty = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<object>> ReplaceClusterCustomObjectStatusWithHttpMessagesAsync(object body, string group, string version, string plural, string name, string dryRun = null, string fieldManager = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<object>> PatchClusterCustomObjectStatusWithHttpMessagesAsync(object body, string group, string version, string plural, string name, string dryRun = null, string fieldManager = null, bool? force = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<object>> GetClusterCustomObjectStatusWithHttpMessagesAsync(string group, string version, string plural, string name, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<object>> ReplaceNamespacedCustomObjectWithHttpMessagesAsync(object body, string group, string version, string namespaceParameter, string plural, string name, string dryRun = null, string fieldManager = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<object>> PatchNamespacedCustomObjectWithHttpMessagesAsync(object body, string group, string version, string namespaceParameter, string plural, string name, string dryRun = null, string fieldManager = null, bool? force = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<object>> DeleteNamespacedCustomObjectWithHttpMessagesAsync(string group, string version, string namespaceParameter, string plural, string name, V1DeleteOptions body = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, string dryRun = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<object>> GetNamespacedCustomObjectWithHttpMessagesAsync(string group, string version, string namespaceParameter, string plural, string name, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<object>> ReplaceNamespacedCustomObjectScaleWithHttpMessagesAsync(object body, string group, string version, string namespaceParameter, string plural, string name, string dryRun = null, string fieldManager = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<object>> PatchNamespacedCustomObjectScaleWithHttpMessagesAsync(object body, string group, string version, string namespaceParameter, string plural, string name, string dryRun = null, string fieldManager = null, bool? force = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<object>> GetNamespacedCustomObjectScaleWithHttpMessagesAsync(string group, string version, string namespaceParameter, string plural, string name, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<object>> ReplaceClusterCustomObjectScaleWithHttpMessagesAsync(object body, string group, string version, string plural, string name, string dryRun = null, string fieldManager = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<object>> PatchClusterCustomObjectScaleWithHttpMessagesAsync(object body, string group, string version, string plural, string name, string dryRun = null, string fieldManager = null, bool? force = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<object>> GetClusterCustomObjectScaleWithHttpMessagesAsync(string group, string version, string plural, string name, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<object>> ReplaceClusterCustomObjectWithHttpMessagesAsync(object body, string group, string version, string plural, string name, string dryRun = null, string fieldManager = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<object>> PatchClusterCustomObjectWithHttpMessagesAsync(object body, string group, string version, string plural, string name, string dryRun = null, string fieldManager = null, bool? force = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<object>> DeleteClusterCustomObjectWithHttpMessagesAsync(string group, string version, string plural, string name, V1DeleteOptions body = null, int? gracePeriodSeconds = null, bool? orphanDependents = null, string propagationPolicy = null, string dryRun = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<object>> GetClusterCustomObjectWithHttpMessagesAsync(string group, string version, string plural, string name, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<object>> ReplaceNamespacedCustomObjectStatusWithHttpMessagesAsync(object body, string group, string version, string namespaceParameter, string plural, string name, string dryRun = null, string fieldManager = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<object>> PatchNamespacedCustomObjectStatusWithHttpMessagesAsync(object body, string group, string version, string namespaceParameter, string plural, string name, string dryRun = null, string fieldManager = null, bool? force = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<object>> GetNamespacedCustomObjectStatusWithHttpMessagesAsync(string group, string version, string namespaceParameter, string plural, string name, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1ConfigMap>> WatchNamespacedConfigMapAsync(string name, string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1ConfigMap> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1Endpoints>> WatchNamespacedEndpointsAsync(string name, string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1Endpoints> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<Corev1Event>> WatchNamespacedEventAsync(string name, string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, Corev1Event> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1LimitRange>> WatchNamespacedLimitRangeAsync(string name, string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1LimitRange> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1PersistentVolumeClaim>> WatchNamespacedPersistentVolumeClaimAsync(string name, string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1PersistentVolumeClaim> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1Pod>> WatchNamespacedPodAsync(string name, string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1Pod> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1PodTemplate>> WatchNamespacedPodTemplateAsync(string name, string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1PodTemplate> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1ReplicationController>> WatchNamespacedReplicationControllerAsync(string name, string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1ReplicationController> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1ResourceQuota>> WatchNamespacedResourceQuotaAsync(string name, string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1ResourceQuota> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1Secret>> WatchNamespacedSecretAsync(string name, string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1Secret> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1ServiceAccount>> WatchNamespacedServiceAccountAsync(string name, string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1ServiceAccount> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1Service>> WatchNamespacedServiceAsync(string name, string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1Service> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1Namespace>> WatchNamespaceAsync(string name, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1Namespace> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1Node>> WatchNodeAsync(string name, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1Node> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1PersistentVolume>> WatchPersistentVolumeAsync(string name, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1PersistentVolume> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1MutatingWebhookConfiguration>> WatchMutatingWebhookConfigurationAsync(string name, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1MutatingWebhookConfiguration> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1ValidatingWebhookConfiguration>> WatchValidatingWebhookConfigurationAsync(string name, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1ValidatingWebhookConfiguration> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1CustomResourceDefinition>> WatchCustomResourceDefinitionAsync(string name, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1CustomResourceDefinition> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1APIService>> WatchAPIServiceAsync(string name, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1APIService> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1ControllerRevision>> WatchNamespacedControllerRevisionAsync(string name, string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1ControllerRevision> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1DaemonSet>> WatchNamespacedDaemonSetAsync(string name, string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1DaemonSet> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1Deployment>> WatchNamespacedDeploymentAsync(string name, string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1Deployment> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1ReplicaSet>> WatchNamespacedReplicaSetAsync(string name, string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1ReplicaSet> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1StatefulSet>> WatchNamespacedStatefulSetAsync(string name, string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1StatefulSet> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1HorizontalPodAutoscaler>> WatchNamespacedHorizontalPodAutoscalerAsync(string name, string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1HorizontalPodAutoscaler> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V2beta1HorizontalPodAutoscaler>> WatchNamespacedHorizontalPodAutoscalerAsync(string name, string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V2beta1HorizontalPodAutoscaler> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V2beta2HorizontalPodAutoscaler>> WatchNamespacedHorizontalPodAutoscalerAsync(string name, string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V2beta2HorizontalPodAutoscaler> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1CronJob>> WatchNamespacedCronJobAsync(string name, string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1CronJob> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1Job>> WatchNamespacedJobAsync(string name, string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1Job> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1beta1CronJob>> WatchNamespacedCronJobAsync(string name, string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1beta1CronJob> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1CertificateSigningRequest>> WatchCertificateSigningRequestAsync(string name, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1CertificateSigningRequest> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1Lease>> WatchNamespacedLeaseAsync(string name, string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1Lease> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1EndpointSlice>> WatchNamespacedEndpointSliceAsync(string name, string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1EndpointSlice> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1beta1EndpointSlice>> WatchNamespacedEndpointSliceAsync(string name, string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1beta1EndpointSlice> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<Eventsv1Event>> WatchNamespacedEventAsync(string name, string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, Eventsv1Event> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1beta1Event>> WatchNamespacedEventAsync(string name, string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1beta1Event> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1beta1FlowSchema>> WatchFlowSchemaAsync(string name, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1beta1FlowSchema> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1beta1PriorityLevelConfiguration>> WatchPriorityLevelConfigurationAsync(string name, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1beta1PriorityLevelConfiguration> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1alpha1StorageVersion>> WatchStorageVersionAsync(string name, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1alpha1StorageVersion> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1IngressClass>> WatchIngressClassAsync(string name, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1IngressClass> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1Ingress>> WatchNamespacedIngressAsync(string name, string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1Ingress> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1NetworkPolicy>> WatchNamespacedNetworkPolicyAsync(string name, string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1NetworkPolicy> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1RuntimeClass>> WatchRuntimeClassAsync(string name, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1RuntimeClass> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1alpha1RuntimeClass>> WatchRuntimeClassAsync(string name, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1alpha1RuntimeClass> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1beta1RuntimeClass>> WatchRuntimeClassAsync(string name, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1beta1RuntimeClass> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1PodDisruptionBudget>> WatchNamespacedPodDisruptionBudgetAsync(string name, string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1PodDisruptionBudget> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1beta1PodDisruptionBudget>> WatchNamespacedPodDisruptionBudgetAsync(string name, string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1beta1PodDisruptionBudget> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1beta1PodSecurityPolicy>> WatchPodSecurityPolicyAsync(string name, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1beta1PodSecurityPolicy> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1ClusterRoleBinding>> WatchClusterRoleBindingAsync(string name, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1ClusterRoleBinding> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1ClusterRole>> WatchClusterRoleAsync(string name, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1ClusterRole> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1RoleBinding>> WatchNamespacedRoleBindingAsync(string name, string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1RoleBinding> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1Role>> WatchNamespacedRoleAsync(string name, string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1Role> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1alpha1ClusterRoleBinding>> WatchClusterRoleBindingAsync(string name, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1alpha1ClusterRoleBinding> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1alpha1ClusterRole>> WatchClusterRoleAsync(string name, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1alpha1ClusterRole> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1alpha1RoleBinding>> WatchNamespacedRoleBindingAsync(string name, string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1alpha1RoleBinding> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1alpha1Role>> WatchNamespacedRoleAsync(string name, string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1alpha1Role> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1PriorityClass>> WatchPriorityClassAsync(string name, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1PriorityClass> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1alpha1PriorityClass>> WatchPriorityClassAsync(string name, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1alpha1PriorityClass> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1CSIDriver>> WatchCSIDriverAsync(string name, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1CSIDriver> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1CSINode>> WatchCSINodeAsync(string name, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1CSINode> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1StorageClass>> WatchStorageClassAsync(string name, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1StorageClass> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1VolumeAttachment>> WatchVolumeAttachmentAsync(string name, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1VolumeAttachment> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1alpha1CSIStorageCapacity>> WatchNamespacedCSIStorageCapacityAsync(string name, string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1alpha1CSIStorageCapacity> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1alpha1VolumeAttachment>> WatchVolumeAttachmentAsync(string name, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1alpha1VolumeAttachment> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<V1beta1CSIStorageCapacity>> WatchNamespacedCSIStorageCapacityAsync(string name, string namespaceParameter, bool? allowWatchBookmarks = null, string continueParameter = null, string fieldSelector = null, string labelSelector = null, int? limit = null, bool? pretty = null, string resourceVersion = null, string resourceVersionMatch = null, int? timeoutSeconds = null, bool? watch = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, V1beta1CSIStorageCapacity> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<int> NamespacedPodExecAsync(string name, string @namespace, string container, IEnumerable<string> command, bool tty, ExecAsyncCallback action, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Watcher<T>> WatchObjectAsync<T>(string path, string @continue = null, string fieldSelector = null, bool? includeUninitialized = null, string labelSelector = null, int? limit = null, bool? pretty = null, int? timeoutSeconds = null, string resourceVersion = null, Dictionary<string, List<string>> customHeaders = null, Action<WatchEventType, T> onEvent = null, Action<Exception> onError = null, Action onClosed = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebSocket> WebSocketNamespacedPodExecAsync(string name, string @namespace = "default", string command = null, string container = null, bool stderr = true, bool stdin = true, bool stdout = true, bool tty = true, string webSocketSubProtocol = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebSocket> WebSocketNamespacedPodExecAsync(string name, string @namespace = "default", IEnumerable<string> command = null, string container = null, bool stderr = true, bool stdin = true, bool stdout = true, bool tty = true, string webSocketSubProtocol = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IStreamDemuxer> MuxedStreamNamespacedPodExecAsync(string name, string @namespace = "default", IEnumerable<string> command = null, string container = null, bool stderr = true, bool stdin = true, bool stdout = true, bool tty = true, string webSocketSubProtocol = "v4.channel.k8s.io", Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebSocket> WebSocketNamespacedPodPortForwardAsync(string name, string @namespace, IEnumerable<int> ports, string webSocketSubProtocol = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebSocket> WebSocketNamespacedPodAttachAsync(string name, string @namespace, string container = null, bool stderr = true, bool stdin = false, bool stdout = true, bool tty = false, string webSocketSubProtocol = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}