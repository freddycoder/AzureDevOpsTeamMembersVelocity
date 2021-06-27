using Microsoft.Extensions.DependencyInjection;
using System;

namespace AzureDevOpsTeamMembersVelocity.Extensions
{
    public static class AddDitributedCachingExtension
    {
        public static IServiceCollection AddDistributedCaching(this IServiceCollection services)
        {
            if (string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("REDIS_HOSTNAME")))
            {
                services.AddDistributedMemoryCache();
            }
            else
            {
                var redisHostname = Environment.GetEnvironmentVariable("REDIS_HOSTNAME");

                services.AddDistributedRedisCache(o =>
                {
                    o.Configuration = redisHostname;
                });
            }

            return services;
        }
    }
}
