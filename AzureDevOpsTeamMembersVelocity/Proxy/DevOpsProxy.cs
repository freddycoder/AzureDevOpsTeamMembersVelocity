using Microsoft.Extensions.Logging;
using RateLimiter;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ComposableAsync;

namespace AzureDevOpsTeamMembersVelocity.Proxy
{
    public class DevOpsProxy
    {
        private static readonly TimeLimiter TimeConstrainte = TimeLimiter.GetFromMaxCountByInterval(30, TimeSpan.FromSeconds(1));
        private readonly TeamMembersVelocitySettings _appSettings;
        private readonly ILogger<DevOpsProxy> _logger;

        public DevOpsProxy(TeamMembersVelocitySettings appSettings, ILogger<DevOpsProxy> logger)
        {
            _appSettings = appSettings;
            _logger = logger;
        }

        public async Task<string> GetAsync(string fullUrl)
        {
            _logger.LogInformation($"Try fetch {fullUrl}");

            try
            {
                var personalaccesstoken = _appSettings.ApiKey;

                using HttpClient client = new();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "", personalaccesstoken))));
                await TimeConstrainte;
                using HttpResponseMessage response = await client.GetAsync(fullUrl);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                _logger.LogDebug(responseBody);

                return responseBody;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, ex.Message);
            }

            return default;
        }

        public async Task<T> GetAsync<T>(string fullUrl)
        {
            _logger.LogInformation($"Try fetch {fullUrl}");

            try
            {
                var personalaccesstoken = _appSettings.ApiKey;

                using HttpClient client = new();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "", personalaccesstoken))));
                await TimeConstrainte;
                using HttpResponseMessage response = await client.GetAsync(fullUrl);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                _logger.LogDebug(responseBody);

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
