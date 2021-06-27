using AzureDevOpsTeamMembersVelocity.Model;
using AzureDevOpsTeamMembersVelocity.Proxy;
using AzureDevOpsTeamMembersVelocity.Repository;
using System.Threading.Tasks;

namespace AzureDevOpsTeamMembersVelocity.Services
{
    /// <summary>
    /// A service to communicate with azure devops git services
    /// </summary>
    public class GitService
    {
        private readonly IDevOpsProxy _proxy;
        private readonly IUserPreferenceRepository _settings;

        /// <summary>
        /// Constructor with dependencies
        /// </summary>
        /// <param name="proxy">The proxy to call the azure devops API</param>
        /// <param name="settings">Settings of the app to access Organization name and TeamProject name</param>
        public GitService(IDevOpsProxy proxy, IUserPreferenceRepository settings)
        {
            _proxy = proxy;
            _settings = settings;
        }

        /// <summary>
        /// List all repository of the current selected Organisation and TeamProject
        /// </summary>
        /// <returns>A task that list Repositories</returns>
        public async Task<(ListResponse<GitRepository>?, string?)> GetRepositories()
        {
            var settings = await _settings.GetAsync<TeamMembersVelocitySettings>();

            var url = $"https://dev.azure.com/{settings.Organisation}/{settings.TeamProject}/_apis/git/repositories?api-version=6.0";

            return await _proxy.GetAsync<ListResponse<GitRepository>>(url);
        }

        /// <summary>
        /// Fetch a git repository informations
        /// </summary>
        /// <param name="gitRepositoryUrl">Url of the resource</param>
        /// <returns>A task that return the GitRepository instance</returns>
        public Task<(GitRepository?, string?)> GetRepository(string gitRepositoryUrl)
        {
            return _proxy.GetAsync<GitRepository>($"{gitRepositoryUrl}?api-version=6.0");
        }

        /// <summary>
        /// List all pull request of a repository
        /// </summary>
        /// <param name="pullRequestUrl">The pull request url from a GitRepositoryUrl</param>
        /// <returns>A task that list pull requests</returns>
        public Task<(ListResponse<PullRequest>?,string?)> GetPullRequests(string pullRequestUrl)
        {
            return _proxy.GetAsync<ListResponse<PullRequest>>($"{pullRequestUrl}?api-version=6.0");
        }
    }
}
