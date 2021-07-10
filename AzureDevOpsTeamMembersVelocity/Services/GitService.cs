using AzureDevOpsTeamMembersVelocity.Model;
using AzureDevOpsTeamMembersVelocity.Proxy;
using System.Threading.Tasks;

namespace AzureDevOpsTeamMembersVelocity.Services
{
    /// <summary>
    /// A service to communicate with azure devops git services
    /// </summary>
    public class GitService
    {
        private readonly IDevOpsProxy _proxy;

        /// <summary>
        /// Constructor with dependencies
        /// </summary>
        /// <param name="proxy">The proxy to call the azure devops API</param>
        public GitService(IDevOpsProxy proxy)
        {
            _proxy = proxy;
        }

        /// <summary>
        /// List all repository of the current selected Organisation and TeamProject
        /// </summary>
        /// <returns>A task that list Repositories</returns>
        public Task<(ListResponse<GitRepository>?, string?)> GetRepositories(string organization, string teamProject)
        {
            return _proxy.GetAsync<ListResponse<GitRepository>>(
    $"https://dev.azure.com/{organization}/{teamProject}/_apis/git/repositories?api-version=6.0");
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
        public Task<(ListResponse<Microsoft.TeamFoundation.SourceControl.WebApi.GitPullRequest>?,string?)> GetPullRequests(string pullRequestUrl)
        {
            return _proxy.GetAsync<ListResponse<Microsoft.TeamFoundation.SourceControl.WebApi.GitPullRequest>>($"{pullRequestUrl}?api-version=6.0");
        }

        /// <summary>
        /// Get a pull request
        /// </summary>
        /// <param name="pullRequestUrl">The pull request url</param>
        /// <returns>A PR and an error if any</returns>
        public Task<(Microsoft.TeamFoundation.SourceControl.WebApi.GitPullRequest?, string?)> GetPullRequest(string pullRequestUrl)
        {
            return _proxy.GetAsync<Microsoft.TeamFoundation.SourceControl.WebApi.GitPullRequest?>($"{pullRequestUrl}?api-version=6.0");
        }
    }
}
