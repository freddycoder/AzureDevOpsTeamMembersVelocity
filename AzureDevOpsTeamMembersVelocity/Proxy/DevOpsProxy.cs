using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AzureDevOpsTeamMembersVelocity.Proxy
{
    public class DevOpsProxy
    {
        private readonly TeamMembersVelocitySettings _appSettings;

        public DevOpsProxy(TeamMembersVelocitySettings appSettings)
        {
            _appSettings = appSettings;
        }

        public async Task<T> GetAsync<T>(string fullUrl)
        {
            Console.WriteLine($"Try fetch {fullUrl}");

            try
            {
                var personalaccesstoken = _appSettings.ApiKey;

                using HttpClient client = new();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "", personalaccesstoken))));

                using HttpResponseMessage response = await client.GetAsync(fullUrl);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);

                var responsesDeserialized = JsonSerializer.Deserialize<T>(responseBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                    WriteIndented = true
                });

                return responsesDeserialized;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
            }

            return default;
        }
    }
}
