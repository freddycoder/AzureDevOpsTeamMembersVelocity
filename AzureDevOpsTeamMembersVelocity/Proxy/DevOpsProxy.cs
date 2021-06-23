using Microsoft.Extensions.Logging;
using RateLimiter;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ComposableAsync;

namespace AzureDevOpsTeamMembersVelocity.Proxy
{
    /// <summary>
    /// DevOpsProxy class is used to call Azure DevOps REST API. 
    /// Implement rate-limiting and ensure URL validation.
    /// </summary>
    public class DevOpsProxy : IDevOpsProxy
    {
        private static readonly TimeLimiter TimeConstrainte = TimeLimiter.GetFromMaxCountByInterval(30, TimeSpan.FromSeconds(1));
        private readonly TeamMembersVelocitySettings _appSettings;
        private readonly ILogger<DevOpsProxy> _logger;
        private readonly HttpClient _client;

        /// <summary>
        /// Constructor with dependencies
        /// </summary>
        /// <param name="client">HttpClient to used</param>
        /// <param name="appSettings">App settings, to acces AuthenticationHeader</param>
        /// <param name="logger">Logger to log information and critical error</param>
        public DevOpsProxy(HttpClient client, TeamMembersVelocitySettings appSettings, ILogger<DevOpsProxy> logger)
        {
            _appSettings = appSettings;
            _logger = logger;
            _client = client;
        }

        /// <summary>
        /// Get the body content of a response according to a fullUrl
        /// </summary>
        /// <param name="fullUrl">Complete URL of the resource to fetch. Must start with https://dev.azure.com/</param>
        /// <returns>The response body as a string</returns>
        public async Task<string?> GetAsync(string fullUrl)
        {
            _logger.LogInformation($"Try fetch {fullUrl}");

            try
            {
                using HttpResponseMessage response = await GetResponseAsync(fullUrl);
                
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, ex.Message);
            }

            return default;
        }

        /// <summary>
        /// Get the body content of a response according to a fullUrl
        /// </summary>
        /// <typeparam name="T">Type used in deserialization</typeparam>
        /// <param name="fullUrl">Complete URL of the resource to fetch. Must start with https://dev.azure.com/</param>
        /// <returns>The response body Deserialized as T</returns>
        public async Task<T?> GetAsync<T>(string fullUrl)
        {
            _logger.LogInformation($"Try fetch {fullUrl}");

            try
            {
                using HttpResponseMessage response = await GetResponseAsync(fullUrl);

                var responseBody = await response.Content.ReadAsByteArrayAsync();

                var responsesDeserialized = JsonSerializer.Deserialize<T>(responseBody, Program.SerializerOptions);

                return responsesDeserialized;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, ex.Message);
            }

            return default;
        }

        private async Task<HttpResponseMessage> GetResponseAsync(string fullUrl)
        {
            if ((fullUrl.StartsWith("https://dev.azure.com/", StringComparison.OrdinalIgnoreCase) || 
                 fullUrl.StartsWith("https://feeds.dev.azure.com/", StringComparison.OrdinalIgnoreCase)) == false)
            {
                throw new InvalidOperationException("DevOpsProxy fullUrl must start with 'https://dev.azure.com' or 'https://feeds.dev.azure.com/'");
            }
            if (fullUrl.Contains('\n'))
            {
                throw new InvalidOperationException("DevOpsProxy fullUrl must not contains any '\\n'");
            }

            _client.DefaultRequestHeaders.Authorization = _appSettings.AuthenticationHeader;

            await TimeConstrainte;

            var response = await _client.GetAsync(fullUrl);

            response.EnsureSuccessStatusCode();

            return response;
        }
    }
}
