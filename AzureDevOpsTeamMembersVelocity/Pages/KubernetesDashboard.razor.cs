using AzureDevOpsTeamMembersVelocity.Model;
using AzureDevOpsTeamMembersVelocity.Settings;
using k8s.Models;
using k8s;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using AzureDevOpsTeamMembersVelocity.Repository;
using System.Text.Json;
using System.Net.Http;
using AzureDevOpsTeamMembersVelocity.Extensions;

namespace AzureDevOpsTeamMembersVelocity.Pages
{
    /// <summary>
    /// Logic for the Kubernetes Dashboard page
    /// </summary>
    [Authorize]
    public partial class KubernetesDashboard : IDisposable, IAsyncDisposable
    {
#pragma warning disable CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.
        [Inject]
        IKubernetes Client { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        [Inject]
        ILogger<KubernetesDashboard> Logger { get; set; }

        [Inject]
        IJSRuntime JS { get; set; }

        [Inject]
        IHttpContextAccessor HttpContextAccessor { get; set; }

        [Inject]
        IUserPreferenceRepository UserPreference { get; set; }

        [Inject]
        IServiceProvider ServiceProvider { get; set; }
#pragma warning restore CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.

        /// <summary>
        /// Namespaces
        /// </summary>
        public ConcurrentDictionary<string, V1Namespace> NamespaceList { get; set; } = new();

        /// <summary>
        /// Deployments
        /// </summary>
        public ConcurrentDictionary<string, V1Deployment> Deployments { get; set; } = new();

        /// <summary>
        /// Pods
        /// </summary>
        public ConcurrentDictionary<string, V1Pod> Pods { get; set; } = new();

        /// <summary>
        /// The error message to display to the user, if any
        /// </summary>
        public string? Error { get; set; }

        /// <summary>
        /// Preferences of the user
        /// </summary>
        public KubernetesPageSettings Settings { get; set; } = new KubernetesPageSettings();

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            try
            {
                Settings = await UserPreference.GetAsync<KubernetesPageSettings>();

                var cookies = HttpContextAccessor.HttpContext?.Request.Cookies;

                var cookiesCollection = new System.Net.CookieContainer();

                if (cookies != null)
                {
                    foreach (var c in cookies)
                    {
                        cookiesCollection.Add(new System.Net.Cookie(c.Key, c.Value) { Domain = await JS.InvokeAsync<string>("window.GetHostname") });
                    }
                }

                k8sHubConnection = new HubConnectionBuilder()
                    .WithUrl(NavigationManager.ToAbsoluteUri("/K8sHub"), options =>
                    {
                        options.Cookies = cookiesCollection;
                        options.HttpMessageHandlerFactory = ServiceProvider.GetService<Func<HttpMessageHandler, HttpMessageHandler>>();
                    })
                    .Build();

                await k8sHubConnection.StartAsync();

                _dashboardTask = RunK8sDashboard();

                logHubConnection = new HubConnectionBuilder()
                    .WithUrl(NavigationManager.ToAbsoluteUri("/GetPodLog"), options =>
                    {
                        options.Cookies = cookiesCollection;
                        options.HttpMessageHandlerFactory = ServiceProvider.GetService<Func<HttpMessageHandler, HttpMessageHandler>>();
                    })
                    .Build();

                await logHubConnection.StartAsync();
            }
            catch (Exception e)
            {
                Error = e.Message;
                Logger.LogError(e, e.Message);
            }
        }

        private HubConnection? k8sHubConnection;
        private readonly CancellationTokenSource _dashboardToken = new();
        private Task? _dashboardTask;

        private HubConnection? logHubConnection;
        private BlockingCollection<string> PodLogs { get; set; } = new();
        private Dictionary<string, CancellationTokenSource> TokensBag { get; set; } = new();

