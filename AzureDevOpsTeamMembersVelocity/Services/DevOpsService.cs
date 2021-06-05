using AzureDevOpsTeamMembersVelocity.Model;
using AzureDevOpsTeamMembersVelocity.Proxy;
using Microsoft.TeamFoundation.Core.WebApi;
using Microsoft.TeamFoundation.Work.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using System;
using System.Collections.Generic;
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

        public async Task<List<TeamProject>> Projects(string organisation)
        {
            var list = await _proxy.GetAsync<ListResponse<TeamProject>>(
                $"https://dev.azure.com/{organisation}/_apis/projects");

            Console.WriteLine(list?.Count);
            Console.WriteLine(list?.Value);

            return list.Value;
        }

        public async Task<List<WebApiTeam>> Teams(string organisation, Guid teamProjectId)
        {
            var list = await _proxy.GetAsync<ListResponse<WebApiTeam>>(
                $"https://dev.azure.com/{organisation}/_apis/projects/{teamProjectId}/teams?api-version=6.0");

            Console.WriteLine(list?.Count);
            Console.WriteLine(list?.Value);

            return list.Value;
        }

        public async Task<List<Sprint>> Sprints(string organization, string project, string team)
        {
            var list = await _proxy.GetAsync<ListResponse<Sprint>>(
                $"https://dev.azure.com/{organization}/{project}/{team}/_apis/work/teamsettings/iterations?api-version=6.0");

            Console.WriteLine(list?.Count);
            Console.WriteLine(list?.Value);

            return list?.Value;
        }

        /// <summary>
        /// Get the list of work item links given the url of the sprint
        /// </summary>
        /// <param name="sprintUrl">The url of the sprint has returned by the <see cref="Sprints(string, string, string)" /> method/></param>
        /// <returns>A work item with details</returns>
        public async Task<WorkItems> WorkItems(string sprintUrl)
        {
            var list = await _proxy.GetAsync<WorkItems>(
                $"{sprintUrl}/workitems?api-version=6.0-preview.1");

            Console.WriteLine(list?.Url);
            Console.WriteLine(list?.WorkItemRelations);

            return list;
        }

        public async Task<WorkItem> WorkItem(string workItemUrl)
        {
            var workItem = await _proxy.GetAsync<WorkItem>(workItemUrl);

            Console.WriteLine(workItem);

            return workItem;
        }

        public async Task<List<WorkItemUpdate>> Updates(string updatesUrl)
        {
            var list = await _proxy.GetAsync<ListResponse<WorkItemUpdate>>($"{updatesUrl}?api-version=6.0");

            Console.WriteLine(list?.Count);
            Console.WriteLine(list?.Value);

            return list.Value;
        }
    }
}
