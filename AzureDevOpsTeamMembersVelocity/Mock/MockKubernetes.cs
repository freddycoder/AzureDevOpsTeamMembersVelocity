using k8s;
using k8s.Models;
using Microsoft.Rest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace AzureDevOpsTeamMembersVelocity.Mock
{
    internal class MockKubernetes : IKubernetes
    {
        private bool disposedValue;

        Uri IKubernetes.BaseUri { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        JsonSerializerSettings IKubernetes.SerializationSettings => throw new NotImplementedException();

        JsonSerializerSettings IKubernetes.DeserializationSettings => throw new NotImplementedException();

        ServiceClientCredentials IKubernetes.Credentials => throw new NotImplementedException();

        HttpClient IKubernetes.HttpClient => throw new NotImplementedException();

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectDeleteNamespacedPodProxyWithHttpMessagesAsync(string name, string namespaceParameter, string path, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectDeleteNamespacedPodProxyWithPathWithHttpMessagesAsync(string name, string namespaceParameter, string path, string path1, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectDeleteNamespacedServiceProxyWithHttpMessagesAsync(string name, string namespaceParameter, string path, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectDeleteNamespacedServiceProxyWithPathWithHttpMessagesAsync(string name, string namespaceParameter, string path, string path1, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectDeleteNodeProxyWithHttpMessagesAsync(string name, string path, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectDeleteNodeProxyWithPathWithHttpMessagesAsync(string name, string path, string path1, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectGetNamespacedPodAttachWithHttpMessagesAsync(string name, string namespaceParameter, string container, bool? stderr, bool? stdin, bool? stdout, bool? tty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectGetNamespacedPodExecWithHttpMessagesAsync(string name, string namespaceParameter, string command, string container, bool? stderr, bool? stdin, bool? stdout, bool? tty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectGetNamespacedPodPortforwardWithHttpMessagesAsync(string name, string namespaceParameter, int? ports, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectGetNamespacedPodProxyWithHttpMessagesAsync(string name, string namespaceParameter, string path, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectGetNamespacedPodProxyWithPathWithHttpMessagesAsync(string name, string namespaceParameter, string path, string path1, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectGetNamespacedServiceProxyWithHttpMessagesAsync(string name, string namespaceParameter, string path, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectGetNamespacedServiceProxyWithPathWithHttpMessagesAsync(string name, string namespaceParameter, string path, string path1, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectGetNodeProxyWithHttpMessagesAsync(string name, string path, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectGetNodeProxyWithPathWithHttpMessagesAsync(string name, string path, string path1, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectHeadNamespacedPodProxyWithHttpMessagesAsync(string name, string namespaceParameter, string path, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectHeadNamespacedPodProxyWithPathWithHttpMessagesAsync(string name, string namespaceParameter, string path, string path1, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectHeadNamespacedServiceProxyWithHttpMessagesAsync(string name, string namespaceParameter, string path, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectHeadNamespacedServiceProxyWithPathWithHttpMessagesAsync(string name, string namespaceParameter, string path, string path1, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectHeadNodeProxyWithHttpMessagesAsync(string name, string path, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectHeadNodeProxyWithPathWithHttpMessagesAsync(string name, string path, string path1, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectPatchNamespacedPodProxyWithHttpMessagesAsync(string name, string namespaceParameter, string path, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectPatchNamespacedPodProxyWithPathWithHttpMessagesAsync(string name, string namespaceParameter, string path, string path1, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectPatchNamespacedServiceProxyWithHttpMessagesAsync(string name, string namespaceParameter, string path, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectPatchNamespacedServiceProxyWithPathWithHttpMessagesAsync(string name, string namespaceParameter, string path, string path1, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectPatchNodeProxyWithHttpMessagesAsync(string name, string path, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectPatchNodeProxyWithPathWithHttpMessagesAsync(string name, string path, string path1, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectPostNamespacedPodAttachWithHttpMessagesAsync(string name, string namespaceParameter, string container, bool? stderr, bool? stdin, bool? stdout, bool? tty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectPostNamespacedPodExecWithHttpMessagesAsync(string name, string namespaceParameter, string command, string container, bool? stderr, bool? stdin, bool? stdout, bool? tty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectPostNamespacedPodPortforwardWithHttpMessagesAsync(string name, string namespaceParameter, int? ports, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectPostNamespacedPodProxyWithHttpMessagesAsync(string name, string namespaceParameter, string path, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectPostNamespacedPodProxyWithPathWithHttpMessagesAsync(string name, string namespaceParameter, string path, string path1, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectPostNamespacedServiceProxyWithHttpMessagesAsync(string name, string namespaceParameter, string path, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectPostNamespacedServiceProxyWithPathWithHttpMessagesAsync(string name, string namespaceParameter, string path, string path1, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectPostNodeProxyWithHttpMessagesAsync(string name, string path, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectPostNodeProxyWithPathWithHttpMessagesAsync(string name, string path, string path1, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectPutNamespacedPodProxyWithHttpMessagesAsync(string name, string namespaceParameter, string path, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectPutNamespacedPodProxyWithPathWithHttpMessagesAsync(string name, string namespaceParameter, string path, string path1, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectPutNamespacedServiceProxyWithHttpMessagesAsync(string name, string namespaceParameter, string path, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectPutNamespacedServiceProxyWithPathWithHttpMessagesAsync(string name, string namespaceParameter, string path, string path1, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectPutNodeProxyWithHttpMessagesAsync(string name, string path, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ConnectPutNodeProxyWithPathWithHttpMessagesAsync(string name, string path, string path1, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1APIService>> IKubernetes.CreateAPIService1WithHttpMessagesAsync(V1beta1APIService body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIService>> IKubernetes.CreateAPIServiceWithHttpMessagesAsync(V1APIService body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CertificateSigningRequest>> IKubernetes.CreateCertificateSigningRequest1WithHttpMessagesAsync(V1beta1CertificateSigningRequest body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1CertificateSigningRequest>> IKubernetes.CreateCertificateSigningRequestWithHttpMessagesAsync(V1CertificateSigningRequest body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<object>> IKubernetes.CreateClusterCustomObjectWithHttpMessagesAsync(object body, string group, string version, string plural, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1ClusterRole>> IKubernetes.CreateClusterRole1WithHttpMessagesAsync(V1alpha1ClusterRole body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1ClusterRole>> IKubernetes.CreateClusterRole2WithHttpMessagesAsync(V1beta1ClusterRole body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1ClusterRoleBinding>> IKubernetes.CreateClusterRoleBinding1WithHttpMessagesAsync(V1alpha1ClusterRoleBinding body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1ClusterRoleBinding>> IKubernetes.CreateClusterRoleBinding2WithHttpMessagesAsync(V1beta1ClusterRoleBinding body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ClusterRoleBinding>> IKubernetes.CreateClusterRoleBindingWithHttpMessagesAsync(V1ClusterRoleBinding body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ClusterRole>> IKubernetes.CreateClusterRoleWithHttpMessagesAsync(V1ClusterRole body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CSIDriver>> IKubernetes.CreateCSIDriver1WithHttpMessagesAsync(V1beta1CSIDriver body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1CSIDriver>> IKubernetes.CreateCSIDriverWithHttpMessagesAsync(V1CSIDriver body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CSINode>> IKubernetes.CreateCSINode1WithHttpMessagesAsync(V1beta1CSINode body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1CSINode>> IKubernetes.CreateCSINodeWithHttpMessagesAsync(V1CSINode body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CustomResourceDefinition>> IKubernetes.CreateCustomResourceDefinition1WithHttpMessagesAsync(V1beta1CustomResourceDefinition body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1CustomResourceDefinition>> IKubernetes.CreateCustomResourceDefinitionWithHttpMessagesAsync(V1CustomResourceDefinition body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1FlowSchema>> IKubernetes.CreateFlowSchemaWithHttpMessagesAsync(V1beta1FlowSchema body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1IngressClass>> IKubernetes.CreateIngressClass1WithHttpMessagesAsync(V1beta1IngressClass body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1IngressClass>> IKubernetes.CreateIngressClassWithHttpMessagesAsync(V1IngressClass body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1MutatingWebhookConfiguration>> IKubernetes.CreateMutatingWebhookConfiguration1WithHttpMessagesAsync(V1beta1MutatingWebhookConfiguration body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1MutatingWebhookConfiguration>> IKubernetes.CreateMutatingWebhookConfigurationWithHttpMessagesAsync(V1MutatingWebhookConfiguration body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Binding>> IKubernetes.CreateNamespacedBindingWithHttpMessagesAsync(V1Binding body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ConfigMap>> IKubernetes.CreateNamespacedConfigMapWithHttpMessagesAsync(V1ConfigMap body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ControllerRevision>> IKubernetes.CreateNamespacedControllerRevisionWithHttpMessagesAsync(V1ControllerRevision body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CronJob>> IKubernetes.CreateNamespacedCronJob1WithHttpMessagesAsync(V1beta1CronJob body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1CronJob>> IKubernetes.CreateNamespacedCronJobWithHttpMessagesAsync(V1CronJob body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CSIStorageCapacity>> IKubernetes.CreateNamespacedCSIStorageCapacity1WithHttpMessagesAsync(V1beta1CSIStorageCapacity body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1CSIStorageCapacity>> IKubernetes.CreateNamespacedCSIStorageCapacityWithHttpMessagesAsync(V1alpha1CSIStorageCapacity body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<object>> IKubernetes.CreateNamespacedCustomObjectWithHttpMessagesAsync(object body, string group, string version, string namespaceParameter, string plural, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1DaemonSet>> IKubernetes.CreateNamespacedDaemonSetWithHttpMessagesAsync(V1DaemonSet body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Deployment>> IKubernetes.CreateNamespacedDeploymentWithHttpMessagesAsync(V1Deployment body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1EndpointSlice>> IKubernetes.CreateNamespacedEndpointSlice1WithHttpMessagesAsync(V1beta1EndpointSlice body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1EndpointSlice>> IKubernetes.CreateNamespacedEndpointSliceWithHttpMessagesAsync(V1EndpointSlice body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Endpoints>> IKubernetes.CreateNamespacedEndpointsWithHttpMessagesAsync(V1Endpoints body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Eventsv1Event>> IKubernetes.CreateNamespacedEvent1WithHttpMessagesAsync(Eventsv1Event body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1Event>> IKubernetes.CreateNamespacedEvent2WithHttpMessagesAsync(V1beta1Event body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Corev1Event>> IKubernetes.CreateNamespacedEventWithHttpMessagesAsync(Corev1Event body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V2beta1HorizontalPodAutoscaler>> IKubernetes.CreateNamespacedHorizontalPodAutoscaler1WithHttpMessagesAsync(V2beta1HorizontalPodAutoscaler body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V2beta2HorizontalPodAutoscaler>> IKubernetes.CreateNamespacedHorizontalPodAutoscaler2WithHttpMessagesAsync(V2beta2HorizontalPodAutoscaler body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1HorizontalPodAutoscaler>> IKubernetes.CreateNamespacedHorizontalPodAutoscalerWithHttpMessagesAsync(V1HorizontalPodAutoscaler body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Ingress>> IKubernetes.CreateNamespacedIngress1WithHttpMessagesAsync(V1Ingress body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Networkingv1beta1Ingress>> IKubernetes.CreateNamespacedIngress2WithHttpMessagesAsync(Networkingv1beta1Ingress body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Extensionsv1beta1Ingress>> IKubernetes.CreateNamespacedIngressWithHttpMessagesAsync(Extensionsv1beta1Ingress body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Job>> IKubernetes.CreateNamespacedJobWithHttpMessagesAsync(V1Job body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1Lease>> IKubernetes.CreateNamespacedLease1WithHttpMessagesAsync(V1beta1Lease body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Lease>> IKubernetes.CreateNamespacedLeaseWithHttpMessagesAsync(V1Lease body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1LimitRange>> IKubernetes.CreateNamespacedLimitRangeWithHttpMessagesAsync(V1LimitRange body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1LocalSubjectAccessReview>> IKubernetes.CreateNamespacedLocalSubjectAccessReview1WithHttpMessagesAsync(V1beta1LocalSubjectAccessReview body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1LocalSubjectAccessReview>> IKubernetes.CreateNamespacedLocalSubjectAccessReviewWithHttpMessagesAsync(V1LocalSubjectAccessReview body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1NetworkPolicy>> IKubernetes.CreateNamespacedNetworkPolicyWithHttpMessagesAsync(V1NetworkPolicy body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PersistentVolumeClaim>> IKubernetes.CreateNamespacedPersistentVolumeClaimWithHttpMessagesAsync(V1PersistentVolumeClaim body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Binding>> IKubernetes.CreateNamespacedPodBindingWithHttpMessagesAsync(V1Binding body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1PodDisruptionBudget>> IKubernetes.CreateNamespacedPodDisruptionBudget1WithHttpMessagesAsync(V1beta1PodDisruptionBudget body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PodDisruptionBudget>> IKubernetes.CreateNamespacedPodDisruptionBudgetWithHttpMessagesAsync(V1PodDisruptionBudget body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1Eviction>> IKubernetes.CreateNamespacedPodEvictionWithHttpMessagesAsync(V1beta1Eviction body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PodTemplate>> IKubernetes.CreateNamespacedPodTemplateWithHttpMessagesAsync(V1PodTemplate body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Pod>> IKubernetes.CreateNamespacedPodWithHttpMessagesAsync(V1Pod body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ReplicaSet>> IKubernetes.CreateNamespacedReplicaSetWithHttpMessagesAsync(V1ReplicaSet body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ReplicationController>> IKubernetes.CreateNamespacedReplicationControllerWithHttpMessagesAsync(V1ReplicationController body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ResourceQuota>> IKubernetes.CreateNamespacedResourceQuotaWithHttpMessagesAsync(V1ResourceQuota body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1Role>> IKubernetes.CreateNamespacedRole1WithHttpMessagesAsync(V1alpha1Role body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1Role>> IKubernetes.CreateNamespacedRole2WithHttpMessagesAsync(V1beta1Role body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1RoleBinding>> IKubernetes.CreateNamespacedRoleBinding1WithHttpMessagesAsync(V1alpha1RoleBinding body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1RoleBinding>> IKubernetes.CreateNamespacedRoleBinding2WithHttpMessagesAsync(V1beta1RoleBinding body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1RoleBinding>> IKubernetes.CreateNamespacedRoleBindingWithHttpMessagesAsync(V1RoleBinding body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Role>> IKubernetes.CreateNamespacedRoleWithHttpMessagesAsync(V1Role body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Secret>> IKubernetes.CreateNamespacedSecretWithHttpMessagesAsync(V1Secret body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Authenticationv1TokenRequest>> IKubernetes.CreateNamespacedServiceAccountTokenWithHttpMessagesAsync(Authenticationv1TokenRequest body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ServiceAccount>> IKubernetes.CreateNamespacedServiceAccountWithHttpMessagesAsync(V1ServiceAccount body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Service>> IKubernetes.CreateNamespacedServiceWithHttpMessagesAsync(V1Service body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1StatefulSet>> IKubernetes.CreateNamespacedStatefulSetWithHttpMessagesAsync(V1StatefulSet body, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Namespace>> IKubernetes.CreateNamespaceWithHttpMessagesAsync(V1Namespace body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Node>> IKubernetes.CreateNodeWithHttpMessagesAsync(V1Node body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PersistentVolume>> IKubernetes.CreatePersistentVolumeWithHttpMessagesAsync(V1PersistentVolume body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1PodSecurityPolicy>> IKubernetes.CreatePodSecurityPolicyWithHttpMessagesAsync(V1beta1PodSecurityPolicy body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1PriorityClass>> IKubernetes.CreatePriorityClass1WithHttpMessagesAsync(V1alpha1PriorityClass body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1PriorityClass>> IKubernetes.CreatePriorityClass2WithHttpMessagesAsync(V1beta1PriorityClass body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PriorityClass>> IKubernetes.CreatePriorityClassWithHttpMessagesAsync(V1PriorityClass body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1PriorityLevelConfiguration>> IKubernetes.CreatePriorityLevelConfigurationWithHttpMessagesAsync(V1beta1PriorityLevelConfiguration body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1RuntimeClass>> IKubernetes.CreateRuntimeClass1WithHttpMessagesAsync(V1alpha1RuntimeClass body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1RuntimeClass>> IKubernetes.CreateRuntimeClass2WithHttpMessagesAsync(V1beta1RuntimeClass body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1RuntimeClass>> IKubernetes.CreateRuntimeClassWithHttpMessagesAsync(V1RuntimeClass body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1SelfSubjectAccessReview>> IKubernetes.CreateSelfSubjectAccessReview1WithHttpMessagesAsync(V1beta1SelfSubjectAccessReview body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1SelfSubjectAccessReview>> IKubernetes.CreateSelfSubjectAccessReviewWithHttpMessagesAsync(V1SelfSubjectAccessReview body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1SelfSubjectRulesReview>> IKubernetes.CreateSelfSubjectRulesReview1WithHttpMessagesAsync(V1beta1SelfSubjectRulesReview body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1SelfSubjectRulesReview>> IKubernetes.CreateSelfSubjectRulesReviewWithHttpMessagesAsync(V1SelfSubjectRulesReview body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1StorageClass>> IKubernetes.CreateStorageClass1WithHttpMessagesAsync(V1beta1StorageClass body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1StorageClass>> IKubernetes.CreateStorageClassWithHttpMessagesAsync(V1StorageClass body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1StorageVersion>> IKubernetes.CreateStorageVersionWithHttpMessagesAsync(V1alpha1StorageVersion body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1SubjectAccessReview>> IKubernetes.CreateSubjectAccessReview1WithHttpMessagesAsync(V1beta1SubjectAccessReview body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1SubjectAccessReview>> IKubernetes.CreateSubjectAccessReviewWithHttpMessagesAsync(V1SubjectAccessReview body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1TokenReview>> IKubernetes.CreateTokenReview1WithHttpMessagesAsync(V1beta1TokenReview body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1TokenReview>> IKubernetes.CreateTokenReviewWithHttpMessagesAsync(V1TokenReview body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1ValidatingWebhookConfiguration>> IKubernetes.CreateValidatingWebhookConfiguration1WithHttpMessagesAsync(V1beta1ValidatingWebhookConfiguration body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ValidatingWebhookConfiguration>> IKubernetes.CreateValidatingWebhookConfigurationWithHttpMessagesAsync(V1ValidatingWebhookConfiguration body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1VolumeAttachment>> IKubernetes.CreateVolumeAttachment1WithHttpMessagesAsync(V1alpha1VolumeAttachment body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1VolumeAttachment>> IKubernetes.CreateVolumeAttachment2WithHttpMessagesAsync(V1beta1VolumeAttachment body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1VolumeAttachment>> IKubernetes.CreateVolumeAttachmentWithHttpMessagesAsync(V1VolumeAttachment body, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteAPIService1WithHttpMessagesAsync(string name, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteAPIServiceWithHttpMessagesAsync(string name, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCertificateSigningRequest1WithHttpMessagesAsync(string name, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCertificateSigningRequestWithHttpMessagesAsync(string name, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<object>> IKubernetes.DeleteClusterCustomObjectWithHttpMessagesAsync(string group, string version, string plural, string name, V1DeleteOptions body, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string dryRun, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteClusterRole1WithHttpMessagesAsync(string name, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteClusterRole2WithHttpMessagesAsync(string name, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteClusterRoleBinding1WithHttpMessagesAsync(string name, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteClusterRoleBinding2WithHttpMessagesAsync(string name, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteClusterRoleBindingWithHttpMessagesAsync(string name, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteClusterRoleWithHttpMessagesAsync(string name, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionAPIService1WithHttpMessagesAsync(V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionAPIServiceWithHttpMessagesAsync(V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionCertificateSigningRequest1WithHttpMessagesAsync(V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionCertificateSigningRequestWithHttpMessagesAsync(V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<object>> IKubernetes.DeleteCollectionClusterCustomObjectWithHttpMessagesAsync(string group, string version, string plural, V1DeleteOptions body, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string dryRun, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionClusterRole1WithHttpMessagesAsync(V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionClusterRole2WithHttpMessagesAsync(V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionClusterRoleBinding1WithHttpMessagesAsync(V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionClusterRoleBinding2WithHttpMessagesAsync(V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionClusterRoleBindingWithHttpMessagesAsync(V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionClusterRoleWithHttpMessagesAsync(V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionCSIDriver1WithHttpMessagesAsync(V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionCSIDriverWithHttpMessagesAsync(V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionCSINode1WithHttpMessagesAsync(V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionCSINodeWithHttpMessagesAsync(V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionCustomResourceDefinition1WithHttpMessagesAsync(V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionCustomResourceDefinitionWithHttpMessagesAsync(V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionFlowSchemaWithHttpMessagesAsync(V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionIngressClass1WithHttpMessagesAsync(V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionIngressClassWithHttpMessagesAsync(V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionMutatingWebhookConfiguration1WithHttpMessagesAsync(V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionMutatingWebhookConfigurationWithHttpMessagesAsync(V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedConfigMapWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedControllerRevisionWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedCronJob1WithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedCronJobWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedCSIStorageCapacity1WithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedCSIStorageCapacityWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<object>> IKubernetes.DeleteCollectionNamespacedCustomObjectWithHttpMessagesAsync(string group, string version, string namespaceParameter, string plural, V1DeleteOptions body, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string dryRun, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedDaemonSetWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedDeploymentWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedEndpointSlice1WithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedEndpointSliceWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedEndpointsWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedEvent1WithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedEvent2WithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedEventWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedHorizontalPodAutoscaler1WithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedHorizontalPodAutoscaler2WithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedHorizontalPodAutoscalerWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedIngress1WithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedIngress2WithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedIngressWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedJobWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedLease1WithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedLeaseWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedLimitRangeWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedNetworkPolicyWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedPersistentVolumeClaimWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedPodDisruptionBudget1WithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedPodDisruptionBudgetWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedPodTemplateWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedPodWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedReplicaSetWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedReplicationControllerWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedResourceQuotaWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedRole1WithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedRole2WithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedRoleBinding1WithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedRoleBinding2WithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedRoleBindingWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedRoleWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedSecretWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedServiceAccountWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNamespacedStatefulSetWithHttpMessagesAsync(string namespaceParameter, V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionNodeWithHttpMessagesAsync(V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionPersistentVolumeWithHttpMessagesAsync(V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionPodSecurityPolicyWithHttpMessagesAsync(V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionPriorityClass1WithHttpMessagesAsync(V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionPriorityClass2WithHttpMessagesAsync(V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionPriorityClassWithHttpMessagesAsync(V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionPriorityLevelConfigurationWithHttpMessagesAsync(V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionRuntimeClass1WithHttpMessagesAsync(V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionRuntimeClass2WithHttpMessagesAsync(V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionRuntimeClassWithHttpMessagesAsync(V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionStorageClass1WithHttpMessagesAsync(V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionStorageClassWithHttpMessagesAsync(V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionStorageVersionWithHttpMessagesAsync(V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionValidatingWebhookConfiguration1WithHttpMessagesAsync(V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionValidatingWebhookConfigurationWithHttpMessagesAsync(V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionVolumeAttachment1WithHttpMessagesAsync(V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionVolumeAttachment2WithHttpMessagesAsync(V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCollectionVolumeAttachmentWithHttpMessagesAsync(V1DeleteOptions body, string continueParameter, string dryRun, string fieldSelector, int? gracePeriodSeconds, string labelSelector, int? limit, bool? orphanDependents, string propagationPolicy, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CSIDriver>> IKubernetes.DeleteCSIDriver1WithHttpMessagesAsync(string name, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1CSIDriver>> IKubernetes.DeleteCSIDriverWithHttpMessagesAsync(string name, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CSINode>> IKubernetes.DeleteCSINode1WithHttpMessagesAsync(string name, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1CSINode>> IKubernetes.DeleteCSINodeWithHttpMessagesAsync(string name, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCustomResourceDefinition1WithHttpMessagesAsync(string name, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteCustomResourceDefinitionWithHttpMessagesAsync(string name, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteFlowSchemaWithHttpMessagesAsync(string name, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteIngressClass1WithHttpMessagesAsync(string name, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteIngressClassWithHttpMessagesAsync(string name, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteMutatingWebhookConfiguration1WithHttpMessagesAsync(string name, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteMutatingWebhookConfigurationWithHttpMessagesAsync(string name, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteNamespacedConfigMapWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteNamespacedControllerRevisionWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteNamespacedCronJob1WithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteNamespacedCronJobWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteNamespacedCSIStorageCapacity1WithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteNamespacedCSIStorageCapacityWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<object>> IKubernetes.DeleteNamespacedCustomObjectWithHttpMessagesAsync(string group, string version, string namespaceParameter, string plural, string name, V1DeleteOptions body, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string dryRun, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteNamespacedDaemonSetWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteNamespacedDeploymentWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteNamespacedEndpointSlice1WithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteNamespacedEndpointSliceWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteNamespacedEndpointsWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteNamespacedEvent1WithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteNamespacedEvent2WithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteNamespacedEventWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteNamespacedHorizontalPodAutoscaler1WithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteNamespacedHorizontalPodAutoscaler2WithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteNamespacedHorizontalPodAutoscalerWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteNamespacedIngress1WithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteNamespacedIngress2WithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteNamespacedIngressWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteNamespacedJobWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteNamespacedLease1WithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteNamespacedLeaseWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteNamespacedLimitRangeWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteNamespacedNetworkPolicyWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PersistentVolumeClaim>> IKubernetes.DeleteNamespacedPersistentVolumeClaimWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteNamespacedPodDisruptionBudget1WithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteNamespacedPodDisruptionBudgetWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PodTemplate>> IKubernetes.DeleteNamespacedPodTemplateWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Pod>> IKubernetes.DeleteNamespacedPodWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteNamespacedReplicaSetWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteNamespacedReplicationControllerWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ResourceQuota>> IKubernetes.DeleteNamespacedResourceQuotaWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteNamespacedRole1WithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteNamespacedRole2WithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteNamespacedRoleBinding1WithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteNamespacedRoleBinding2WithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteNamespacedRoleBindingWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteNamespacedRoleWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteNamespacedSecretWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ServiceAccount>> IKubernetes.DeleteNamespacedServiceAccountWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteNamespacedServiceWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteNamespacedStatefulSetWithHttpMessagesAsync(string name, string namespaceParameter, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteNamespaceWithHttpMessagesAsync(string name, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteNodeWithHttpMessagesAsync(string name, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PersistentVolume>> IKubernetes.DeletePersistentVolumeWithHttpMessagesAsync(string name, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1PodSecurityPolicy>> IKubernetes.DeletePodSecurityPolicyWithHttpMessagesAsync(string name, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeletePriorityClass1WithHttpMessagesAsync(string name, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeletePriorityClass2WithHttpMessagesAsync(string name, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeletePriorityClassWithHttpMessagesAsync(string name, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeletePriorityLevelConfigurationWithHttpMessagesAsync(string name, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteRuntimeClass1WithHttpMessagesAsync(string name, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteRuntimeClass2WithHttpMessagesAsync(string name, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteRuntimeClassWithHttpMessagesAsync(string name, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1StorageClass>> IKubernetes.DeleteStorageClass1WithHttpMessagesAsync(string name, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1StorageClass>> IKubernetes.DeleteStorageClassWithHttpMessagesAsync(string name, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteStorageVersionWithHttpMessagesAsync(string name, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteValidatingWebhookConfiguration1WithHttpMessagesAsync(string name, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Status>> IKubernetes.DeleteValidatingWebhookConfigurationWithHttpMessagesAsync(string name, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1VolumeAttachment>> IKubernetes.DeleteVolumeAttachment1WithHttpMessagesAsync(string name, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1VolumeAttachment>> IKubernetes.DeleteVolumeAttachment2WithHttpMessagesAsync(string name, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1VolumeAttachment>> IKubernetes.DeleteVolumeAttachmentWithHttpMessagesAsync(string name, V1DeleteOptions body, string dryRun, int? gracePeriodSeconds, bool? orphanDependents, string propagationPolicy, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIGroup>> IKubernetes.GetAPIGroup10WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIGroup>> IKubernetes.GetAPIGroup11WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIGroup>> IKubernetes.GetAPIGroup12WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIGroup>> IKubernetes.GetAPIGroup13WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIGroup>> IKubernetes.GetAPIGroup14WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIGroup>> IKubernetes.GetAPIGroup15WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIGroup>> IKubernetes.GetAPIGroup16WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIGroup>> IKubernetes.GetAPIGroup17WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIGroup>> IKubernetes.GetAPIGroup18WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIGroup>> IKubernetes.GetAPIGroup19WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIGroup>> IKubernetes.GetAPIGroup1WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIGroup>> IKubernetes.GetAPIGroup20WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIGroup>> IKubernetes.GetAPIGroup2WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIGroup>> IKubernetes.GetAPIGroup3WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIGroup>> IKubernetes.GetAPIGroup4WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIGroup>> IKubernetes.GetAPIGroup5WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIGroup>> IKubernetes.GetAPIGroup6WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIGroup>> IKubernetes.GetAPIGroup7WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIGroup>> IKubernetes.GetAPIGroup8WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIGroup>> IKubernetes.GetAPIGroup9WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIGroup>> IKubernetes.GetAPIGroupWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources10WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources11WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources12WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources13WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources14WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources15WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources16WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources17WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources18WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources19WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources1WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources20WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources21WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources22WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources23WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources24WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources25WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources26WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources27WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources28WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources29WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources2WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources30WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources31WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources32WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources33WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources34WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources35WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources36WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources37WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources38WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources39WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources3WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources40WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources41WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources42WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources43WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources4WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources5WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources6WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources7WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources8WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResources9WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIResourceList>> IKubernetes.GetAPIResourcesWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIGroupList>> IKubernetes.GetAPIVersions1WithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIVersions>> IKubernetes.GetAPIVersionsWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<object>> IKubernetes.GetClusterCustomObjectScaleWithHttpMessagesAsync(string group, string version, string plural, string name, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<object>> IKubernetes.GetClusterCustomObjectStatusWithHttpMessagesAsync(string group, string version, string plural, string name, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<object>> IKubernetes.GetClusterCustomObjectWithHttpMessagesAsync(string group, string version, string plural, string name, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<VersionInfo>> IKubernetes.GetCodeWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<object>> IKubernetes.GetNamespacedCustomObjectScaleWithHttpMessagesAsync(string group, string version, string namespaceParameter, string plural, string name, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<object>> IKubernetes.GetNamespacedCustomObjectStatusWithHttpMessagesAsync(string group, string version, string namespaceParameter, string plural, string name, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<object>> IKubernetes.GetNamespacedCustomObjectWithHttpMessagesAsync(string group, string version, string namespaceParameter, string plural, string name, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<string>> IKubernetes.GetServiceAccountIssuerOpenIDConfigurationWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<string>> IKubernetes.GetServiceAccountIssuerOpenIDKeysetWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1APIServiceList>> IKubernetes.ListAPIService1WithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIServiceList>> IKubernetes.ListAPIServiceWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CertificateSigningRequestList>> IKubernetes.ListCertificateSigningRequest1WithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1CertificateSigningRequestList>> IKubernetes.ListCertificateSigningRequestWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<object>> IKubernetes.ListClusterCustomObjectWithHttpMessagesAsync(string group, string version, string plural, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1ClusterRoleList>> IKubernetes.ListClusterRole1WithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1ClusterRoleList>> IKubernetes.ListClusterRole2WithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1ClusterRoleBindingList>> IKubernetes.ListClusterRoleBinding1WithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1ClusterRoleBindingList>> IKubernetes.ListClusterRoleBinding2WithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ClusterRoleBindingList>> IKubernetes.ListClusterRoleBindingWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ClusterRoleList>> IKubernetes.ListClusterRoleWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ComponentStatusList>> IKubernetes.ListComponentStatusWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ConfigMapList>> IKubernetes.ListConfigMapForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ControllerRevisionList>> IKubernetes.ListControllerRevisionForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CronJobList>> IKubernetes.ListCronJobForAllNamespaces1WithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1CronJobList>> IKubernetes.ListCronJobForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CSIDriverList>> IKubernetes.ListCSIDriver1WithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1CSIDriverList>> IKubernetes.ListCSIDriverWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CSINodeList>> IKubernetes.ListCSINode1WithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1CSINodeList>> IKubernetes.ListCSINodeWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CSIStorageCapacityList>> IKubernetes.ListCSIStorageCapacityForAllNamespaces1WithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1CSIStorageCapacityList>> IKubernetes.ListCSIStorageCapacityForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CustomResourceDefinitionList>> IKubernetes.ListCustomResourceDefinition1WithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1CustomResourceDefinitionList>> IKubernetes.ListCustomResourceDefinitionWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1DaemonSetList>> IKubernetes.ListDaemonSetForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1DeploymentList>> IKubernetes.ListDeploymentForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            return Task.FromResult(new HttpOperationResponse<V1DeploymentList>
            {
                Body = new V1DeploymentList
                {
                    Items = new List<V1Deployment>()
                }
            });
        }

        Task<HttpOperationResponse<V1EndpointsList>> IKubernetes.ListEndpointsForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1EndpointSliceList>> IKubernetes.ListEndpointSliceForAllNamespaces1WithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1EndpointSliceList>> IKubernetes.ListEndpointSliceForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Eventsv1EventList>> IKubernetes.ListEventForAllNamespaces1WithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1EventList>> IKubernetes.ListEventForAllNamespaces2WithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Corev1EventList>> IKubernetes.ListEventForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1FlowSchemaList>> IKubernetes.ListFlowSchemaWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V2beta1HorizontalPodAutoscalerList>> IKubernetes.ListHorizontalPodAutoscalerForAllNamespaces1WithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V2beta2HorizontalPodAutoscalerList>> IKubernetes.ListHorizontalPodAutoscalerForAllNamespaces2WithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1HorizontalPodAutoscalerList>> IKubernetes.ListHorizontalPodAutoscalerForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1IngressClassList>> IKubernetes.ListIngressClass1WithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1IngressClassList>> IKubernetes.ListIngressClassWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1IngressList>> IKubernetes.ListIngressForAllNamespaces1WithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Networkingv1beta1IngressList>> IKubernetes.ListIngressForAllNamespaces2WithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Extensionsv1beta1IngressList>> IKubernetes.ListIngressForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1JobList>> IKubernetes.ListJobForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1LeaseList>> IKubernetes.ListLeaseForAllNamespaces1WithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1LeaseList>> IKubernetes.ListLeaseForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1LimitRangeList>> IKubernetes.ListLimitRangeForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1MutatingWebhookConfigurationList>> IKubernetes.ListMutatingWebhookConfiguration1WithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1MutatingWebhookConfigurationList>> IKubernetes.ListMutatingWebhookConfigurationWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ConfigMapList>> IKubernetes.ListNamespacedConfigMapWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ControllerRevisionList>> IKubernetes.ListNamespacedControllerRevisionWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CronJobList>> IKubernetes.ListNamespacedCronJob1WithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1CronJobList>> IKubernetes.ListNamespacedCronJobWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CSIStorageCapacityList>> IKubernetes.ListNamespacedCSIStorageCapacity1WithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1CSIStorageCapacityList>> IKubernetes.ListNamespacedCSIStorageCapacityWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<object>> IKubernetes.ListNamespacedCustomObjectWithHttpMessagesAsync(string group, string version, string namespaceParameter, string plural, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1DaemonSetList>> IKubernetes.ListNamespacedDaemonSetWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1DeploymentList>> IKubernetes.ListNamespacedDeploymentWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1EndpointSliceList>> IKubernetes.ListNamespacedEndpointSlice1WithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1EndpointSliceList>> IKubernetes.ListNamespacedEndpointSliceWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1EndpointsList>> IKubernetes.ListNamespacedEndpointsWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Eventsv1EventList>> IKubernetes.ListNamespacedEvent1WithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1EventList>> IKubernetes.ListNamespacedEvent2WithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Corev1EventList>> IKubernetes.ListNamespacedEventWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V2beta1HorizontalPodAutoscalerList>> IKubernetes.ListNamespacedHorizontalPodAutoscaler1WithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V2beta2HorizontalPodAutoscalerList>> IKubernetes.ListNamespacedHorizontalPodAutoscaler2WithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1HorizontalPodAutoscalerList>> IKubernetes.ListNamespacedHorizontalPodAutoscalerWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1IngressList>> IKubernetes.ListNamespacedIngress1WithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Networkingv1beta1IngressList>> IKubernetes.ListNamespacedIngress2WithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Extensionsv1beta1IngressList>> IKubernetes.ListNamespacedIngressWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1JobList>> IKubernetes.ListNamespacedJobWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1LeaseList>> IKubernetes.ListNamespacedLease1WithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1LeaseList>> IKubernetes.ListNamespacedLeaseWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1LimitRangeList>> IKubernetes.ListNamespacedLimitRangeWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1NetworkPolicyList>> IKubernetes.ListNamespacedNetworkPolicyWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PersistentVolumeClaimList>> IKubernetes.ListNamespacedPersistentVolumeClaimWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1PodDisruptionBudgetList>> IKubernetes.ListNamespacedPodDisruptionBudget1WithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PodDisruptionBudgetList>> IKubernetes.ListNamespacedPodDisruptionBudgetWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PodTemplateList>> IKubernetes.ListNamespacedPodTemplateWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PodList>> IKubernetes.ListNamespacedPodWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ReplicaSetList>> IKubernetes.ListNamespacedReplicaSetWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ReplicationControllerList>> IKubernetes.ListNamespacedReplicationControllerWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ResourceQuotaList>> IKubernetes.ListNamespacedResourceQuotaWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1RoleList>> IKubernetes.ListNamespacedRole1WithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1RoleList>> IKubernetes.ListNamespacedRole2WithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1RoleBindingList>> IKubernetes.ListNamespacedRoleBinding1WithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1RoleBindingList>> IKubernetes.ListNamespacedRoleBinding2WithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1RoleBindingList>> IKubernetes.ListNamespacedRoleBindingWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1RoleList>> IKubernetes.ListNamespacedRoleWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1SecretList>> IKubernetes.ListNamespacedSecretWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ServiceAccountList>> IKubernetes.ListNamespacedServiceAccountWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ServiceList>> IKubernetes.ListNamespacedServiceWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1StatefulSetList>> IKubernetes.ListNamespacedStatefulSetWithHttpMessagesAsync(string namespaceParameter, bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1NamespaceList>> IKubernetes.ListNamespaceWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            return Task.FromResult(new HttpOperationResponse<V1NamespaceList>
            {
                Body = new V1NamespaceList
                {
                    Items = new List<V1Namespace>()
                }
            });
        }

        Task<HttpOperationResponse<V1NetworkPolicyList>> IKubernetes.ListNetworkPolicyForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1NodeList>> IKubernetes.ListNodeWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PersistentVolumeClaimList>> IKubernetes.ListPersistentVolumeClaimForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PersistentVolumeList>> IKubernetes.ListPersistentVolumeWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1PodDisruptionBudgetList>> IKubernetes.ListPodDisruptionBudgetForAllNamespaces1WithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PodDisruptionBudgetList>> IKubernetes.ListPodDisruptionBudgetForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PodList>> IKubernetes.ListPodForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1PodSecurityPolicyList>> IKubernetes.ListPodSecurityPolicyWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PodTemplateList>> IKubernetes.ListPodTemplateForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1PriorityClassList>> IKubernetes.ListPriorityClass1WithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1PriorityClassList>> IKubernetes.ListPriorityClass2WithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PriorityClassList>> IKubernetes.ListPriorityClassWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1PriorityLevelConfigurationList>> IKubernetes.ListPriorityLevelConfigurationWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ReplicaSetList>> IKubernetes.ListReplicaSetForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ReplicationControllerList>> IKubernetes.ListReplicationControllerForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ResourceQuotaList>> IKubernetes.ListResourceQuotaForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1RoleBindingList>> IKubernetes.ListRoleBindingForAllNamespaces1WithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1RoleBindingList>> IKubernetes.ListRoleBindingForAllNamespaces2WithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1RoleBindingList>> IKubernetes.ListRoleBindingForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1RoleList>> IKubernetes.ListRoleForAllNamespaces1WithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1RoleList>> IKubernetes.ListRoleForAllNamespaces2WithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1RoleList>> IKubernetes.ListRoleForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1RuntimeClassList>> IKubernetes.ListRuntimeClass1WithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1RuntimeClassList>> IKubernetes.ListRuntimeClass2WithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1RuntimeClassList>> IKubernetes.ListRuntimeClassWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1SecretList>> IKubernetes.ListSecretForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ServiceAccountList>> IKubernetes.ListServiceAccountForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ServiceList>> IKubernetes.ListServiceForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1StatefulSetList>> IKubernetes.ListStatefulSetForAllNamespacesWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1StorageClassList>> IKubernetes.ListStorageClass1WithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1StorageClassList>> IKubernetes.ListStorageClassWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1StorageVersionList>> IKubernetes.ListStorageVersionWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1ValidatingWebhookConfigurationList>> IKubernetes.ListValidatingWebhookConfiguration1WithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ValidatingWebhookConfigurationList>> IKubernetes.ListValidatingWebhookConfigurationWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1VolumeAttachmentList>> IKubernetes.ListVolumeAttachment1WithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1VolumeAttachmentList>> IKubernetes.ListVolumeAttachment2WithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1VolumeAttachmentList>> IKubernetes.ListVolumeAttachmentWithHttpMessagesAsync(bool? allowWatchBookmarks, string continueParameter, string fieldSelector, string labelSelector, int? limit, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse> IKubernetes.LogFileHandlerWithHttpMessagesAsync(string logpath, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse> IKubernetes.LogFileListHandlerWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<IStreamDemuxer> IKubernetes.MuxedStreamNamespacedPodExecAsync(string name, string @namespace, IEnumerable<string> command, string container, bool stderr, bool stdin, bool stdout, bool tty, string webSocketSubProtocol, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<int> IKubernetes.NamespacedPodExecAsync(string name, string @namespace, string container, IEnumerable<string> command, bool tty, ExecAsyncCallback action, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1APIService>> IKubernetes.PatchAPIService1WithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1APIService>> IKubernetes.PatchAPIServiceStatus1WithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIService>> IKubernetes.PatchAPIServiceStatusWithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIService>> IKubernetes.PatchAPIServiceWithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CertificateSigningRequest>> IKubernetes.PatchCertificateSigningRequest1WithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CertificateSigningRequest>> IKubernetes.PatchCertificateSigningRequestApproval1WithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1CertificateSigningRequest>> IKubernetes.PatchCertificateSigningRequestApprovalWithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CertificateSigningRequest>> IKubernetes.PatchCertificateSigningRequestStatus1WithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1CertificateSigningRequest>> IKubernetes.PatchCertificateSigningRequestStatusWithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1CertificateSigningRequest>> IKubernetes.PatchCertificateSigningRequestWithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<object>> IKubernetes.PatchClusterCustomObjectScaleWithHttpMessagesAsync(object body, string group, string version, string plural, string name, string dryRun, string fieldManager, bool? force, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<object>> IKubernetes.PatchClusterCustomObjectStatusWithHttpMessagesAsync(object body, string group, string version, string plural, string name, string dryRun, string fieldManager, bool? force, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<object>> IKubernetes.PatchClusterCustomObjectWithHttpMessagesAsync(object body, string group, string version, string plural, string name, string dryRun, string fieldManager, bool? force, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1ClusterRole>> IKubernetes.PatchClusterRole1WithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1ClusterRole>> IKubernetes.PatchClusterRole2WithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1ClusterRoleBinding>> IKubernetes.PatchClusterRoleBinding1WithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1ClusterRoleBinding>> IKubernetes.PatchClusterRoleBinding2WithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ClusterRoleBinding>> IKubernetes.PatchClusterRoleBindingWithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ClusterRole>> IKubernetes.PatchClusterRoleWithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CSIDriver>> IKubernetes.PatchCSIDriver1WithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1CSIDriver>> IKubernetes.PatchCSIDriverWithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CSINode>> IKubernetes.PatchCSINode1WithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1CSINode>> IKubernetes.PatchCSINodeWithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CustomResourceDefinition>> IKubernetes.PatchCustomResourceDefinition1WithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CustomResourceDefinition>> IKubernetes.PatchCustomResourceDefinitionStatus1WithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1CustomResourceDefinition>> IKubernetes.PatchCustomResourceDefinitionStatusWithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1CustomResourceDefinition>> IKubernetes.PatchCustomResourceDefinitionWithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1FlowSchema>> IKubernetes.PatchFlowSchemaStatusWithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1FlowSchema>> IKubernetes.PatchFlowSchemaWithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1IngressClass>> IKubernetes.PatchIngressClass1WithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1IngressClass>> IKubernetes.PatchIngressClassWithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1MutatingWebhookConfiguration>> IKubernetes.PatchMutatingWebhookConfiguration1WithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1MutatingWebhookConfiguration>> IKubernetes.PatchMutatingWebhookConfigurationWithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ConfigMap>> IKubernetes.PatchNamespacedConfigMapWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ControllerRevision>> IKubernetes.PatchNamespacedControllerRevisionWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CronJob>> IKubernetes.PatchNamespacedCronJob1WithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CronJob>> IKubernetes.PatchNamespacedCronJobStatus1WithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1CronJob>> IKubernetes.PatchNamespacedCronJobStatusWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1CronJob>> IKubernetes.PatchNamespacedCronJobWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CSIStorageCapacity>> IKubernetes.PatchNamespacedCSIStorageCapacity1WithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1CSIStorageCapacity>> IKubernetes.PatchNamespacedCSIStorageCapacityWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<object>> IKubernetes.PatchNamespacedCustomObjectScaleWithHttpMessagesAsync(object body, string group, string version, string namespaceParameter, string plural, string name, string dryRun, string fieldManager, bool? force, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<object>> IKubernetes.PatchNamespacedCustomObjectStatusWithHttpMessagesAsync(object body, string group, string version, string namespaceParameter, string plural, string name, string dryRun, string fieldManager, bool? force, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<object>> IKubernetes.PatchNamespacedCustomObjectWithHttpMessagesAsync(object body, string group, string version, string namespaceParameter, string plural, string name, string dryRun, string fieldManager, bool? force, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1DaemonSet>> IKubernetes.PatchNamespacedDaemonSetStatusWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1DaemonSet>> IKubernetes.PatchNamespacedDaemonSetWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Scale>> IKubernetes.PatchNamespacedDeploymentScaleWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Deployment>> IKubernetes.PatchNamespacedDeploymentStatusWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Deployment>> IKubernetes.PatchNamespacedDeploymentWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1EndpointSlice>> IKubernetes.PatchNamespacedEndpointSlice1WithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1EndpointSlice>> IKubernetes.PatchNamespacedEndpointSliceWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Endpoints>> IKubernetes.PatchNamespacedEndpointsWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Eventsv1Event>> IKubernetes.PatchNamespacedEvent1WithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1Event>> IKubernetes.PatchNamespacedEvent2WithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Corev1Event>> IKubernetes.PatchNamespacedEventWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V2beta1HorizontalPodAutoscaler>> IKubernetes.PatchNamespacedHorizontalPodAutoscaler1WithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V2beta2HorizontalPodAutoscaler>> IKubernetes.PatchNamespacedHorizontalPodAutoscaler2WithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V2beta1HorizontalPodAutoscaler>> IKubernetes.PatchNamespacedHorizontalPodAutoscalerStatus1WithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V2beta2HorizontalPodAutoscaler>> IKubernetes.PatchNamespacedHorizontalPodAutoscalerStatus2WithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1HorizontalPodAutoscaler>> IKubernetes.PatchNamespacedHorizontalPodAutoscalerStatusWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1HorizontalPodAutoscaler>> IKubernetes.PatchNamespacedHorizontalPodAutoscalerWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Ingress>> IKubernetes.PatchNamespacedIngress1WithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Networkingv1beta1Ingress>> IKubernetes.PatchNamespacedIngress2WithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Ingress>> IKubernetes.PatchNamespacedIngressStatus1WithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Networkingv1beta1Ingress>> IKubernetes.PatchNamespacedIngressStatus2WithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Extensionsv1beta1Ingress>> IKubernetes.PatchNamespacedIngressStatusWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Extensionsv1beta1Ingress>> IKubernetes.PatchNamespacedIngressWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Job>> IKubernetes.PatchNamespacedJobStatusWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Job>> IKubernetes.PatchNamespacedJobWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1Lease>> IKubernetes.PatchNamespacedLease1WithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Lease>> IKubernetes.PatchNamespacedLeaseWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1LimitRange>> IKubernetes.PatchNamespacedLimitRangeWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1NetworkPolicy>> IKubernetes.PatchNamespacedNetworkPolicyWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PersistentVolumeClaim>> IKubernetes.PatchNamespacedPersistentVolumeClaimStatusWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PersistentVolumeClaim>> IKubernetes.PatchNamespacedPersistentVolumeClaimWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1PodDisruptionBudget>> IKubernetes.PatchNamespacedPodDisruptionBudget1WithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1PodDisruptionBudget>> IKubernetes.PatchNamespacedPodDisruptionBudgetStatus1WithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PodDisruptionBudget>> IKubernetes.PatchNamespacedPodDisruptionBudgetStatusWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PodDisruptionBudget>> IKubernetes.PatchNamespacedPodDisruptionBudgetWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1EphemeralContainers>> IKubernetes.PatchNamespacedPodEphemeralcontainersWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Pod>> IKubernetes.PatchNamespacedPodStatusWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PodTemplate>> IKubernetes.PatchNamespacedPodTemplateWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Pod>> IKubernetes.PatchNamespacedPodWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Scale>> IKubernetes.PatchNamespacedReplicaSetScaleWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ReplicaSet>> IKubernetes.PatchNamespacedReplicaSetStatusWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ReplicaSet>> IKubernetes.PatchNamespacedReplicaSetWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Scale>> IKubernetes.PatchNamespacedReplicationControllerScaleWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ReplicationController>> IKubernetes.PatchNamespacedReplicationControllerStatusWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ReplicationController>> IKubernetes.PatchNamespacedReplicationControllerWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ResourceQuota>> IKubernetes.PatchNamespacedResourceQuotaStatusWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ResourceQuota>> IKubernetes.PatchNamespacedResourceQuotaWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1Role>> IKubernetes.PatchNamespacedRole1WithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1Role>> IKubernetes.PatchNamespacedRole2WithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1RoleBinding>> IKubernetes.PatchNamespacedRoleBinding1WithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1RoleBinding>> IKubernetes.PatchNamespacedRoleBinding2WithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1RoleBinding>> IKubernetes.PatchNamespacedRoleBindingWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Role>> IKubernetes.PatchNamespacedRoleWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Secret>> IKubernetes.PatchNamespacedSecretWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ServiceAccount>> IKubernetes.PatchNamespacedServiceAccountWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Service>> IKubernetes.PatchNamespacedServiceStatusWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Service>> IKubernetes.PatchNamespacedServiceWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Scale>> IKubernetes.PatchNamespacedStatefulSetScaleWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1StatefulSet>> IKubernetes.PatchNamespacedStatefulSetStatusWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1StatefulSet>> IKubernetes.PatchNamespacedStatefulSetWithHttpMessagesAsync(V1Patch body, string name, string namespaceParameter, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Namespace>> IKubernetes.PatchNamespaceStatusWithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Namespace>> IKubernetes.PatchNamespaceWithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Node>> IKubernetes.PatchNodeStatusWithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Node>> IKubernetes.PatchNodeWithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PersistentVolume>> IKubernetes.PatchPersistentVolumeStatusWithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PersistentVolume>> IKubernetes.PatchPersistentVolumeWithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1PodSecurityPolicy>> IKubernetes.PatchPodSecurityPolicyWithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1PriorityClass>> IKubernetes.PatchPriorityClass1WithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1PriorityClass>> IKubernetes.PatchPriorityClass2WithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PriorityClass>> IKubernetes.PatchPriorityClassWithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1PriorityLevelConfiguration>> IKubernetes.PatchPriorityLevelConfigurationStatusWithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1PriorityLevelConfiguration>> IKubernetes.PatchPriorityLevelConfigurationWithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1RuntimeClass>> IKubernetes.PatchRuntimeClass1WithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1RuntimeClass>> IKubernetes.PatchRuntimeClass2WithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1RuntimeClass>> IKubernetes.PatchRuntimeClassWithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1StorageClass>> IKubernetes.PatchStorageClass1WithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1StorageClass>> IKubernetes.PatchStorageClassWithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1StorageVersion>> IKubernetes.PatchStorageVersionStatusWithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1StorageVersion>> IKubernetes.PatchStorageVersionWithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1ValidatingWebhookConfiguration>> IKubernetes.PatchValidatingWebhookConfiguration1WithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ValidatingWebhookConfiguration>> IKubernetes.PatchValidatingWebhookConfigurationWithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1VolumeAttachment>> IKubernetes.PatchVolumeAttachment1WithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1VolumeAttachment>> IKubernetes.PatchVolumeAttachment2WithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1VolumeAttachment>> IKubernetes.PatchVolumeAttachmentStatusWithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1VolumeAttachment>> IKubernetes.PatchVolumeAttachmentWithHttpMessagesAsync(V1Patch body, string name, string dryRun, string fieldManager, bool? force, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1APIService>> IKubernetes.ReadAPIService1WithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1APIService>> IKubernetes.ReadAPIServiceStatus1WithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIService>> IKubernetes.ReadAPIServiceStatusWithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIService>> IKubernetes.ReadAPIServiceWithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CertificateSigningRequest>> IKubernetes.ReadCertificateSigningRequest1WithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CertificateSigningRequest>> IKubernetes.ReadCertificateSigningRequestApproval1WithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1CertificateSigningRequest>> IKubernetes.ReadCertificateSigningRequestApprovalWithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CertificateSigningRequest>> IKubernetes.ReadCertificateSigningRequestStatus1WithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1CertificateSigningRequest>> IKubernetes.ReadCertificateSigningRequestStatusWithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1CertificateSigningRequest>> IKubernetes.ReadCertificateSigningRequestWithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1ClusterRole>> IKubernetes.ReadClusterRole1WithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1ClusterRole>> IKubernetes.ReadClusterRole2WithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1ClusterRoleBinding>> IKubernetes.ReadClusterRoleBinding1WithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1ClusterRoleBinding>> IKubernetes.ReadClusterRoleBinding2WithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ClusterRoleBinding>> IKubernetes.ReadClusterRoleBindingWithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ClusterRole>> IKubernetes.ReadClusterRoleWithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ComponentStatus>> IKubernetes.ReadComponentStatusWithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CSIDriver>> IKubernetes.ReadCSIDriver1WithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1CSIDriver>> IKubernetes.ReadCSIDriverWithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CSINode>> IKubernetes.ReadCSINode1WithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1CSINode>> IKubernetes.ReadCSINodeWithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CustomResourceDefinition>> IKubernetes.ReadCustomResourceDefinition1WithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CustomResourceDefinition>> IKubernetes.ReadCustomResourceDefinitionStatus1WithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1CustomResourceDefinition>> IKubernetes.ReadCustomResourceDefinitionStatusWithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1CustomResourceDefinition>> IKubernetes.ReadCustomResourceDefinitionWithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1FlowSchema>> IKubernetes.ReadFlowSchemaStatusWithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1FlowSchema>> IKubernetes.ReadFlowSchemaWithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1IngressClass>> IKubernetes.ReadIngressClass1WithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1IngressClass>> IKubernetes.ReadIngressClassWithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1MutatingWebhookConfiguration>> IKubernetes.ReadMutatingWebhookConfiguration1WithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1MutatingWebhookConfiguration>> IKubernetes.ReadMutatingWebhookConfigurationWithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ConfigMap>> IKubernetes.ReadNamespacedConfigMapWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ControllerRevision>> IKubernetes.ReadNamespacedControllerRevisionWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CronJob>> IKubernetes.ReadNamespacedCronJob1WithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CronJob>> IKubernetes.ReadNamespacedCronJobStatus1WithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1CronJob>> IKubernetes.ReadNamespacedCronJobStatusWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1CronJob>> IKubernetes.ReadNamespacedCronJobWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CSIStorageCapacity>> IKubernetes.ReadNamespacedCSIStorageCapacity1WithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1CSIStorageCapacity>> IKubernetes.ReadNamespacedCSIStorageCapacityWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1DaemonSet>> IKubernetes.ReadNamespacedDaemonSetStatusWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1DaemonSet>> IKubernetes.ReadNamespacedDaemonSetWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Scale>> IKubernetes.ReadNamespacedDeploymentScaleWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Deployment>> IKubernetes.ReadNamespacedDeploymentStatusWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Deployment>> IKubernetes.ReadNamespacedDeploymentWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1EndpointSlice>> IKubernetes.ReadNamespacedEndpointSlice1WithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1EndpointSlice>> IKubernetes.ReadNamespacedEndpointSliceWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Endpoints>> IKubernetes.ReadNamespacedEndpointsWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Eventsv1Event>> IKubernetes.ReadNamespacedEvent1WithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1Event>> IKubernetes.ReadNamespacedEvent2WithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Corev1Event>> IKubernetes.ReadNamespacedEventWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V2beta1HorizontalPodAutoscaler>> IKubernetes.ReadNamespacedHorizontalPodAutoscaler1WithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V2beta2HorizontalPodAutoscaler>> IKubernetes.ReadNamespacedHorizontalPodAutoscaler2WithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V2beta1HorizontalPodAutoscaler>> IKubernetes.ReadNamespacedHorizontalPodAutoscalerStatus1WithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V2beta2HorizontalPodAutoscaler>> IKubernetes.ReadNamespacedHorizontalPodAutoscalerStatus2WithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1HorizontalPodAutoscaler>> IKubernetes.ReadNamespacedHorizontalPodAutoscalerStatusWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1HorizontalPodAutoscaler>> IKubernetes.ReadNamespacedHorizontalPodAutoscalerWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Ingress>> IKubernetes.ReadNamespacedIngress1WithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Networkingv1beta1Ingress>> IKubernetes.ReadNamespacedIngress2WithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Ingress>> IKubernetes.ReadNamespacedIngressStatus1WithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Networkingv1beta1Ingress>> IKubernetes.ReadNamespacedIngressStatus2WithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Extensionsv1beta1Ingress>> IKubernetes.ReadNamespacedIngressStatusWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Extensionsv1beta1Ingress>> IKubernetes.ReadNamespacedIngressWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Job>> IKubernetes.ReadNamespacedJobStatusWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Job>> IKubernetes.ReadNamespacedJobWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1Lease>> IKubernetes.ReadNamespacedLease1WithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Lease>> IKubernetes.ReadNamespacedLeaseWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1LimitRange>> IKubernetes.ReadNamespacedLimitRangeWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1NetworkPolicy>> IKubernetes.ReadNamespacedNetworkPolicyWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PersistentVolumeClaim>> IKubernetes.ReadNamespacedPersistentVolumeClaimStatusWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PersistentVolumeClaim>> IKubernetes.ReadNamespacedPersistentVolumeClaimWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1PodDisruptionBudget>> IKubernetes.ReadNamespacedPodDisruptionBudget1WithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1PodDisruptionBudget>> IKubernetes.ReadNamespacedPodDisruptionBudgetStatus1WithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PodDisruptionBudget>> IKubernetes.ReadNamespacedPodDisruptionBudgetStatusWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PodDisruptionBudget>> IKubernetes.ReadNamespacedPodDisruptionBudgetWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1EphemeralContainers>> IKubernetes.ReadNamespacedPodEphemeralcontainersWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Stream>> IKubernetes.ReadNamespacedPodLogWithHttpMessagesAsync(string name, string namespaceParameter, string container, bool? follow, bool? insecureSkipTLSVerifyBackend, int? limitBytes, string pretty, bool? previous, int? sinceSeconds, int? tailLines, bool? timestamps, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Pod>> IKubernetes.ReadNamespacedPodStatusWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PodTemplate>> IKubernetes.ReadNamespacedPodTemplateWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Pod>> IKubernetes.ReadNamespacedPodWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Scale>> IKubernetes.ReadNamespacedReplicaSetScaleWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ReplicaSet>> IKubernetes.ReadNamespacedReplicaSetStatusWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ReplicaSet>> IKubernetes.ReadNamespacedReplicaSetWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Scale>> IKubernetes.ReadNamespacedReplicationControllerScaleWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ReplicationController>> IKubernetes.ReadNamespacedReplicationControllerStatusWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ReplicationController>> IKubernetes.ReadNamespacedReplicationControllerWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ResourceQuota>> IKubernetes.ReadNamespacedResourceQuotaStatusWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ResourceQuota>> IKubernetes.ReadNamespacedResourceQuotaWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1Role>> IKubernetes.ReadNamespacedRole1WithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1Role>> IKubernetes.ReadNamespacedRole2WithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1RoleBinding>> IKubernetes.ReadNamespacedRoleBinding1WithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1RoleBinding>> IKubernetes.ReadNamespacedRoleBinding2WithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1RoleBinding>> IKubernetes.ReadNamespacedRoleBindingWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Role>> IKubernetes.ReadNamespacedRoleWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Secret>> IKubernetes.ReadNamespacedSecretWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ServiceAccount>> IKubernetes.ReadNamespacedServiceAccountWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Service>> IKubernetes.ReadNamespacedServiceStatusWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Service>> IKubernetes.ReadNamespacedServiceWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Scale>> IKubernetes.ReadNamespacedStatefulSetScaleWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1StatefulSet>> IKubernetes.ReadNamespacedStatefulSetStatusWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1StatefulSet>> IKubernetes.ReadNamespacedStatefulSetWithHttpMessagesAsync(string name, string namespaceParameter, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Namespace>> IKubernetes.ReadNamespaceStatusWithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Namespace>> IKubernetes.ReadNamespaceWithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Node>> IKubernetes.ReadNodeStatusWithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Node>> IKubernetes.ReadNodeWithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PersistentVolume>> IKubernetes.ReadPersistentVolumeStatusWithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PersistentVolume>> IKubernetes.ReadPersistentVolumeWithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1PodSecurityPolicy>> IKubernetes.ReadPodSecurityPolicyWithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1PriorityClass>> IKubernetes.ReadPriorityClass1WithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1PriorityClass>> IKubernetes.ReadPriorityClass2WithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PriorityClass>> IKubernetes.ReadPriorityClassWithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1PriorityLevelConfiguration>> IKubernetes.ReadPriorityLevelConfigurationStatusWithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1PriorityLevelConfiguration>> IKubernetes.ReadPriorityLevelConfigurationWithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1RuntimeClass>> IKubernetes.ReadRuntimeClass1WithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1RuntimeClass>> IKubernetes.ReadRuntimeClass2WithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1RuntimeClass>> IKubernetes.ReadRuntimeClassWithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1StorageClass>> IKubernetes.ReadStorageClass1WithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1StorageClass>> IKubernetes.ReadStorageClassWithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1StorageVersion>> IKubernetes.ReadStorageVersionStatusWithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1StorageVersion>> IKubernetes.ReadStorageVersionWithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1ValidatingWebhookConfiguration>> IKubernetes.ReadValidatingWebhookConfiguration1WithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ValidatingWebhookConfiguration>> IKubernetes.ReadValidatingWebhookConfigurationWithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1VolumeAttachment>> IKubernetes.ReadVolumeAttachment1WithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1VolumeAttachment>> IKubernetes.ReadVolumeAttachment2WithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1VolumeAttachment>> IKubernetes.ReadVolumeAttachmentStatusWithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1VolumeAttachment>> IKubernetes.ReadVolumeAttachmentWithHttpMessagesAsync(string name, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1APIService>> IKubernetes.ReplaceAPIService1WithHttpMessagesAsync(V1beta1APIService body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1APIService>> IKubernetes.ReplaceAPIServiceStatus1WithHttpMessagesAsync(V1beta1APIService body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIService>> IKubernetes.ReplaceAPIServiceStatusWithHttpMessagesAsync(V1APIService body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1APIService>> IKubernetes.ReplaceAPIServiceWithHttpMessagesAsync(V1APIService body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CertificateSigningRequest>> IKubernetes.ReplaceCertificateSigningRequest1WithHttpMessagesAsync(V1beta1CertificateSigningRequest body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CertificateSigningRequest>> IKubernetes.ReplaceCertificateSigningRequestApproval1WithHttpMessagesAsync(V1beta1CertificateSigningRequest body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1CertificateSigningRequest>> IKubernetes.ReplaceCertificateSigningRequestApprovalWithHttpMessagesAsync(V1CertificateSigningRequest body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CertificateSigningRequest>> IKubernetes.ReplaceCertificateSigningRequestStatus1WithHttpMessagesAsync(V1beta1CertificateSigningRequest body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1CertificateSigningRequest>> IKubernetes.ReplaceCertificateSigningRequestStatusWithHttpMessagesAsync(V1CertificateSigningRequest body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1CertificateSigningRequest>> IKubernetes.ReplaceCertificateSigningRequestWithHttpMessagesAsync(V1CertificateSigningRequest body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<object>> IKubernetes.ReplaceClusterCustomObjectScaleWithHttpMessagesAsync(object body, string group, string version, string plural, string name, string dryRun, string fieldManager, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<object>> IKubernetes.ReplaceClusterCustomObjectStatusWithHttpMessagesAsync(object body, string group, string version, string plural, string name, string dryRun, string fieldManager, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<object>> IKubernetes.ReplaceClusterCustomObjectWithHttpMessagesAsync(object body, string group, string version, string plural, string name, string dryRun, string fieldManager, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1ClusterRole>> IKubernetes.ReplaceClusterRole1WithHttpMessagesAsync(V1alpha1ClusterRole body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1ClusterRole>> IKubernetes.ReplaceClusterRole2WithHttpMessagesAsync(V1beta1ClusterRole body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1ClusterRoleBinding>> IKubernetes.ReplaceClusterRoleBinding1WithHttpMessagesAsync(V1alpha1ClusterRoleBinding body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1ClusterRoleBinding>> IKubernetes.ReplaceClusterRoleBinding2WithHttpMessagesAsync(V1beta1ClusterRoleBinding body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ClusterRoleBinding>> IKubernetes.ReplaceClusterRoleBindingWithHttpMessagesAsync(V1ClusterRoleBinding body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ClusterRole>> IKubernetes.ReplaceClusterRoleWithHttpMessagesAsync(V1ClusterRole body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CSIDriver>> IKubernetes.ReplaceCSIDriver1WithHttpMessagesAsync(V1beta1CSIDriver body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1CSIDriver>> IKubernetes.ReplaceCSIDriverWithHttpMessagesAsync(V1CSIDriver body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CSINode>> IKubernetes.ReplaceCSINode1WithHttpMessagesAsync(V1beta1CSINode body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1CSINode>> IKubernetes.ReplaceCSINodeWithHttpMessagesAsync(V1CSINode body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CustomResourceDefinition>> IKubernetes.ReplaceCustomResourceDefinition1WithHttpMessagesAsync(V1beta1CustomResourceDefinition body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CustomResourceDefinition>> IKubernetes.ReplaceCustomResourceDefinitionStatus1WithHttpMessagesAsync(V1beta1CustomResourceDefinition body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1CustomResourceDefinition>> IKubernetes.ReplaceCustomResourceDefinitionStatusWithHttpMessagesAsync(V1CustomResourceDefinition body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1CustomResourceDefinition>> IKubernetes.ReplaceCustomResourceDefinitionWithHttpMessagesAsync(V1CustomResourceDefinition body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1FlowSchema>> IKubernetes.ReplaceFlowSchemaStatusWithHttpMessagesAsync(V1beta1FlowSchema body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1FlowSchema>> IKubernetes.ReplaceFlowSchemaWithHttpMessagesAsync(V1beta1FlowSchema body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1IngressClass>> IKubernetes.ReplaceIngressClass1WithHttpMessagesAsync(V1beta1IngressClass body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1IngressClass>> IKubernetes.ReplaceIngressClassWithHttpMessagesAsync(V1IngressClass body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1MutatingWebhookConfiguration>> IKubernetes.ReplaceMutatingWebhookConfiguration1WithHttpMessagesAsync(V1beta1MutatingWebhookConfiguration body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1MutatingWebhookConfiguration>> IKubernetes.ReplaceMutatingWebhookConfigurationWithHttpMessagesAsync(V1MutatingWebhookConfiguration body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ConfigMap>> IKubernetes.ReplaceNamespacedConfigMapWithHttpMessagesAsync(V1ConfigMap body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ControllerRevision>> IKubernetes.ReplaceNamespacedControllerRevisionWithHttpMessagesAsync(V1ControllerRevision body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CronJob>> IKubernetes.ReplaceNamespacedCronJob1WithHttpMessagesAsync(V1beta1CronJob body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CronJob>> IKubernetes.ReplaceNamespacedCronJobStatus1WithHttpMessagesAsync(V1beta1CronJob body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1CronJob>> IKubernetes.ReplaceNamespacedCronJobStatusWithHttpMessagesAsync(V1CronJob body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1CronJob>> IKubernetes.ReplaceNamespacedCronJobWithHttpMessagesAsync(V1CronJob body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1CSIStorageCapacity>> IKubernetes.ReplaceNamespacedCSIStorageCapacity1WithHttpMessagesAsync(V1beta1CSIStorageCapacity body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1CSIStorageCapacity>> IKubernetes.ReplaceNamespacedCSIStorageCapacityWithHttpMessagesAsync(V1alpha1CSIStorageCapacity body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<object>> IKubernetes.ReplaceNamespacedCustomObjectScaleWithHttpMessagesAsync(object body, string group, string version, string namespaceParameter, string plural, string name, string dryRun, string fieldManager, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<object>> IKubernetes.ReplaceNamespacedCustomObjectStatusWithHttpMessagesAsync(object body, string group, string version, string namespaceParameter, string plural, string name, string dryRun, string fieldManager, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<object>> IKubernetes.ReplaceNamespacedCustomObjectWithHttpMessagesAsync(object body, string group, string version, string namespaceParameter, string plural, string name, string dryRun, string fieldManager, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1DaemonSet>> IKubernetes.ReplaceNamespacedDaemonSetStatusWithHttpMessagesAsync(V1DaemonSet body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1DaemonSet>> IKubernetes.ReplaceNamespacedDaemonSetWithHttpMessagesAsync(V1DaemonSet body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Scale>> IKubernetes.ReplaceNamespacedDeploymentScaleWithHttpMessagesAsync(V1Scale body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Deployment>> IKubernetes.ReplaceNamespacedDeploymentStatusWithHttpMessagesAsync(V1Deployment body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Deployment>> IKubernetes.ReplaceNamespacedDeploymentWithHttpMessagesAsync(V1Deployment body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1EndpointSlice>> IKubernetes.ReplaceNamespacedEndpointSlice1WithHttpMessagesAsync(V1beta1EndpointSlice body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1EndpointSlice>> IKubernetes.ReplaceNamespacedEndpointSliceWithHttpMessagesAsync(V1EndpointSlice body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Endpoints>> IKubernetes.ReplaceNamespacedEndpointsWithHttpMessagesAsync(V1Endpoints body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Eventsv1Event>> IKubernetes.ReplaceNamespacedEvent1WithHttpMessagesAsync(Eventsv1Event body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1Event>> IKubernetes.ReplaceNamespacedEvent2WithHttpMessagesAsync(V1beta1Event body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Corev1Event>> IKubernetes.ReplaceNamespacedEventWithHttpMessagesAsync(Corev1Event body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V2beta1HorizontalPodAutoscaler>> IKubernetes.ReplaceNamespacedHorizontalPodAutoscaler1WithHttpMessagesAsync(V2beta1HorizontalPodAutoscaler body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V2beta2HorizontalPodAutoscaler>> IKubernetes.ReplaceNamespacedHorizontalPodAutoscaler2WithHttpMessagesAsync(V2beta2HorizontalPodAutoscaler body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V2beta1HorizontalPodAutoscaler>> IKubernetes.ReplaceNamespacedHorizontalPodAutoscalerStatus1WithHttpMessagesAsync(V2beta1HorizontalPodAutoscaler body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V2beta2HorizontalPodAutoscaler>> IKubernetes.ReplaceNamespacedHorizontalPodAutoscalerStatus2WithHttpMessagesAsync(V2beta2HorizontalPodAutoscaler body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1HorizontalPodAutoscaler>> IKubernetes.ReplaceNamespacedHorizontalPodAutoscalerStatusWithHttpMessagesAsync(V1HorizontalPodAutoscaler body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1HorizontalPodAutoscaler>> IKubernetes.ReplaceNamespacedHorizontalPodAutoscalerWithHttpMessagesAsync(V1HorizontalPodAutoscaler body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Ingress>> IKubernetes.ReplaceNamespacedIngress1WithHttpMessagesAsync(V1Ingress body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Networkingv1beta1Ingress>> IKubernetes.ReplaceNamespacedIngress2WithHttpMessagesAsync(Networkingv1beta1Ingress body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Ingress>> IKubernetes.ReplaceNamespacedIngressStatus1WithHttpMessagesAsync(V1Ingress body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Networkingv1beta1Ingress>> IKubernetes.ReplaceNamespacedIngressStatus2WithHttpMessagesAsync(Networkingv1beta1Ingress body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Extensionsv1beta1Ingress>> IKubernetes.ReplaceNamespacedIngressStatusWithHttpMessagesAsync(Extensionsv1beta1Ingress body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<Extensionsv1beta1Ingress>> IKubernetes.ReplaceNamespacedIngressWithHttpMessagesAsync(Extensionsv1beta1Ingress body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Job>> IKubernetes.ReplaceNamespacedJobStatusWithHttpMessagesAsync(V1Job body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Job>> IKubernetes.ReplaceNamespacedJobWithHttpMessagesAsync(V1Job body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1Lease>> IKubernetes.ReplaceNamespacedLease1WithHttpMessagesAsync(V1beta1Lease body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Lease>> IKubernetes.ReplaceNamespacedLeaseWithHttpMessagesAsync(V1Lease body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1LimitRange>> IKubernetes.ReplaceNamespacedLimitRangeWithHttpMessagesAsync(V1LimitRange body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1NetworkPolicy>> IKubernetes.ReplaceNamespacedNetworkPolicyWithHttpMessagesAsync(V1NetworkPolicy body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PersistentVolumeClaim>> IKubernetes.ReplaceNamespacedPersistentVolumeClaimStatusWithHttpMessagesAsync(V1PersistentVolumeClaim body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PersistentVolumeClaim>> IKubernetes.ReplaceNamespacedPersistentVolumeClaimWithHttpMessagesAsync(V1PersistentVolumeClaim body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1PodDisruptionBudget>> IKubernetes.ReplaceNamespacedPodDisruptionBudget1WithHttpMessagesAsync(V1beta1PodDisruptionBudget body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1PodDisruptionBudget>> IKubernetes.ReplaceNamespacedPodDisruptionBudgetStatus1WithHttpMessagesAsync(V1beta1PodDisruptionBudget body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PodDisruptionBudget>> IKubernetes.ReplaceNamespacedPodDisruptionBudgetStatusWithHttpMessagesAsync(V1PodDisruptionBudget body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PodDisruptionBudget>> IKubernetes.ReplaceNamespacedPodDisruptionBudgetWithHttpMessagesAsync(V1PodDisruptionBudget body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1EphemeralContainers>> IKubernetes.ReplaceNamespacedPodEphemeralcontainersWithHttpMessagesAsync(V1EphemeralContainers body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Pod>> IKubernetes.ReplaceNamespacedPodStatusWithHttpMessagesAsync(V1Pod body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PodTemplate>> IKubernetes.ReplaceNamespacedPodTemplateWithHttpMessagesAsync(V1PodTemplate body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Pod>> IKubernetes.ReplaceNamespacedPodWithHttpMessagesAsync(V1Pod body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Scale>> IKubernetes.ReplaceNamespacedReplicaSetScaleWithHttpMessagesAsync(V1Scale body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ReplicaSet>> IKubernetes.ReplaceNamespacedReplicaSetStatusWithHttpMessagesAsync(V1ReplicaSet body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ReplicaSet>> IKubernetes.ReplaceNamespacedReplicaSetWithHttpMessagesAsync(V1ReplicaSet body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Scale>> IKubernetes.ReplaceNamespacedReplicationControllerScaleWithHttpMessagesAsync(V1Scale body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ReplicationController>> IKubernetes.ReplaceNamespacedReplicationControllerStatusWithHttpMessagesAsync(V1ReplicationController body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ReplicationController>> IKubernetes.ReplaceNamespacedReplicationControllerWithHttpMessagesAsync(V1ReplicationController body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ResourceQuota>> IKubernetes.ReplaceNamespacedResourceQuotaStatusWithHttpMessagesAsync(V1ResourceQuota body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ResourceQuota>> IKubernetes.ReplaceNamespacedResourceQuotaWithHttpMessagesAsync(V1ResourceQuota body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1Role>> IKubernetes.ReplaceNamespacedRole1WithHttpMessagesAsync(V1alpha1Role body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1Role>> IKubernetes.ReplaceNamespacedRole2WithHttpMessagesAsync(V1beta1Role body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1RoleBinding>> IKubernetes.ReplaceNamespacedRoleBinding1WithHttpMessagesAsync(V1alpha1RoleBinding body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1RoleBinding>> IKubernetes.ReplaceNamespacedRoleBinding2WithHttpMessagesAsync(V1beta1RoleBinding body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1RoleBinding>> IKubernetes.ReplaceNamespacedRoleBindingWithHttpMessagesAsync(V1RoleBinding body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Role>> IKubernetes.ReplaceNamespacedRoleWithHttpMessagesAsync(V1Role body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Secret>> IKubernetes.ReplaceNamespacedSecretWithHttpMessagesAsync(V1Secret body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ServiceAccount>> IKubernetes.ReplaceNamespacedServiceAccountWithHttpMessagesAsync(V1ServiceAccount body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Service>> IKubernetes.ReplaceNamespacedServiceStatusWithHttpMessagesAsync(V1Service body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Service>> IKubernetes.ReplaceNamespacedServiceWithHttpMessagesAsync(V1Service body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Scale>> IKubernetes.ReplaceNamespacedStatefulSetScaleWithHttpMessagesAsync(V1Scale body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1StatefulSet>> IKubernetes.ReplaceNamespacedStatefulSetStatusWithHttpMessagesAsync(V1StatefulSet body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1StatefulSet>> IKubernetes.ReplaceNamespacedStatefulSetWithHttpMessagesAsync(V1StatefulSet body, string name, string namespaceParameter, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Namespace>> IKubernetes.ReplaceNamespaceFinalizeWithHttpMessagesAsync(V1Namespace body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Namespace>> IKubernetes.ReplaceNamespaceStatusWithHttpMessagesAsync(V1Namespace body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Namespace>> IKubernetes.ReplaceNamespaceWithHttpMessagesAsync(V1Namespace body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Node>> IKubernetes.ReplaceNodeStatusWithHttpMessagesAsync(V1Node body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1Node>> IKubernetes.ReplaceNodeWithHttpMessagesAsync(V1Node body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PersistentVolume>> IKubernetes.ReplacePersistentVolumeStatusWithHttpMessagesAsync(V1PersistentVolume body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PersistentVolume>> IKubernetes.ReplacePersistentVolumeWithHttpMessagesAsync(V1PersistentVolume body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1PodSecurityPolicy>> IKubernetes.ReplacePodSecurityPolicyWithHttpMessagesAsync(V1beta1PodSecurityPolicy body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1PriorityClass>> IKubernetes.ReplacePriorityClass1WithHttpMessagesAsync(V1alpha1PriorityClass body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1PriorityClass>> IKubernetes.ReplacePriorityClass2WithHttpMessagesAsync(V1beta1PriorityClass body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1PriorityClass>> IKubernetes.ReplacePriorityClassWithHttpMessagesAsync(V1PriorityClass body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1PriorityLevelConfiguration>> IKubernetes.ReplacePriorityLevelConfigurationStatusWithHttpMessagesAsync(V1beta1PriorityLevelConfiguration body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1PriorityLevelConfiguration>> IKubernetes.ReplacePriorityLevelConfigurationWithHttpMessagesAsync(V1beta1PriorityLevelConfiguration body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1RuntimeClass>> IKubernetes.ReplaceRuntimeClass1WithHttpMessagesAsync(V1alpha1RuntimeClass body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1RuntimeClass>> IKubernetes.ReplaceRuntimeClass2WithHttpMessagesAsync(V1beta1RuntimeClass body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1RuntimeClass>> IKubernetes.ReplaceRuntimeClassWithHttpMessagesAsync(V1RuntimeClass body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1StorageClass>> IKubernetes.ReplaceStorageClass1WithHttpMessagesAsync(V1beta1StorageClass body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1StorageClass>> IKubernetes.ReplaceStorageClassWithHttpMessagesAsync(V1StorageClass body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1StorageVersion>> IKubernetes.ReplaceStorageVersionStatusWithHttpMessagesAsync(V1alpha1StorageVersion body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1StorageVersion>> IKubernetes.ReplaceStorageVersionWithHttpMessagesAsync(V1alpha1StorageVersion body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1ValidatingWebhookConfiguration>> IKubernetes.ReplaceValidatingWebhookConfiguration1WithHttpMessagesAsync(V1beta1ValidatingWebhookConfiguration body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1ValidatingWebhookConfiguration>> IKubernetes.ReplaceValidatingWebhookConfigurationWithHttpMessagesAsync(V1ValidatingWebhookConfiguration body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1alpha1VolumeAttachment>> IKubernetes.ReplaceVolumeAttachment1WithHttpMessagesAsync(V1alpha1VolumeAttachment body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1beta1VolumeAttachment>> IKubernetes.ReplaceVolumeAttachment2WithHttpMessagesAsync(V1beta1VolumeAttachment body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1VolumeAttachment>> IKubernetes.ReplaceVolumeAttachmentStatusWithHttpMessagesAsync(V1VolumeAttachment body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<HttpOperationResponse<V1VolumeAttachment>> IKubernetes.ReplaceVolumeAttachmentWithHttpMessagesAsync(V1VolumeAttachment body, string name, string dryRun, string fieldManager, string pretty, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1APIService>> IKubernetes.WatchAPIServiceAsync(string name, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1APIService> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1beta1APIService>> IKubernetes.WatchAPIServiceAsync(string name, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1beta1APIService> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1CertificateSigningRequest>> IKubernetes.WatchCertificateSigningRequestAsync(string name, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1CertificateSigningRequest> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1beta1CertificateSigningRequest>> IKubernetes.WatchCertificateSigningRequestAsync(string name, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1beta1CertificateSigningRequest> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1ClusterRole>> IKubernetes.WatchClusterRoleAsync(string name, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1ClusterRole> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1alpha1ClusterRole>> IKubernetes.WatchClusterRoleAsync(string name, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1alpha1ClusterRole> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1beta1ClusterRole>> IKubernetes.WatchClusterRoleAsync(string name, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1beta1ClusterRole> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1ClusterRoleBinding>> IKubernetes.WatchClusterRoleBindingAsync(string name, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1ClusterRoleBinding> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1alpha1ClusterRoleBinding>> IKubernetes.WatchClusterRoleBindingAsync(string name, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1alpha1ClusterRoleBinding> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1beta1ClusterRoleBinding>> IKubernetes.WatchClusterRoleBindingAsync(string name, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1beta1ClusterRoleBinding> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1CSIDriver>> IKubernetes.WatchCSIDriverAsync(string name, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1CSIDriver> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1beta1CSIDriver>> IKubernetes.WatchCSIDriverAsync(string name, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1beta1CSIDriver> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1CSINode>> IKubernetes.WatchCSINodeAsync(string name, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1CSINode> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1beta1CSINode>> IKubernetes.WatchCSINodeAsync(string name, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1beta1CSINode> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1CustomResourceDefinition>> IKubernetes.WatchCustomResourceDefinitionAsync(string name, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1CustomResourceDefinition> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1beta1CustomResourceDefinition>> IKubernetes.WatchCustomResourceDefinitionAsync(string name, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1beta1CustomResourceDefinition> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1beta1FlowSchema>> IKubernetes.WatchFlowSchemaAsync(string name, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1beta1FlowSchema> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1IngressClass>> IKubernetes.WatchIngressClassAsync(string name, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1IngressClass> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1beta1IngressClass>> IKubernetes.WatchIngressClassAsync(string name, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1beta1IngressClass> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1MutatingWebhookConfiguration>> IKubernetes.WatchMutatingWebhookConfigurationAsync(string name, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1MutatingWebhookConfiguration> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1beta1MutatingWebhookConfiguration>> IKubernetes.WatchMutatingWebhookConfigurationAsync(string name, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1beta1MutatingWebhookConfiguration> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1Namespace>> IKubernetes.WatchNamespaceAsync(string name, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1Namespace> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1ConfigMap>> IKubernetes.WatchNamespacedConfigMapAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1ConfigMap> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1ControllerRevision>> IKubernetes.WatchNamespacedControllerRevisionAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1ControllerRevision> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1CronJob>> IKubernetes.WatchNamespacedCronJobAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1CronJob> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1beta1CronJob>> IKubernetes.WatchNamespacedCronJobAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1beta1CronJob> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1alpha1CSIStorageCapacity>> IKubernetes.WatchNamespacedCSIStorageCapacityAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1alpha1CSIStorageCapacity> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1beta1CSIStorageCapacity>> IKubernetes.WatchNamespacedCSIStorageCapacityAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1beta1CSIStorageCapacity> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1DaemonSet>> IKubernetes.WatchNamespacedDaemonSetAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1DaemonSet> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1Deployment>> IKubernetes.WatchNamespacedDeploymentAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1Deployment> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1Endpoints>> IKubernetes.WatchNamespacedEndpointsAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1Endpoints> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1EndpointSlice>> IKubernetes.WatchNamespacedEndpointSliceAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1EndpointSlice> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1beta1EndpointSlice>> IKubernetes.WatchNamespacedEndpointSliceAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1beta1EndpointSlice> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<Corev1Event>> IKubernetes.WatchNamespacedEventAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, Corev1Event> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<Eventsv1Event>> IKubernetes.WatchNamespacedEventAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, Eventsv1Event> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1beta1Event>> IKubernetes.WatchNamespacedEventAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1beta1Event> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1HorizontalPodAutoscaler>> IKubernetes.WatchNamespacedHorizontalPodAutoscalerAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1HorizontalPodAutoscaler> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V2beta1HorizontalPodAutoscaler>> IKubernetes.WatchNamespacedHorizontalPodAutoscalerAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V2beta1HorizontalPodAutoscaler> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V2beta2HorizontalPodAutoscaler>> IKubernetes.WatchNamespacedHorizontalPodAutoscalerAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V2beta2HorizontalPodAutoscaler> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<Extensionsv1beta1Ingress>> IKubernetes.WatchNamespacedIngressAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, Extensionsv1beta1Ingress> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1Ingress>> IKubernetes.WatchNamespacedIngressAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1Ingress> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<Networkingv1beta1Ingress>> IKubernetes.WatchNamespacedIngressAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, Networkingv1beta1Ingress> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1Job>> IKubernetes.WatchNamespacedJobAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1Job> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1Lease>> IKubernetes.WatchNamespacedLeaseAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1Lease> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1beta1Lease>> IKubernetes.WatchNamespacedLeaseAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1beta1Lease> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1LimitRange>> IKubernetes.WatchNamespacedLimitRangeAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1LimitRange> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1NetworkPolicy>> IKubernetes.WatchNamespacedNetworkPolicyAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1NetworkPolicy> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1PersistentVolumeClaim>> IKubernetes.WatchNamespacedPersistentVolumeClaimAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1PersistentVolumeClaim> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1Pod>> IKubernetes.WatchNamespacedPodAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1Pod> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1PodDisruptionBudget>> IKubernetes.WatchNamespacedPodDisruptionBudgetAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1PodDisruptionBudget> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1beta1PodDisruptionBudget>> IKubernetes.WatchNamespacedPodDisruptionBudgetAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1beta1PodDisruptionBudget> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1PodTemplate>> IKubernetes.WatchNamespacedPodTemplateAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1PodTemplate> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1ReplicaSet>> IKubernetes.WatchNamespacedReplicaSetAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1ReplicaSet> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1ReplicationController>> IKubernetes.WatchNamespacedReplicationControllerAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1ReplicationController> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1ResourceQuota>> IKubernetes.WatchNamespacedResourceQuotaAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1ResourceQuota> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1Role>> IKubernetes.WatchNamespacedRoleAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1Role> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1alpha1Role>> IKubernetes.WatchNamespacedRoleAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1alpha1Role> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1beta1Role>> IKubernetes.WatchNamespacedRoleAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1beta1Role> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1RoleBinding>> IKubernetes.WatchNamespacedRoleBindingAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1RoleBinding> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1alpha1RoleBinding>> IKubernetes.WatchNamespacedRoleBindingAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1alpha1RoleBinding> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1beta1RoleBinding>> IKubernetes.WatchNamespacedRoleBindingAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1beta1RoleBinding> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1Secret>> IKubernetes.WatchNamespacedSecretAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1Secret> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1ServiceAccount>> IKubernetes.WatchNamespacedServiceAccountAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1ServiceAccount> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1Service>> IKubernetes.WatchNamespacedServiceAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1Service> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1StatefulSet>> IKubernetes.WatchNamespacedStatefulSetAsync(string name, string @namespace, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1StatefulSet> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1Node>> IKubernetes.WatchNodeAsync(string name, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1Node> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<T>> IKubernetes.WatchObjectAsync<T>(string path, string @continue, string fieldSelector, bool? includeUninitialized, string labelSelector, int? limit, bool? pretty, int? timeoutSeconds, string resourceVersion, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, T> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1PersistentVolume>> IKubernetes.WatchPersistentVolumeAsync(string name, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1PersistentVolume> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1beta1PodSecurityPolicy>> IKubernetes.WatchPodSecurityPolicyAsync(string name, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1beta1PodSecurityPolicy> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1PriorityClass>> IKubernetes.WatchPriorityClassAsync(string name, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1PriorityClass> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1alpha1PriorityClass>> IKubernetes.WatchPriorityClassAsync(string name, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1alpha1PriorityClass> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1beta1PriorityClass>> IKubernetes.WatchPriorityClassAsync(string name, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1beta1PriorityClass> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1beta1PriorityLevelConfiguration>> IKubernetes.WatchPriorityLevelConfigurationAsync(string name, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1beta1PriorityLevelConfiguration> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1RuntimeClass>> IKubernetes.WatchRuntimeClassAsync(string name, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1RuntimeClass> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1alpha1RuntimeClass>> IKubernetes.WatchRuntimeClassAsync(string name, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1alpha1RuntimeClass> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1beta1RuntimeClass>> IKubernetes.WatchRuntimeClassAsync(string name, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1beta1RuntimeClass> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1StorageClass>> IKubernetes.WatchStorageClassAsync(string name, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1StorageClass> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1beta1StorageClass>> IKubernetes.WatchStorageClassAsync(string name, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1beta1StorageClass> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1alpha1StorageVersion>> IKubernetes.WatchStorageVersionAsync(string name, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1alpha1StorageVersion> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1ValidatingWebhookConfiguration>> IKubernetes.WatchValidatingWebhookConfigurationAsync(string name, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1ValidatingWebhookConfiguration> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1beta1ValidatingWebhookConfiguration>> IKubernetes.WatchValidatingWebhookConfigurationAsync(string name, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1beta1ValidatingWebhookConfiguration> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1VolumeAttachment>> IKubernetes.WatchVolumeAttachmentAsync(string name, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1VolumeAttachment> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1alpha1VolumeAttachment>> IKubernetes.WatchVolumeAttachmentAsync(string name, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1alpha1VolumeAttachment> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Watcher<V1beta1VolumeAttachment>> IKubernetes.WatchVolumeAttachmentAsync(string name, bool? allowWatchBookmarks, string @continue, string fieldSelector, string labelSelector, int? limit, bool? pretty, string resourceVersion, string resourceVersionMatch, int? timeoutSeconds, bool? watch, Dictionary<string, List<string>> customHeaders, Action<WatchEventType, V1beta1VolumeAttachment> onEvent, Action<Exception> onError, Action onClosed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<WebSocket> IKubernetes.WebSocketNamespacedPodAttachAsync(string name, string @namespace, string container, bool stderr, bool stdin, bool stdout, bool tty, string webSocketSubProtocol, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<WebSocket> IKubernetes.WebSocketNamespacedPodExecAsync(string name, string @namespace, string command, string container, bool stderr, bool stdin, bool stdout, bool tty, string webSocketSubProtocol, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<WebSocket> IKubernetes.WebSocketNamespacedPodExecAsync(string name, string @namespace, IEnumerable<string> command, string container, bool stderr, bool stdin, bool stdout, bool tty, string webSocketSubProtocol, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<WebSocket> IKubernetes.WebSocketNamespacedPodPortForwardAsync(string name, string @namespace, IEnumerable<int> ports, string webSocketSubProtocol, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: supprimer l'état managé (objets managés)
                }

                // TODO: libérer les ressources non managées (objets non managés) et substituer le finaliseur
                // TODO: affecter aux grands champs une valeur null
                disposedValue = true;
            }
        }

        // // TODO: substituer le finaliseur uniquement si 'Dispose(bool disposing)' a du code pour libérer les ressources non managées
        // ~MockKubernetes()
        // {
        //     // Ne changez pas ce code. Placez le code de nettoyage dans la méthode 'Dispose(bool disposing)'
        //     Dispose(disposing: false);
        // }

        void IDisposable.Dispose()
        {
            // Ne changez pas ce code. Placez le code de nettoyage dans la méthode 'Dispose(bool disposing)'
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}