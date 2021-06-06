using AzureDevOpsTeamMembersVelocity.Model;
using AzureDevOpsTeamMembersVelocity.Proxy;
using Microsoft.TeamFoundation.Core.WebApi;
using System;
using System.Threading.Tasks;

namespace AzureDevOpsTeamMembersVelocity.Services
{
    public class DevOpsService
    {
        private readonly DevOpsProxy _proxy;

        public DevOpsService(DevOpsProxy proxy)
        {
            _proxy = proxy;
        }

        public Task<ListResponse<TeamProject>> Projects(string organisation)
        {
            return _proxy.GetAsync<ListResponse<TeamProject>>(
                $"https://dev.azure.com/{organisation}/_apis/projects");
        }

        public Task<ListResponse<WebApiTeam>> Teams(string organisation, Guid teamProjectId)
        {
            return _proxy.GetAsync<ListResponse<WebApiTeam>>(
                $"https://dev.azure.com/{organisation}/_apis/projects/{teamProjectId}/teams?api-version=6.0");
        }

        public Task<TeamDaysOff> TeamDaysOff(string teamIterationDaysOffUrl)
        {
            return _proxy.GetAsync<TeamDaysOff>(
                $"{teamIterationDaysOffUrl}?api-version=6.0");
        }

        public Task<TeamSettings> TeamSettings(string teamSettingsUrl)
        {
            return _proxy.GetAsync<TeamSettings>(
                $"{teamSettingsUrl}?api-version=6.0");
        }

        public Task<ListResponse<Sprint>> Sprints(string organization, string project, string team)
        {
            return _proxy.GetAsync<ListResponse<Sprint>>(
                $"https://dev.azure.com/{organization}/{project}/{team}/_apis/work/teamsettings/iterations?api-version=6.0");
        }

        public Task<Sprint> Sprint(string sprintUrl)
        {
            return _proxy.GetAsync<Sprint>($"{sprintUrl}?api-version=6.0");
        }

        public Task<ListResponse<Capacity>> Capacities(string capacityUrl)
        {
            return _proxy.GetAsync<ListResponse<Capacity>>(
                $"{capacityUrl}?api-version=6.0");
        }

        /// <summary>
        /// Get the list of work item links given the url of the sprint
        /// </summary>
        /// <param name="sprintUrl">The url of the sprint has returned by the <see cref="Sprints(string, string, string)" /> method/></param>
        /// <returns>A work item with details</returns>
        public Task<WorkItems> WorkItems(string sprintUrl)
        {
            return _proxy.GetAsync<WorkItems>(
                $"{sprintUrl}/workitems?api-version=6.0-preview.1");
        }

        public Task<WorkItem> WorkItem(string workItemUrl)
        {
            return _proxy.GetAsync<WorkItem>(workItemUrl);
        }

        public Task<ListResponse<WorkItemUpdate>> Updates(string updatesUrl)
        {
            return _proxy.GetAsync<ListResponse<WorkItemUpdate>>($"{updatesUrl}?api-version=6.0");
        }
    }
}
