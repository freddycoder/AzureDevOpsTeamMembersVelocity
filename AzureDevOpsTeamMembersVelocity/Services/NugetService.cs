using AzureDevOpsTeamMembersVelocity.Model;
using AzureDevOpsTeamMembersVelocity.Proxy;
using System;
using System.Threading.Tasks;

namespace AzureDevOpsTeamMembersVelocity.Services
{
    public class NugetService
    {
        private readonly IDevOpsProxy _proxy;
        private readonly TeamMembersVelocitySettings _settings;

        public NugetService(IDevOpsProxy proxy, TeamMembersVelocitySettings settings)
        {
            _proxy = proxy;
            _settings = settings;
        }

        public async Task<ListResponse<Feed>?> GetFeeds(string? teamProject = null)
        {
            ListResponse<Feed>? response;
            
            if (string.IsNullOrWhiteSpace(teamProject))
            {
                response = await _proxy.GetAsync<ListResponse<Feed>>
                    ($"https://feeds.dev.azure.com/{_settings.Organisation}/_apis/packaging/feeds?api-version=6.0-preview.1");
            }
            else
            {
                // Fetch the team project feeds
                response = await _proxy.GetAsync<ListResponse<Feed>>
                    ($"https://feeds.dev.azure.com/{_settings.Organisation}/{teamProject}/_apis/packaging/feeds?api-version=6.0-preview.1");
            }

            return response;
        }

        public async Task<ListResponse<Model.Nuget>?> GetNugets(string feedUrl)
        {
            var response = await _proxy.GetAsync<ListResponse<Model.Nuget>>(feedUrl);

            return response;
        }
    }
}
