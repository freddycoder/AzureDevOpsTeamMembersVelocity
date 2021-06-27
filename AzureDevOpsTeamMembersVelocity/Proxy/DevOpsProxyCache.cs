using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureDevOpsTeamMembersVelocity.Proxy
{
    public class DevOpsProxyCache : IDevOpsProxy
    {
        private readonly DevOpsProxy _proxy;
        private readonly ILogger<DevOpsProxyCache> _logger;

        private ConcurrentDictionary<string, CacheInstance<string>> StringCache { get; set; } = new ();

        private readonly TimeSpan CacheSeconde = TimeSpan.FromSeconds(int.Parse(Environment.GetEnvironmentVariable("DevOpsProxyCacheSeconds") ?? "1"));

        public DevOpsProxyCache(DevOpsProxy proxy, ILogger<DevOpsProxyCache> logger)
        {
            _proxy = proxy;
            _logger = logger;
        }

        public async Task<(string?, string?)> GetAsync(string fullUrl)
        {
            if (StringCache.TryGetValue(fullUrl, out var cacheInstance))
            {
                if (cacheInstance.Expiration > DateTime.Now)
                {
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

        public async Task<(T?, string?)> GetAsync<T>(string fullUrl)
        {
            if (ObjectCache.TryGetValue(fullUrl, out var cacheInstance))
            {
                if (cacheInstance.Expiration > DateTime.Now)
                {
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