        private async Task RunK8sDashboard()
        {
            try
            {
                await Task.WhenAll(new Task[]
                {
                    WatchNamespacesTask(),
                    WatchDeploymentsTask(),
                    WatchPodsTask()
                });
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message, e);
                Error = $"RunK8sDashboarde: {e.Message}{Environment.NewLine}You may want to reload the page to fully restore the live refresh";
                StateHasChanged();
            }
        }

        private async Task WatchNamespacesTask()
        {
            var namespaceChannel = await k8sHubConnection.StreamAsChannelAsync<Pair<WatchEventType?, V1Namespace>>("Namespaces", _dashboardToken.Token);

            await namespaceChannel.OnMessageRecieved(async @namespace =>
            {
                if (@namespace.Item2 is null)
                {
                    return;
                }

                switch (@namespace.Item1)
                {
                    case null:
                    case WatchEventType.Added:
                        if (!NamespaceList.TryAdd(@namespace.Item2.Metadata.Name, @namespace.Item2))
                        {
                            var message = $"Failed to add namespace {@namespace.Item2.Metadata.Name}";
                            Logger.LogError(message);
                            Error = message;
                        }
                        break;
                    case WatchEventType.Bookmark:
                        Logger.LogInformation(WatchEventType.Bookmark.ToString());
                        Logger.LogInformation(JsonSerializer.Serialize(@namespace.Item2));
                        break;
                    case WatchEventType.Deleted:
                        if (!NamespaceList.Remove(@namespace.Item2.Metadata.Name, out var _))
                        {
                            var message = $"Failed to remove namespace {@namespace.Item2.Metadata.Name}";
                            Logger.LogError(message);
                            Error = message;
                        }
                        break;
                    case WatchEventType.Error:
                        Logger.LogError(WatchEventType.Error.ToString());
                        Logger.LogError(JsonSerializer.Serialize(@namespace.Item2));
                        break;
                    case WatchEventType.Modified:
                        var key = @namespace.Item2.Metadata.Name;
                        if (!(NamespaceList.TryGetValue(key, out var oldValue) && NamespaceList.TryUpdate(key, @namespace.Item2, oldValue)))
                        {
                            var message = $"Failed to update namespace {@namespace.Item2.Metadata.Name}";
                            Logger.LogError(message);
                            Error = message;
                        }
                        break;
                    default:
                        throw new InvalidOperationException($"Unknow {nameof(WatchEventType)} with value {@namespace.Item1}");
                }

                await InvokeAsync(() =>
                {
                    StateHasChanged();
                });

            }, _dashboardToken.Token);
        }

        private async Task WatchDeploymentsTask()
        {
            var deploymentChannel = await k8sHubConnection.StreamAsChannelAsync<Pair<WatchEventType?, V1Deployment>>("Deployments", _dashboardToken.Token);

            await deploymentChannel.OnMessageRecieved(async deployment =>
            {
                if (deployment.Item2 is null)
                {
                    return;
                }

                var key = $"{deployment.Item2.Namespace()}-{deployment.Item2.Name()}";

                switch (deployment.Item1)
                {
                    case null:
                    case WatchEventType.Added:
                        if (!Deployments.TryAdd(key, deployment.Item2))
                        {
                            var message = $"Failed to add deployment {deployment.Item2.Metadata.Name}";
                            Logger.LogError(message);
                            Error = message;
                        }
                        break;
                    case WatchEventType.Bookmark:
                        Logger.LogInformation(WatchEventType.Bookmark.ToString());
                        Logger.LogInformation(JsonSerializer.Serialize(deployment.Item2));
                        break;
                    case WatchEventType.Deleted:
                        if (!Deployments.Remove(key, out var removedDeployment))
                        {
                            var message = $"Failed to remove deployment {deployment.Item2.Metadata.Name}";
                            Logger.LogError(message);
                            Error = message;
                        }
                        break;
                    case WatchEventType.Error:
                        Logger.LogError(WatchEventType.Error.ToString());
                        Logger.LogError(JsonSerializer.Serialize(deployment.Item2));
                        break;
                    case WatchEventType.Modified:
                        if (!(Deployments.TryGetValue(key, out var oldValue) && Deployments.TryUpdate(key, deployment.Item2, oldValue)))
                        {
                            var message = $"Failed to update deployment {deployment.Item2.Metadata.Name}";
                            Logger.LogError(message);
                            Error = message;
                        }
                        break;
                    default:
                        throw new InvalidOperationException($"Unknow {nameof(WatchEventType)} with value {deployment.Item1}");
                }

                await InvokeAsync(() =>
                {
                    StateHasChanged();
                });

            }, _dashboardToken.Token);
        }

