using AzureDevOpsTeamMembersVelocity.Settings;
using AzureDevOpsTeamMembersVelocity.Proxy;
using System.Threading.Tasks;

namespace AzureDevOpsTeamMembersVelocity.Services
{
    /// <summary>
    /// Service to interact with the Release part of the Azure DevOps REST API
    /// </summary>
    public class ReleasesService
    {
        private readonly IDevOpsProxy _proxy;

        /// <summary>
        /// Constructor with dependencies
        /// </summary>
        /// <param name="proxy"></param>
        public ReleasesService(IDevOpsProxy proxy)
        {
            _proxy = proxy;
        }

        /// <summary>
        /// List relase of an organisation team project.
        /// </summary>
        /// <remarks>
        /// Microoft documentation: https://docs.microsoft.com/en-us/rest/api/azure/devops/release/releases/list?view=azure-devops-rest-6.0#release
        /// </remarks>
        /// <param name="organization"></param>
        /// <param name="teamProject"></param>
        /// <returns></returns>
        public Task<(ListResponse<Microsoft.VisualStudio.Services.ReleaseManagement.WebApi.Release>?, string?)> ListReleases(string organization, string teamProject)
        {
            return _proxy.GetAsync<ListResponse<Microsoft.VisualStudio.Services.ReleaseManagement.WebApi.Release>>(
$"https://vsrm.dev.azure.com/{organization}/{teamProject}/_apis/release/releases?api-version=6.0");
        }

        /// <summary>
        /// Get a list of releases definition for a team project.
        /// </summary>
        /// <remarks>
        /// Microsoft documentation: https://docs.microsoft.com/en-us/rest/api/azure/devops/release/definitions/list?view=azure-devops-rest-6.0
        /// </remarks>
        public Task<(ListResponse<Microsoft.VisualStudio.Services.ReleaseManagement.WebApi.ReleaseDefinition>?, string?)> ListDefinition(string organization, string teamProject, ListDefinitionFilter? listDefinitionFilter = default)
        {
            string releaseDefinitionUrl = $"https://vsrm.dev.azure.com/{organization}/{teamProject}/_apis/release/definitions?api-version=6.0";

            if (listDefinitionFilter != null)
            {
                releaseDefinitionUrl = listDefinitionFilter.AppendParameterToQueryString(releaseDefinitionUrl);
            }

            return _proxy.GetAsync<ListResponse<Microsoft.VisualStudio.Services.ReleaseManagement.WebApi.ReleaseDefinition>>(releaseDefinitionUrl);
        }
    }
}
