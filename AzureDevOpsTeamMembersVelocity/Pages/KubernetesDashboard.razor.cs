﻿using AzureDevOpsTeamMembersVelocity.Model;
using AzureDevOpsTeamMembersVelocity.Settings;
using k8s.Models;
using k8s;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
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

namespace AzureDevOpsTeamMembersVelocity.Pages
{
    [Authorize]
    public partial class KubernetesDashboard
    {
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

        public ConcurrentDictionary<string, V1Namespace> NamespaceList { get; set; } = new();

        public ConcurrentDictionary<string, V1Deployment> Deployments { get; set; } = new();

        public ConcurrentDictionary<string, V1Pod> Pods { get; set; } = new();

        public string? Error { get; set; }

        public KubernetesPageSettings Settings { get; set; } = new KubernetesPageSettings();

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
                    })
                    .Build();

                await k8sHubConnection.StartAsync();

                _dashboardTask = RunK8sDashboard();

                logHubConnection = new HubConnectionBuilder()
                    .WithUrl(NavigationManager.ToAbsoluteUri("/GetPodLog"), options =>
                    {
                        options.Cookies = cookiesCollection;
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
        private CancellationTokenSource _dashboardToken = new();
        private Task? _dashboardTask;

        private HubConnection? logHubConnection;
        private BlockingCollection<string> PodLogs { get; set; } = new();
        private Dictionary<string, System.Threading.CancellationTokenSource> TokensBag { get; set; } = new();

        private async Task RunK8sDashboard()
        {
            try
            {
                await Task.WhenAll(new Task[]
                {
                Task.Run(async () =>
                {
                    var namespaceChannel = await k8sHubConnection.StreamAsChannelAsync<Pair<WatchEventType?, V1Namespace>>("Namespaces", _dashboardToken.Token);

                    while (await namespaceChannel.WaitToReadAsync(_dashboardToken.Token))
                    {
                        while (namespaceChannel.TryRead(out var @namespace))
                        {
                            if (@namespace.Item2 is null)
                            {
                                continue;
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
                                    if ((NamespaceList.TryGetValue(key, out var oldValue) && NamespaceList.TryUpdate(key, @namespace.Item2, oldValue)) == false)
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
                        }
                    }
                }),
                Task.Run(async () =>
                {
                    var deploymentChannel = await k8sHubConnection.StreamAsChannelAsync<Pair<WatchEventType?, V1Deployment>>("Deployments", _dashboardToken.Token);

                    while (await deploymentChannel.WaitToReadAsync(_dashboardToken.Token))
                    {
                        while (deploymentChannel.TryRead(out var deployment))
                        {
                            if (deployment.Item2 is null)
                            {
                                continue;
                            }

                            var key = $"{deployment.Item2.Metadata.NamespaceProperty}-{deployment.Item2.Metadata.Name}";

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
                                    if ((Deployments.TryGetValue(key, out var oldValue) && Deployments.TryUpdate(key, deployment.Item2, oldValue)) == false)
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
                        }
                    }
                }),
                Task.Run(async () =>
                {
                    var podChannel = await k8sHubConnection.StreamAsChannelAsync<Pair<WatchEventType?, V1Pod>>("Pods", _dashboardToken.Token);

                    List<Task> taskList = new();

                    while (await podChannel.WaitToReadAsync(_dashboardToken.Token))
                    {
                        while (podChannel.TryRead(out var pod))
                        {
                            if (pod.Item2 is null)
                            {
                                continue;
                            }

                            var @namespace = pod.Item2.Metadata.NamespaceProperty;
                            var podName = pod.Item2.Metadata.Name;
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
                                    if (Pods.TryGetValue(key, out var oldValue) && Pods.TryUpdate(key, pod.Item2, oldValue))
                                    {
                                        var taskKey = PodLogsTaskKey(pod.Item2.Metadata.NamespaceProperty, pod.Item2.Metadata.Name);

                                        if (TokensBag.TryGetValue(taskKey, out var token))
                                        {
                                            if (pod.Item2.Status.Phase == "Succeded" ||
                                                pod.Item2.Status.Phase == "Failed")
                                            {
                                                token.Cancel();

                                                TokensBag.Remove(taskKey);
                                            }
                                            else if (pod.Item2.Status.Phase == "Running" || 
                                                     pod.Item2.Status.Phase == "Pending")
                                            {
                                                Logger.LogInformation("Get metadata update on a pod that listen to logs");
                                            }
                                            else
                                            {
                                                Logger.LogWarning("Unknow state recieved from the hub");
                                                Logger.LogWarning(WatchEventType.Modified.ToString());
                                                Logger.LogWarning(JsonSerializer.Serialize(pod.Item2));
                                            }

                                        }
                                        else
                                        {
                                            if (pod.Item2.Status.Phase == "Succeded" ||
                                                pod.Item2.Status.Phase == "Failed")
                                            {
                                                Logger.LogInformation("Get metadata update on a pod that listen to logs, but the pod is not ready for listening to logs");
                                            }
                                            else if ((pod.Item2.Status.Phase == "Running" || pod.Item2.Status.Phase == "Pending") &&
                                                     DeployementCheckedForLogs.Any(d => pod.Item2.Metadata.Name.StartsWith(d)))
                                            {
                                                taskList.Add(ListenTopPodLogs(PodLogsTaskKey(@namespace, podName), @namespace, podName));
                                            }
                                            else
                                            {
                                                Logger.LogWarning("Unknow state recieved from the hub");
                                                Logger.LogWarning(WatchEventType.Modified.ToString());
                                                Logger.LogWarning(JsonSerializer.Serialize(pod.Item2));
                                            }
                                        }
                                    }
                                    else
                                    {
                                        var message = $"Failed to update pod {pod.Item2.Metadata.Name}";
                                        Logger.LogError(message);
                                        Error = message;
                                    }
                                    break;
                                default:
                                    throw new InvalidOperationException($"Unknow {nameof(WatchEventType)} with value {pod.Item1}");
                            }

                            await InvokeAsync(() =>
                            {
                                StateHasChanged();
                            });
                        }
                    }

                    await Task.WhenAll(taskList);
                })
                });
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message, e);
                Error = $"RunK8sDashboarde: {e.Message}{Environment.NewLine}You may want to reload the page to fully restore the live refresh";
            }
        }

        private async Task OnPodLogClick(ChangeEventArgs args, string podNamespace, string podName)
        {
            var taskKey = PodLogsTaskKey(podNamespace, podName);

            if (TokensBag.TryGetValue(taskKey, out var tokenSourceCancellation))
            {
                tokenSourceCancellation.Cancel();

                TokensBag.Remove(taskKey);
            }
            else
            {
                await ListenTopPodLogs(taskKey, podNamespace, podName);
            }
        }

        public async Task ListenTopPodLogs(string taskKey, string podNamespace, string podName)
        {
            CancellationTokenSource tokenSource = new();

            try
            {
                var channel = await logHubConnection.StreamAsChannelAsync<string>("GetPodLog", podNamespace, podName, tokenSource.Token);

                TokensBag.Add(taskKey, tokenSource);

                while (await channel.WaitToReadAsync(tokenSource.Token))
                {
                    while (channel.TryRead(out var log))
                    {
                        PodLogs.Add(log);
                        StateHasChanged();
                        if (ScrollToBottom)
                        {
                            await JS.InvokeVoidAsync("window.scrollToBottom");
                        }
                    }
                }
            }
            catch (OperationCanceledException e)
            {
                Logger.LogInformation($"{e.Message}{Environment.NewLine}{e.StackTrace}");
            }
        }

        public string PodLogsTaskKey(string podNamespace, string podName) => $"{podNamespace}{podName}";

        public HashSet<string> DeployementCheckedForLogs { get; } = new();

        private async Task OnDeploymentLogClick(ChangeEventArgs args, string deploymentNamespace, string deploymentName)
        {
            try
            {
                DeployementCheckedForLogs.Add(deploymentName);

                List<Task> taskList = new();

                foreach (var pod in Pods.Values)
                {
                    if (pod.Name().StartsWith(deploymentName))
                    {
                        var keyHashSet = $"{deploymentNamespace}-{deploymentName}";

                        taskList.Add(OnPodLogClick(args, deploymentNamespace, pod.Name()).ContinueWith(task =>
                        {
                            try
                            {
                                DeployementCheckedForLogs.Remove(keyHashSet);
                            }
                            catch { }

                            return Task.CompletedTask;
                        }));
                    }
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
                catch { }

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

        private void ClearLogs()
        {
            while (PodLogs.TryTake(out _)) { }
        }

        private bool ScrollToBottom { get; set; }

        public void ChangeScrollToBottom()
        {
            ScrollToBottom = !ScrollToBottom;
        }

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

        public void Dispose()
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
    }
}