        private async Task WatchPodsTask()
        {
            var podChannel = await k8sHubConnection.StreamAsChannelAsync<Pair<WatchEventType?, V1Pod>>("Pods", _dashboardToken.Token);

            List<Task> taskList = new();

            await podChannel.OnMessageRecieved(async pod =>
            {
                if (pod.Item2 is null)
                {
                    return;
                }

                var @namespace = pod.Item2.Namespace();
                var podName = pod.Item2.Name();
                var key = $"{@namespace}-{pod.Item2.Metadata.Name}";

                switch (pod.Item1)
                {
                    case null:
                    case WatchEventType.Added:
                        if (Pods.TryAdd(key, pod.Item2))
                        {
                            if ((pod.Item2.Status.Phase == "Running" || pod.Item2.Status.Phase == "Pending") &&
                                DeployementCheckedForLogs.Any(d => pod.Item2.Metadata.Name.StartsWith(d)))
                            {
                                taskList.Add(ListenTopPodLogs(PodLogsTaskKey(@namespace, podName), @namespace, podName));
                            }
                        }
                        else
                        {
                            var message = $"Failed to add pod {pod.Item2.Metadata.Name}";
                            Logger.LogError(message);
                            Error = message;
                        }
                        break;
                    case WatchEventType.Bookmark:
                        Logger.LogInformation(WatchEventType.Bookmark.ToString());
                        Logger.LogInformation(JsonSerializer.Serialize(pod.Item2));
                        break;
                    case WatchEventType.Deleted:
                        if (Pods.Remove(key, out var podDeleted))
                        {
                            var taskKey = PodLogsTaskKey(podDeleted.Metadata.NamespaceProperty, podDeleted.Metadata.Name);

                            if (TokensBag.TryGetValue(taskKey, out var tokenSourceCancellation))
                            {
                                tokenSourceCancellation.Cancel();

                                TokensBag.Remove(taskKey);
                            }
                        }
                        else
                        {
                            var message = $"Failed to remove pod {pod.Item2.Metadata.Name}";
                            Logger.LogError(message);
                            Error = message;
                        }
                        break;
                    case WatchEventType.Error:
                        Logger.LogError(WatchEventType.Error.ToString());
                        Logger.LogError(JsonSerializer.Serialize(pod.Item2));
                        break;
                    case WatchEventType.Modified:
                        OnUpdatePodInfo(key, pod.Item2, taskList);
                        break;
                    default:
                        throw new InvalidOperationException($"Unknow {nameof(WatchEventType)} with value {pod.Item1}");
                }

                await InvokeAsync(() =>
                {
                    StateHasChanged();
                });

            }, _dashboardToken.Token);

            await Task.WhenAll(taskList);
        }

