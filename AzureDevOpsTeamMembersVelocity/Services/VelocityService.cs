using AzureDevOpsTeamMembersVelocity.Extensions;
using AzureDevOpsTeamMembersVelocity.Model;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AzureDevOpsTeamMembersVelocity.Services
{
    public class VelocityService
    {
        private readonly DevOpsService _devOpsService;

        public VelocityService(DevOpsService devOpsService)
        {
            _devOpsService = devOpsService;
        }

        public async Task<List<MemberVelocity>> MemberVelocities(string sprintUrl)
        {
            var items = (await _devOpsService.WorkItems(sprintUrl)).WorkItemRelations;

            var (workItems, workItemUpdates) = await GetWorksAndHistory(items);

            Debug.Assert(workItems.Count == workItemUpdates.Count, "List must be the same size");

            var groupByPerson = new Dictionary<string, MemberVelocity>();

            for (int i = 0; i < workItems.Count; i++)
            {
                if (workItemUpdates[i] != null)
                    GroupByPerson(groupByPerson, workItems[i], workItemUpdates[i]);
            }

            return groupByPerson.Values.OrderBy(m => m.HoursOfWorkDone).ToList();
        }

        public static void GroupByPerson(Dictionary<string, MemberVelocity> groupByPerson, WorkItem workItem, List<WorkItemUpdate> workItemUpdates)
        {
            foreach (var update in workItemUpdates)
            {
                var person = update.RevisedBy?.DisplayName ?? string.Empty;

                if (!groupByPerson.TryGetValue(person, out MemberVelocity velocity))
                {
                    velocity = new MemberVelocity
                    {
                        DisplayName = person
                    };

                    groupByPerson.Add(person, velocity);
                }

                var remaningWork = update?.Fields?.MaybeGet<string, Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.WorkItemFieldUpdate>
                    ("Microsoft.VSTS.Scheduling.RemainingWork");

                if (remaningWork?.OldValue != null)
                {
                    var delta = GetDelta(remaningWork.OldValue, remaningWork.NewValue);

                    velocity.HoursOfWorkDone += delta;

                    update.RelatedTaskTitle = workItem.Fields?.MaybeGet("System.Title")?.ToString();

                    velocity.Updates.Add(update);
                }
            }
        }

        private static double GetDelta(object oldValue, object newValue)
        {
            var sx = oldValue?.ToString() ?? "";
            var sy = newValue?.ToString() ?? "";

            var x = Parse(sx);
            var y = Parse(sy);

            return x - y;
        }

        private static double Parse(string sx)
        {
            if (double.TryParse(sx.Replace(".", ","), out var x))
            {
                return x;
            }

            return 0.0;
        }

        private async Task<(List<WorkItem>, List<List<WorkItemUpdate>>)> GetWorksAndHistory(List<Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.WorkItemLink> items)
        {
            var workItems = new List<WorkItem>();

            var workItemUpdates = new List<List<WorkItemUpdate>>(items.Count);

            foreach (var item in items)
            {
                var result = await GetWorkItem(item);

                if (result != null)
                {
                    workItems.Add(result);

                    if (result.Links?.WorkItemUpdates?.Href != null)
                    {
                        workItemUpdates.Add(await GetWorkItemUpdate(result.Links.WorkItemUpdates.Href));
                    }
                    else
                    {
                        workItemUpdates.Add(null);
                    }
                }
            }

            return (workItems, workItemUpdates);
        }

        private async Task<WorkItem> GetWorkItem(Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.WorkItemLink workItem)
        {
            if (workItem.Source != null && workItem.Target != null)
            {
                return await _devOpsService.WorkItem(workItem.Target.Url);
            }

            return null;
        }

        private Task<List<WorkItemUpdate>> GetWorkItemUpdate(string updatesLink)
        {
            return _devOpsService.Updates(updatesLink);
        }
    }
}
