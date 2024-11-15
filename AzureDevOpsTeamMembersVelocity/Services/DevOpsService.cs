using AzureDevOpsTeamMembersVelocity.Model;
using AzureDevOpsTeamMembersVelocity.Proxy;
using System;
using System.Threading.Tasks;

namespace AzureDevOpsTeamMembersVelocity.Services
{
    /// <summary>
    /// Classed used to call and deserialize resource from the Azure DevOps REST API
    /// </summary>
    public class DevOpsService
    {
        private readonly IDevOpsProxy _proxy;

        /// <summary>
        /// Constructor with dependencies
        /// </summary>
        /// <param name="proxy">The proxy used to call the REST API</param>
        public DevOpsService(IDevOpsProxy proxy)
        {
            _proxy = proxy;
        }

        /// <summary>
        /// Get the list of projects of an organization.
        /// </summary>
        /// <remarks>
        /// See microsoft doc : https://docs.microsoft.com/en-us/rest/api/azure/devops/core/projects/list?view=azure-devops-rest-6.0
        /// </remarks>
        /// <param name="organization">Name of the organization. https://dev.azure.com/{organization}</param>
        /// <returns>List of TeamProject</returns>
        public Task<(ListResponse<TeamProject>?, string?)> Projects(string organization)
        {
            return _proxy.GetAsync<ListResponse<TeamProject>>(
                $"https://dev.azure.com/{organization}/_apis/projects?api-version=6.0");
        }

        /// <summary>
        /// Return the list of Teams of an organization TeamProject
        /// </summary>
        /// <param name="organization">Name of the organization. https://dev.azure.com/{organization}</param>
        /// <param name="teamProjectId">Id of the organization team project selected</param>
        /// <returns>List of teams</returns>
        public Task<(ListResponse<WebApiTeam>?, string?)> Teams(string organization, Guid teamProjectId)
        {
            return _proxy.GetAsync<ListResponse<WebApiTeam>>(
                $"https://dev.azure.com/{organization}/_apis/projects/{teamProjectId}/teams?api-version=6.0");
        }

        /// <summary>
        /// Get team days off from the teamIterationDaysOffUrl passed and deserialize the response.
        /// </summary>
        /// <remarks>
        /// The api-version used is 6.0, and the caller is not expected to specify the version in the URL.
        /// </remarks>
        /// <param name="teamIterationDaysOffUrl">URL of team days off to fetch</param>
        public Task<(TeamSettingsDaysOff?, string?)> TeamDaysOff(string teamIterationDaysOffUrl)
        {
            return _proxy.GetAsync<TeamSettingsDaysOff>(
                $"{teamIterationDaysOffUrl}?api-version=6.0");
        }

        /// <summary>
        /// Get Team Settings given a team settings URL
        /// </summary>
        /// <remarks>
        /// api-version 6.0 is used
        /// </remarks>
        /// <param name="teamSettingsUrl">The teamSettings full URL without the api-version</param>
        /// <returns>The teamSetting instance</returns>
        public Task<(TeamSetting?, string?)> TeamSettings(string teamSettingsUrl)
        {
            return _proxy.GetAsync<TeamSetting>(
                $"{teamSettingsUrl}?api-version=6.0");
        }

        /// <summary>
        /// Get the list of sprints of a team.
        /// </summary>
        /// <param name="organization">Name of the organisation. https://dev.azure.com/{organisation}</param>
        /// <param name="project"></param>
        /// <param name="team"></param>
        /// <returns></returns>
        public Task<(ListResponse<Sprint>?, string?)> Sprints(string organization, string project, string team)
        {
            return _proxy.GetAsync<ListResponse<Sprint>>(
                $"https://dev.azure.com/{organization}/{project}/{team}/_apis/work/teamsettings/iterations?api-version=6.0");
        }

        /// <summary>
        /// Get the sprint given a full URL
        /// </summary>
        /// <remarks>
        /// api-version 6.0 is used
        /// </remarks>
        /// <param name="sprintUrl">The full URL of the sprint.</param>
        /// <returns>The instance of the sprint</returns>
        public Task<(Sprint?, string?)> Sprint(string sprintUrl)
        {
            return _proxy.GetAsync<Sprint>($"{sprintUrl}?api-version=6.0");
        }

        /// <summary>
        /// Get the capacity of a sprint given a full URL
        /// </summary>
        /// <remarks>
        /// api-version 6.0 is used
        /// </remarks>
        /// <param name="capacityUrl">The full URL of the capacity information.</param>
        /// <returns>The list of capacities</returns>
        public Task<(ListResponse<TeamMemberCapacityIdentityRef>?, string?)> Capacities(string capacityUrl)
        {
            return _proxy.GetAsync<ListResponse<TeamMemberCapacityIdentityRef>>(
                $"{capacityUrl}?api-version=6.0");
        }

        /// <summary>
        /// Get the list of work item links given the URL of the sprint.
        /// </summary>
        /// <param name="sprintUrl">The URL of the sprint has returned by the <see cref="Sprints(string, string, string)" /> method/></param>
        /// <returns>A work item with details</returns>
        public Task<(WorkItems?, string?)> WorkItems(string sprintUrl)
        {
            return _proxy.GetAsync<WorkItems>(
                $"{sprintUrl}/workitems?api-version=6.0-preview.1");
        }

        /// <summary>
        /// Get a workItem given a workItemUrl
        /// </summary>
        /// <param name="workItemUrl">workItem fullUrl</param>
        /// <returns>The WorkItem deserialized</returns>
        public Task<(WorkItem?, string?)> WorkItem(string workItemUrl)
        {
            return _proxy.GetAsync<WorkItem>($"{workItemUrl}?api-version=6.0");
        }

        /// <summary>
        /// Get the list of updates from the updatesUrl passed and deserialize the response.
        /// </summary>
        /// <remarks>
        /// The api-version used is 6.0, and the caller is not expected to specify the version in the URL.
        /// </remarks>
        /// <param name="updatesUrl">URL of updates to fetch</param>
        public Task<(ListResponse<WorkItemUpdate>?, string?)> Updates(string updatesUrl)
        {
            return _proxy.GetAsync<ListResponse<WorkItemUpdate>>($"{updatesUrl}?api-version=6.0");
        }
    }
}