        private void OnUpdatePodInfo(string key, V1Pod pod, List<Task> taskList)
        {
            if (Pods.TryGetValue(key, out var oldValue) && Pods.TryUpdate(key, pod, oldValue))
            {
                var taskKey = PodLogsTaskKey(pod.Metadata.NamespaceProperty, pod.Metadata.Name);

                if (TokensBag.TryGetValue(taskKey, out var token))
                {
                    if (pod.Status.Phase == "Succeeded" ||
                        pod.Status.Phase == "Failed")
                    {
                        token.Cancel();

                        TokensBag.Remove(taskKey);
                    }
                    else if (pod.Status.Phase == "Running" ||
                             pod.Status.Phase == "Pending")
                    {
                        Logger.LogInformation("Get metadata update on a pod that listen to logs");
                    }
                    else
                    {
                        Logger.LogWarning("Unknow state recieved from the hub");
                        Logger.LogWarning(WatchEventType.Modified.ToString());
                        Logger.LogWarning(JsonSerializer.Serialize(pod));
                    }
                }
                else
                {
                    if (pod.Status.Phase == "Succeeded" ||
                        pod.Status.Phase == "Failed")
                    {
                        Logger.LogInformation("Get metadata update on a pod that listen to logs, but the pod is not ready for listening to logs");
                    }
                    else if (pod.Status.Phase == "Running" || pod.Status.Phase == "Pending")
                    {
                        if (DeployementCheckedForLogs.Any(d => pod.Metadata.Name.StartsWith(d)))
                        {
                            Logger.LogInformation("Start listen to pod log after reveived a ready state");
                            taskList.Add(ListenTopPodLogs(PodLogsTaskKey(pod.Namespace(), pod.Name()), pod.Namespace(), pod.Name()));
                        }
                        else
                        {
                            Logger.LogInformation($"Recived {WatchEventType.Modified} from the hub for pod {pod.Name()} in namespace {pod.Namespace()}");
                        }
                    }
                    else
                    {
                        Logger.LogWarning("Unknow state recieved from the hub");
                        Logger.LogWarning(WatchEventType.Modified.ToString());
                        Logger.LogWarning(JsonSerializer.Serialize(pod));
                    }
                }
            }
            else
            {
                var message = $"Failed to update pod {pod.Metadata.Name}";
                Logger.LogError(message);
                Error = message;
            }
        }

        private async Task OnPodLogClick(ChangeEventArgs args, string podNamespace, string podName)
        {
            var taskKey = PodLogsTaskKey(podNamespace, podName);

            if (((bool?)args.Value) == true)
            {
                await ListenTopPodLogs(taskKey, podNamespace, podName);
            }
            else
            {
                if (TokensBag.TryGetValue(taskKey, out var tokenSourceCancellation))
                {
                    tokenSourceCancellation.Cancel();

                    TokensBag.Remove(taskKey);
                }
            }
        }

        private async Task ListenTopPodLogs(string taskKey, string podNamespace, string podName)
        {
            CancellationTokenSource tokenSource = new();

            try
            {
                var channel = await logHubConnection.StreamAsChannelAsync<string>("GetPodLog", podNamespace, podName, tokenSource.Token);

                TokensBag.Add(taskKey, tokenSource);

                await channel.OnMessageRecieved(async log =>
                {
                    PodLogs.Add(log);
                    StateHasChanged();
                    if (ScrollToBottom)
                    {
                        await JS.InvokeVoidAsync("window.scrollToBottom");
                    }
                }, tokenSource.Token);
            }
            catch (OperationCanceledException e)
            {
                Logger.LogInformation($"{e.Message}{Environment.NewLine}{e.StackTrace}");
            }
        }

        private static string PodLogsTaskKey(string podNamespace, string podName) => $"{podNamespace}{podName}";

        /// <summary>
        /// Set of deployment that user select to listen to logs
        /// </summary>
        public HashSet<string> DeployementCheckedForLogs { get; } = new();

