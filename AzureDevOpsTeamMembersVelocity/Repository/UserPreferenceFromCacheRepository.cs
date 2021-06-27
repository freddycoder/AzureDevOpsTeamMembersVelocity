using AzureDevOpsTeamMembersVelocity.Settings;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Caching.Distributed;
using System;
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

        /// <summary>
        /// Constructor with dependencies
        /// </summary>
        /// <param name="cache">The sitributed cache</param>
        /// <param name="authenticationStateProvider">AuthenticationStateProvider to fetch user info</param>
        public UserPreferenceFromCacheRepository(IDistributedCache cache, AuthenticationStateProvider authenticationStateProvider)
        {
            _cache = cache;
            _authenticationStateProvider = authenticationStateProvider;
        }

        /// <summary>
        /// Get a user settings. If the settings as never been store, a new instance is return.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public async Task<T> GetAsync<T>() where T : AbstractSettings
        {
            var user = await _authenticationStateProvider.GetAuthenticationStateAsync();

            var cacheValue = await _cache.GetStringAsync(KeyOf<T>(user));

            if (cacheValue != null)
            {
                var settings = JsonSerializer.Deserialize<T>(cacheValue, Program.SerializerOptions);

                if (settings != null)
                {
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
            if (settings == null) return;

            var user = await _authenticationStateProvider.GetAuthenticationStateAsync();

            await _cache.SetStringAsync(KeyOf<T>(user), JsonSerializer.Serialize(settings, Program.SerializerOptions));
        }

        private static string KeyOf<T>(AuthenticationState user)
        {
            return $"{user?.User?.Identity?.Name}_{typeof(T).Name}";
        }
    }
}
