using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureDevOpsTeamMembersVelocity.Proxy
{
    /// <summary>
    /// Class to add response caching on the IDevOpsProxy. The main goal of this class
    /// is to avoid calling two time the API when call are made in short time distance.
    /// But in fact, there is no time limit. To configure the cache, set a integer number
    /// value to the DevOpsProxyCacheSeconds envrionment variable. If the variable dosen't
    /// exist, a default value of 1 second is apply, otherwise to value configured is apply.
    /// </summary>
    public class DevOpsProxyCache : IDevOpsProxy
    {
        private readonly DevOpsProxy _proxy;
        private readonly ILogger<DevOpsProxyCache> _logger;

        private ConcurrentDictionary<string, CacheInstance<string>> StringCache { get; set; } = new ();

        private readonly TimeSpan CacheSeconde = TimeSpan.FromSeconds(int.Parse(Environment.GetEnvironmentVariable("DevOpsProxyCacheSeconds") ?? "1"));

        /// <summary>
        /// Constructor with dependencies
        /// </summary>
        /// <param name="proxy">The base implementation of IDevOpsProxy</param>
        /// <param name="logger">Allow to log information when returning an instance from cache</param>
        public DevOpsProxyCache(DevOpsProxy proxy, ILogger<DevOpsProxyCache> logger)
        {
            _proxy = proxy;
            _logger = logger;
        }

        /// <summary>
        /// If a value is find is cache, no network call is made, otherwise a network call is made
        /// and if the result is good, the value is put in cache.
        /// </summary>
        public async Task<(string?, string?)> GetAsync(string fullUrl)
        {
            if (StringCache.TryGetValue(fullUrl, out var cacheInstance))
            {
                if (cacheInstance.Expiration > DateTime.Now)
                {
                    _logger.LogInformation($"Find in cache {fullUrl}");

                    return (cacheInstance.Instance, default);
                }
                else
                {
                    if (StringCache.Remove(fullUrl, out var _) == false)
                    {
                        if (StringCache.TryRemove(fullUrl, out var _))
                        {
                            _logger.LogCritical($"Impossible to remove {fullUrl} from cache. Clearing the cache");
                            StringCache.Clear();
                        }
                    }
                }
            }

            var response = await _proxy.GetAsync(fullUrl);

            if (response.Item1 != null)
            {
                StringCache.TryAdd(fullUrl, new CacheInstance<string>(DateTime.Now + CacheSeconde, response.Item1));
            }

            return response;
        }

        private ConcurrentDictionary<string, CacheInstance<object>> ObjectCache { get; set; } = new();

        /// <summary>
        /// If a value is find is cache, no network call is made, otherwise a network call is made
        /// and if the result is good, the value is put in cache.
        /// </summary>
        public async Task<(T?, string?)> GetAsync<T>(string fullUrl)
        {
            if (ObjectCache.TryGetValue(fullUrl, out var cacheInstance))
            {
                if (cacheInstance.Expiration > DateTime.Now)
                {
                    _logger.LogInformation($"Find in cache {fullUrl}");

                    return ((T) cacheInstance.Instance, default);
                }
                else
                {
                    if (ObjectCache.Remove(fullUrl, out var _) == false)
                    {
                        if (ObjectCache.TryRemove(fullUrl, out var _) == false)
                        {
                            _logger.LogCritical($"Impossible to remove {fullUrl} from cache. Clearing the cache");
                            ObjectCache.Clear();
                        }
                    }
                }
            }

            var response = await _proxy.GetAsync<T>(fullUrl);

            if (response.Item1 != null)
            {
                ObjectCache.TryAdd(fullUrl, new CacheInstance<object>(DateTime.Now + CacheSeconde, response.Item1));
            }

            return response;
        }
    }

    /// <summary>
    /// Use to store element inside the <see cref="DevOpsProxyCache"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CacheInstance<T>
    {
        /// <summary>
        /// Create a cache instance object with the expiration date and the instance to
        /// keep in cache.
        /// </summary>
        /// <param name="expiration">The expiration date</param>
        /// <param name="instance">The value to keep in cache</param>
        public CacheInstance(DateTime expiration, T instance)
        {
            Expiration = expiration;
            Instance = instance;
        }

        /// <summary>
        /// The expiration of the cache instance
        /// </summary>
        public DateTime Expiration { get; }

        /// <summary>
        /// The value of cached
        /// </summary>
        public T Instance { get; }
    }
}