        private async Task OnDeploymentLogClick(ChangeEventArgs args, string deploymentNamespace, string deploymentName)
        {
            try
            {
                DeployementCheckedForLogs.Add(deploymentName);

                List<Task> taskList = new();

                foreach (var pod in Pods.Values.Where(p => p.Name().StartsWith(deploymentName)))
                {
                    var keyHashSet = $"{deploymentNamespace}-{deploymentName}";

                    taskList.Add(OnPodLogClick(args, deploymentNamespace, pod.Name()).ContinueWith(task =>
                    {
                        try
                        {
                            DeployementCheckedForLogs.Remove(keyHashSet);
                        }
                        catch
                        {
                            // The catch block is empty because the code try to remove the string from the set
                        }

                        return Task.CompletedTask;
                    }));
                }

                foreach (var task in taskList)
                {
                    await task;
                }
            }
            catch (Exception e)
            {
                try
                {
                    DeployementCheckedForLogs.Remove($"{deploymentNamespace}-{deploymentName}");
                }
                catch
                {
                    // The catch block is empty because the code try to remove the string from the set
                }

                Error = e.Message;
                Logger.LogError(e, e.Message);
            }
        }

        private async Task DeleteNamespace(V1Namespace ns)
        {
            try
            {
                await Client.DeleteNamespaceAsync(ns.Metadata.Name, new V1DeleteOptions());
            }
            catch (Exception e)
            {
                Error = e.Message;
                Logger.LogError(e, e.Message);
            }
        }

        private async Task DeletePod(V1Pod pod)
        {
            try
            {
                await Client.DeleteNamespacedPodAsync(pod.Name(), pod.Namespace(), new V1DeleteOptions());
            }
            catch (Exception e)
            {
                Error = e.Message;
                Logger.LogError(e, e.Message);
            }
        }

        private void ClearLogs()
        {
            try
            {
                bool trySucceeded = false;

                do
                {
                    trySucceeded = PodLogs.TryTake(out _);

                } while (trySucceeded);
            }
            catch (Exception e)
            {
                Error = $"An error append when clearing logs: {e.Message}";
                Logger.LogWarning(e, e.Message);
            }
        }

        private bool ScrollToBottom { get; set; }

        /// <summary>
        /// inverse the value of the <see cref="ScrollToBottom" /> property
        /// </summary>
        public void ChangeScrollToBottom()
        {
            ScrollToBottom = !ScrollToBottom;
        }

        /// <inheritdoc />
        public async ValueTask DisposeAsync()
        {
            if (logHubConnection is not null)
            {
                await logHubConnection.DisposeAsync();
            }

            if (k8sHubConnection is not null)
            {
                await k8sHubConnection.DisposeAsync();
            }
        }

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose method that cleanup backgroud task
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dashboardToken.Cancel();

                try
                {
                    _dashboardTask?.Wait();
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(e.Message);
                    Console.Error.WriteLine(e.StackTrace);
                }

                _dashboardTask?.Dispose();
                _dashboardToken.Dispose();
            }
        }

        /// <summary>
        /// Set the 'collapse' class to the appropriate property
        /// </summary>
        /// <param name="collapseId"></param>
        public void Collapsing(string collapseId)
        {
            if (collapseId == "collapseNamespace")
            {
                Settings.NamespaceCollapseClass = string.IsNullOrEmpty(Settings.NamespaceCollapseClass) ? "collapse" : "";
            }
            else if (collapseId == "collapseDeployment")
            {
                Settings.DeploymentCollapseClass = string.IsNullOrEmpty(Settings.DeploymentCollapseClass) ? "collapse" : "";
            }
            else if (collapseId == "collapsePods")
            {
                Settings.PodsCollapseClass = string.IsNullOrEmpty(Settings.PodsCollapseClass) ? "collapse" : "";
            }

            UserPreference.SetAsync(Settings);
        }

        /// <summary>
        /// Property use to filter the pods table
        /// </summary>
        public string SearchPods {get;set;} = string.Empty;

        /// <summary>
        /// Set the search pods property to empty string
        /// </summary>
        public void ClearSearchPods()
        {
            SearchPods = string.Empty;
        }

        /// <summary>
        /// Append when user type in the search pods input
        /// </summary>
        public Task OnSearchPods(ChangeEventArgs args)
        {
            SearchPods = args.Value?.ToString() ?? string.Empty;
            StateHasChanged();
            return Task.CompletedTask;
        }
    }
}
