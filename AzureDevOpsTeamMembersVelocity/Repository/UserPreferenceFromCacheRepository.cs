using AzureDevOpsTeamMembersVelocity.Settings;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace AzureDevOpsTeamMembersVelocity.Repository
{
    /// <summary>
    /// User preference repository to store user preference in a distributed cache store.
    /// </summary>
    public class UserPreferenceFromCacheRepository : IUserPreferenceRepository
    {
        private readonly IDistributedCache _cache;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILogger<UserPreferenceFromCacheRepository> _logger;
        private readonly Dictionary<string, AbstractSettings> _memory;

        /// <summary>
        /// Constructor with dependencies
        /// </summary>
        /// <param name="cache">The sitributed cache</param>
        /// <param name="authenticationStateProvider">AuthenticationStateProvider to fetch user info</param>
        /// <param name="logger">Logger to log information and error</param>
        public UserPreferenceFromCacheRepository(IDistributedCache cache, AuthenticationStateProvider authenticationStateProvider, ILogger<UserPreferenceFromCacheRepository> logger)
        {
            _cache = cache;
            _authenticationStateProvider = authenticationStateProvider;
            _logger = logger;
            _memory = new();
        }

        /// <summary>
        /// Get a user settings. If the settings as never been store, a new instance is return.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public async Task<T> GetAsync<T>() where T : AbstractSettings
        {
            var user = await _authenticationStateProvider.GetAuthenticationStateAsync();

            var key = KeyOf<T>(user);

            if (_memory.TryGetValue(key, out var settingsCached) && settingsCached != null)
            {
                return (T) settingsCached;
            }

            _logger.LogInformation($"Load {typeof(T).Name} from cache");

            var cacheValue = await _cache.GetStringAsync(key);

            if (cacheValue != null)
            {
                var settings = JsonSerializer.Deserialize<T>(cacheValue, Program.SerializerOptions);

                if (settings != null)
                {
                    StoreInMemory(key, settings);

                    return settings;
                }
            }

            return Activator.CreateInstance<T>();
        }

        /// <summary>
        /// Set the preference type into the repository. If null is passed, 
        /// the function immediatly return. nothing append. If the value 
        /// already in the repository, the object is replace
        /// </summary>
        /// <typeparam name="T">The type of the preference</typeparam>
        /// <param name="settings">The instance to save</param>
        public async Task SetAsync<T>(T settings) where T : AbstractSettings
        {
            if (settings == null || settings.AsNotChanged()) return;

            var user = await _authenticationStateProvider.GetAuthenticationStateAsync();

            _logger.LogInformation($"Set {typeof(T).Name} in cache");

            var key = KeyOf<T>(user);

            await _cache.SetStringAsync(key, JsonSerializer.Serialize(settings, Program.SerializerOptions));

            StoreInMemory(key, settings);

            settings.Saved();
        }

        private static string KeyOf<T>(AuthenticationState user)
        {
            return $"{user?.User?.Identity?.Name}_{typeof(T).Name}";
        }

        private void StoreInMemory(string key, AbstractSettings settings)
        {
            if (settings != null)
            {
                try
                {
                    if (_memory.ContainsKey(key))
                    {
                        _memory[key] = settings;
                    }
                    else
                    {
                        _memory.Add(key, settings);
                    }
                }
                catch (Exception e)
                {
                    _logger.LogCritical(e, e.Message);
                }
            }
        }
    }
}
