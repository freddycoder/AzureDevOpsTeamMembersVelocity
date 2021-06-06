using Microsoft.Extensions.Logging;
using RateLimiter;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ComposableAsync;
using System.IO;

namespace AzureDevOpsTeamMembersVelocity.Proxy
{
    public class DevOpsProxy
    {
        private static readonly TimeLimiter TimeConstrainte = TimeLimiter.GetFromMaxCountByInterval(30, TimeSpan.FromSeconds(1));
        private readonly TeamMembersVelocitySettings _appSettings;
        private readonly ILogger<DevOpsProxy> _logger;
        private readonly HttpClient client;

        public DevOpsProxy(HttpClient client, TeamMembersVelocitySettings appSettings, ILogger<DevOpsProxy> logger)
        {
            _appSettings = appSettings;
            _logger = logger;
            this.client = client;
        }

        public async Task<string?> GetAsync(string fullUrl)
        {
            _logger.LogInformation($"Try fetch {fullUrl}");

            try
            {
                client.DefaultRequestHeaders.Authorization = _appSettings.AuthenticationHeader;

                await TimeConstrainte;

                using HttpResponseMessage response = await client.GetAsync(fullUrl);
                
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, ex.Message);
            }

            return default;
        }

        public async Task<T?> GetAsync<T>(string fullUrl)
        {
            _logger.LogInformation($"Try fetch {fullUrl}");

            try
            {
                var personalaccesstoken = _appSettings.ApiKey;
                client.DefaultRequestHeaders.Authorization = _appSettings.AuthenticationHeader;

                await TimeConstrainte;

                using HttpResponseMessage response = await client.GetAsync(fullUrl);

                response.EnsureSuccessStatusCode();

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
    }
}
