using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AzureDevOpsTeamMembersVelocity.Extensions
{
    /// <summary>
    /// Class containing extension method to register the IDistributedCache implementation
    /// </summary>
    public static class AddDistributedCachingExtension
    {
        /// <summary>
        /// Register the IDistributedCache implementation. If REDIS_HOSTNAME environment variable is
        /// null or whitespace, the InMemory implementation is register otherwise, the RedisCache 
        /// implementation is register.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddDistributedCaching(this IServiceCollection services)
        {
            var redisHostname = Environment.GetEnvironmentVariable("REDIS_HOSTNAME");

            if (string.IsNullOrWhiteSpace(redisHostname))
            {
                services.AddDistributedMemoryCache();
            }
            else
            {
                services.AddOptions();

                services.Configure<RedisCacheOptions>(o =>
                {
                    o.Configuration = redisHostname;
                });

                services.AddSingleton<IDistributedCache, RedisCache>();
            }

            return services;
        }
    }
}
