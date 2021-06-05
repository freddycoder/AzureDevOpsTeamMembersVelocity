using AzureDevOpsTeamMembersVelocity.Model;
using AzureDevOpsTeamMembersVelocity.Proxy;
using Microsoft.Extensions.Logging;
using Microsoft.TeamFoundation.Core.WebApi;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureDevOpsTeamMembersVelocity.Services
{
    public class DevOpsService
    {
        private readonly DevOpsProxy _proxy;
        private readonly ILogger<DevOpsService> _logger;

        public DevOpsService(DevOpsProxy proxy, ILogger<DevOpsService> logger)
        {
            _proxy = proxy;
            _logger = logger;
        }

        public async Task<List<TeamProject>> Projects(string organisation)
        {
            var list = await _proxy.GetAsync<ListResponse<TeamProject>>(
                $"https://dev.azure.com/{organisation}/_apis/projects");

            _logger.LogDebug(list?.Count.ToString());
            _logger.LogDebug(list?.Value?.ToString());

            return list?.Value;
        }

        public async Task<List<WebApiTeam>> Teams(string organisation, Guid teamProjectId)
        {
            var list = await _proxy.GetAsync<ListResponse<WebApiTeam>>(
                $"https://dev.azure.com/{organisation}/_apis/projects/{teamProjectId}/teams?api-version=6.0");

            _logger.LogDebug(list?.Count.ToString());
            _logger.LogDebug(list?.Value?.ToString());

            return list?.Value;
        }

        public async Task<TeamDaysOff> TeamDaysOff(string teamIterationDaysOffUrl)
        {
            var teamDaysOff = await _proxy.GetAsync<TeamDaysOff>(
                $"{teamIterationDaysOffUrl}?api-version=6.0");

            _logger.LogDebug(teamDaysOff?.ToString());

            return teamDaysOff;
        }

        public async Task<List<Sprint>> Sprints(string organization, string project, string team)
        {
            var list = await _proxy.GetAsync<ListResponse<Sprint>>(
                $"https://dev.azure.com/{organization}/{project}/{team}/_apis/work/teamsettings/iterations?api-version=6.0");

            _logger.LogDebug(list?.Count.ToString());
            _logger.LogDebug(list?.Value?.ToString());

            return list?.Value;
        }

        public async Task<Sprint> Sprint(string sprintUrl)
        {
            var sprint = await _proxy.GetAsync<Sprint>($"{sprintUrl}?api-version=6.0");

            _logger.LogDebug(sprint?.ToString());

            return sprint;
        }

        public async Task<List<Capacity>> Capacities(string capacityUrl)
        {
            var capacity = await _proxy.GetAsync<ListResponse<Capacity>>(
                $"{capacityUrl}?api-version=6.0");

            _logger.LogDebug(capacity?.Count.ToString());
            _logger.LogDebug(capacity?.Value?.ToString());

            return capacity?.Value;
        }

        /// <summary>
        /// Get the list of work item links given the url of the sprint
        /// </summary>
        /// <param name="sprintUrl">The url of the sprint has returned by the <see cref="Sprints(string, string, string)" /> method/></param>
        /// <returns>A work item with details</returns>
        public async Task<WorkItems> WorkItems(string sprintUrl)
        {
            var workItems = await _proxy.GetAsync<WorkItems>(
                $"{sprintUrl}/workitems?api-version=6.0-preview.1");

            _logger.LogDebug(workItems?.Url?.ToString());
            _logger.LogDebug(workItems?.WorkItemRelations?.ToString());

            return workItems;
        }

        public async Task<WorkItem> WorkItem(string workItemUrl)
        {
            var workItem = await _proxy.GetAsync<WorkItem>(workItemUrl);

            _logger.LogDebug(workItem?.ToString());

            return workItem;
        }

        public async Task<List<WorkItemUpdate>> Updates(string updatesUrl)
        {
            var list = await _proxy.GetAsync<ListResponse<WorkItemUpdate>>($"{updatesUrl}?api-version=6.0");

            _logger.LogDebug(list?.Count.ToString());
            _logger.LogDebug(list?.Value?.ToString());

            return list?.Value;
        }
    }
}
