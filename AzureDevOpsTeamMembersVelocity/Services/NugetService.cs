using AzureDevOpsTeamMembersVelocity.Model;
using AzureDevOpsTeamMembersVelocity.Proxy;
using System.Threading.Tasks;

namespace AzureDevOpsTeamMembersVelocity.Services
{
    /// <summary>
    /// Service class to interact with Azure DevOps REST API related to nugets and feeds.
    /// </summary>
    public class NugetService
    {
        private readonly IDevOpsProxy _proxy;
        private readonly TeamMembersVelocitySettings _settings;

        /// <summary>
        /// Constructor with dependencies
        /// </summary>
        /// <param name="proxy"></param>
        /// <param name="settings"></param>
        public NugetService(IDevOpsProxy proxy, TeamMembersVelocitySettings settings)
        {
            _proxy = proxy;
            _settings = settings;
        }

        /// <summary>
        /// Get all the feed of an organisation or of a team project
        /// </summary>
        /// <param name="teamProject"></param>
        /// <returns></returns>
        public async Task<ListResponse<Feed>?> GetFeeds(string? teamProject = null)
        {
            ListResponse<Feed>? response;
            
            if (string.IsNullOrWhiteSpace(teamProject))
            {
                // Fetch the organization feeds
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

        /// <summary>
        /// Get all nuget of a feed, with the possibility to pass a search term
        /// </summary>
        /// <param name="feedUrl"></param>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        public async Task<(ListResponse<Model.Nuget>?, string?)> GetNugets(string feedUrl, string? searchTerm = null)
        {
            if (string.IsNullOrWhiteSpace(searchTerm) == false)
            {
                feedUrl += $"?packageNameQuery={searchTerm}";
            }

            var response = await _proxy.GetAsync<ListResponse<Model.Nuget>>(feedUrl);

            return response;
        }
    }
}
