using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using static System.Environment;

namespace AzureDevOpsTeamMembersVelocity.Extensions
{
    public static class UseForwardedHeadersExtension
    {
        public static IServiceCollection AddTeamVelocityForwardedHeaders(this IServiceCollection services)
        {
            if (string.Equals(GetEnvironmentVariable("Forwarded_headers"), bool.TrueString, StringComparison.OrdinalIgnoreCase))
            {
                services.Configure<ForwardedHeadersOptions>(options =>
                {
                    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;

                    foreach (var network in GetEnvironmentVariable("KNOW_NETWORKS")?.Split(';') ?? Array.Empty<string>())
                    {
                        var ipInfo = network.Split("/");

                        options.KnownNetworks.Add(new IPNetwork(IPAddress.Parse(ipInfo[0]), int.Parse(ipInfo[1])));
                    }
                });
            }

            return services;
        }

        public static IApplicationBuilder UseTeamMembersVelocityForwardedHeadersRules(this IApplicationBuilder app, ILogger<Startup> logger)
        {
            if (string.Equals(GetEnvironmentVariable("Forwarded_headers"), bool.TrueString, StringComparison.OrdinalIgnoreCase))
            {
                app.UseForwardedHeaders();

                DebugHeaders(app, logger);
                
                if (string.Equals(GetEnvironmentVariable("USE_SCHEMA_FROM_PROXY"), bool.TrueString, StringComparison.CurrentCultureIgnoreCase))
                {
                    app.Use(async (context, next) =>
                    {
                        if (context.Request.Headers.TryGetValue("X-Forwarded-Proto", out var forwardedProto))
                        {
                            context.Request.Scheme = forwardedProto;
                        }

                        await next();
                    });
                }
            }

            return app;
        }

        private static void DebugHeaders(IApplicationBuilder app, ILogger<Startup> logger)
        {
            if (string.Equals(GetEnvironmentVariable("Debug_headers"), bool.TrueString, StringComparison.OrdinalIgnoreCase))
            {
                app.Use(async (context, next) =>
                {
                    // Request method, scheme, and path
                    logger.LogDebug("Request Method: {Method}", context.Request.Method);
                    logger.LogDebug("Request Scheme: {Scheme}", context.Request.Scheme);
                    logger.LogDebug("Request Path: {Path}", context.Request.Path);

                    // Headers
                    foreach (var header in context.Request.Headers)
                    {
                        logger.LogDebug("Header: {Key}: {Value}", header.Key, header.Value);
                    }

                    // Connection: RemoteIp
                    logger.LogDebug("Request RemoteIp: {RemoteIpAddress}",
                        context.Connection.RemoteIpAddress);

                    await next();
                });
            }
        }
    }
}
