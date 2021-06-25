using AzureDevOpsTeamMembersVelocity.Proxy;
using Microsoft.TeamFoundation.SourceControl.WebApi;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AzureDevOpsTeamMembersVelocity.Services
{
    /// <summary>
    /// A service to communicate with azure devops git services
    /// </summary>
    public class GitService
    {
        private readonly IDevOpsProxy _proxy;
        private readonly TeamMembersVelocitySettings _settings;
        private readonly DevOpsService _devOpsService;

        /// <summary>
        /// Constructor with dependencies
        /// </summary>
        /// <param name="proxy">The proxy to call the azure devops API</param>
        /// <param name="settings">Settings of the app to access Organization name and TeamProject name</param>
        public GitService(IDevOpsProxy proxy, TeamMembersVelocitySettings settings, DevOpsService devOpsService)
        {
            _proxy = proxy;
            _settings = settings;
            _devOpsService = devOpsService;
        }

        /// <summary>
        /// List all repository of the current selected Organisation and TeamProject
        /// </summary>
        /// <returns>A task that list Repositories</returns>
        public Task<ListResponse<GitRepository>?> GetRepositories()
        {
            return _proxy.GetAsync<ListResponse<GitRepository>>(
                $"https://dev.azure.com/{_settings.Organisation}/{_settings.TeamProject}/_apis/git/repositories?api-version=6.0");
        }

        /// <summary>
        /// List all pull request of a repository
        /// </summary>
        /// <param name="repositoryId">The Id of the repostiry</param>
        /// <returns>A task that list pull requests</returns>
        public async Task<ListResponse<GitPullRequest>?> GetPullRequests(Guid repositoryId)
        {
            if (_settings.Organisation == null)
            {
                throw new InvalidOperationException("The Organization field of the TeamVelocitySettings must not be null to fetch pull requests");
            }

            var idTeamProject = (await _devOpsService.Projects(_settings.Organisation))?
                                                     .Value?
                                                     .FirstOrDefault(t => t.Name == _settings.TeamProject)?
                                                     .Id;

            // searchCriteria.sourceRepositoryId={repositoryId}&

            return await _proxy.GetAsync<ListResponse<GitPullRequest>>(
                $"https://dev.azure.com/{_settings.Organisation}/{idTeamProject}/_apis/git/pullrequests?api-version=6.0");
        }
    }
}
