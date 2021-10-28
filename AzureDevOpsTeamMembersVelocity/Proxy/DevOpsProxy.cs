using Microsoft.Extensions.Logging;
using RateLimiter;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ComposableAsync;
using AzureDevOpsTeamMembersVelocity.Repository;
using Microsoft.Identity.Client;
using System.Linq;
using AzureDevOpsTeamMembersVelocity.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Components.Authorization;

using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Identity.Web;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using static System.Net.WebRequestMethods;
using Org.BouncyCastle.Asn1.Crmf;
using System.Runtime;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Caching.Distributed;

namespace AzureDevOpsTeamMembersVelocity.Proxy
{
    /// <summary>
    /// DevOpsProxy class is used to call Azure DevOps REST API. 
    /// Implement rate-limiting and ensure URL validation.
    /// </summary>
    public class DevOpsProxy : IDevOpsProxy
    {
        private static readonly TimeLimiter TimeConstrainte = TimeLimiter.GetFromMaxCountByInterval(29, TimeSpan.FromSeconds(1));
        private readonly IUserPreferenceRepository _appSettings;
        private readonly ILogger<DevOpsProxy> _logger;
        private readonly IConfiguration _config;
        private readonly IServiceProvider _serviceProvider;
        private readonly HttpClient _client;

        /// <summary>
        /// Constructor with dependencies
        /// </summary>
        /// <param name="client">HttpClient to used</param>
        /// <param name="appSettings">App settings, to acces AuthenticationHeader</param>
        /// <param name="logger">Logger to log information and critical error</param>
        public DevOpsProxy(IHttpClientFactory client, 
            IUserPreferenceRepository appSettings, 
            IConfiguration config,
            IServiceProvider serviceProvider,
            ILogger<DevOpsProxy> logger)
        {
            _appSettings = appSettings;
            _logger = logger;
            _config = config;
            _serviceProvider = serviceProvider;
            _client = client.CreateClient(nameof(DevOpsProxy));
        }

        /// <summary>
        /// Get the body content of a response according to a fullUrl
        /// </summary>
        /// <param name="fullUrl">Complete URL of the resource to fetch. Must start with https://dev.azure.com/</param>
        /// <returns>The response body as a string</returns>
        public async Task<(string?, string?)> GetAsync(string fullUrl)
        {
            _logger.LogInformation($"Try fetch {fullUrl}");

            try
            {
                using HttpResponseMessage response = await GetResponseAsync(fullUrl);
                
                return (await response.Content.ReadAsStringAsync(), default);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, ex.Message);

                return (default, ex.Message);
            }
        }

        /// <summary>
        /// Get the body content of a response according to a fullUrl
        /// </summary>
        /// <typeparam name="T">Type used in deserialization</typeparam>
        /// <param name="fullUrl">Complete URL of the resource to fetch. Must start with https://dev.azure.com/</param>
        /// <returns>The response body Deserialized as T</returns>
        public async Task<(T?, string?)> GetAsync<T>(string fullUrl)
        {
            _logger.LogInformation($"Try fetch {fullUrl}");

            try
            {
                using HttpResponseMessage response = await GetResponseAsync(fullUrl);

                var responseBody = await response.Content.ReadAsByteArrayAsync();

                var responsesDeserialized = JsonSerializer.Deserialize<T>(responseBody, Program.SerializerOptions);

                return (responsesDeserialized, default);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, ex.Message);

                return (default, ex.Message);
            }
        }

        private async Task<HttpResponseMessage> GetResponseAsync(string fullUrl)
        {
            if (!(fullUrl.StartsWith("https://dev.azure.com/", StringComparison.OrdinalIgnoreCase) || 
                  fullUrl.StartsWith("https://feeds.dev.azure.com/", StringComparison.OrdinalIgnoreCase) ||
                  fullUrl.StartsWith("https://vsrm.dev.azure.com/", StringComparison.OrdinalIgnoreCase))) 
            {
                throw new InvalidOperationException("DevOpsProxy fullUrl must start with 'https://dev.azure.com' or 'https://feeds.dev.azure.com/' or 'https://vsrm.dev.azure.com/'");
            }
            if (fullUrl.Contains('\n'))
            {
                throw new InvalidOperationException("DevOpsProxy fullUrl must not contains any '\\n'");
            }

            if (!AddAuthentificationExtension.IsAzureADAuth(_config))
            {
                TeamMembersVelocitySettings settings = await _appSettings.GetAsync<TeamMembersVelocitySettings>();

                _client.DefaultRequestHeaders.Authorization = settings.AuthenticationHeader;
            }
            else
            {
                var cache = _serviceProvider.GetRequiredService<IDistributedCache>();
                var userInfo = _serviceProvider.GetRequiredService<AuthenticationStateProvider>();

                var authState = await userInfo.GetAuthenticationStateAsync();

                var userId = authState.User.Claims.First(c => c.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier" || 
                                                              c.Type == "uid");

                var key = $"{userId.Value}.{_config["AzureAD:TenantId"]}";

                var token = await cache.GetStringAsync(key);

                var tokenProvider = _serviceProvider.GetRequiredService<ITokenAcquisition>();

                try 
                {
                    var tokens = await tokenProvider.GetAccessTokenForUserAsync(new[]
                    {
                        "https://app.vssps.visualstudio.com/user_impersonation",
                        "https://app.vssps.visualstudio.com/vso.work"
                    });

                    _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokens);
                }
                catch (Exception e)
                {
                    var handler = _serviceProvider.GetRequiredService<MicrosoftIdentityConsentAndConditionalAccessHandler>();

                    handler.HandleException(e);

                    var tokens = await tokenProvider.GetAccessTokenForUserAsync(new[]
                    {
                        "https://app.vssps.visualstudio.com/user_impersonation",
                        "https://app.vssps.visualstudio.com/vso.work"
                    });

                    _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokens);
                }
            }

            await TimeConstrainte;

            var response = await _client.GetAsync(fullUrl);

            response.EnsureSuccessStatusCode();

            if (response.StatusCode == System.Net.HttpStatusCode.NonAuthoritativeInformation)
            {
                var exception = new UnauthorizedAccessException("203: Authentication failed when calling the Azure DevOps REST API");

                exception.Data.Add("HttpResponse", await response.Content.ReadAsStringAsync());

                throw exception;
            }

            return response;
        }
    }
}
