using AzureDevOpsTeamMembersVelocity.Extensions;
using AzureDevOpsTeamMembersVelocity.Model;
using System;
using System.Collections.Generic;
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

        public async IAsyncEnumerable<MemberVelocity> MemberVelocities(string sprintUrl, List<Capacity> capacities = null, Sprint sprint = null, TeamDaysOff teamDaysOff = null, TeamSettings teamSettings = null)
        {
            var items = (await _devOpsService.WorkItems(sprintUrl)).WorkItemRelations;

            var groupByPerson = new Dictionary<string, MemberVelocity>();

            await foreach (var (workItem, workItemUpdates) in GetWorksAndHistory(items))
            {
                GroupByPerson(groupByPerson, workItem, workItemUpdates);

                foreach (var value in groupByPerson.Values)
                {
                    yield return EnhanceMemberVolocityInfo(value, capacities, sprint, teamDaysOff, teamSettings);
                }
            }
        }

        private static MemberVelocity EnhanceMemberVolocityInfo(MemberVelocity velocity, List<Capacity> capacities = null, Sprint sprint = null, TeamDaysOff teamDaysOff = null, TeamSettings teamSettings = null)
        {
            if (capacities != default)
            {
                var capacity = capacities.FirstOrDefault(c => c.TeamMember.DisplayName == velocity.DisplayName);

                if (capacity != null)
                {
                    if (capacity.Activities?.Any() == true)
                        velocity.CapacitySaved = capacity.Activities.Select(a => (double)a.CapacityPerDay).Sum();

                    if (sprint.Attributes?.StartDate != null &&
                        sprint.Attributes.StartDate < DateTimeOffset.Now &&
                        sprint.Attributes?.FinishDate != null)
                    {
                        var nbDayOfWork = sprint.GetTotalWorkingDays(teamSettings?.WorkingDays, teamDaysOff);

                        if (capacity.DaysOff?.Any() == true)
                            nbDayOfWork -= capacity.DaysOff.Select(d => (d.End - d.Start).TotalDays).Sum();

                        if (nbDayOfWork != 0)
                            velocity.RealCapacity = velocity.HoursOfWorkDone / nbDayOfWork;
                    }
                }
            }

            return velocity;
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

        private async IAsyncEnumerable<(WorkItem, List<WorkItemUpdate>)> GetWorksAndHistory(List<Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.WorkItemLink> items)
        {
            foreach (var item in items)
            {
                var result = await GetWorkItem(item);

                if (result != null)
                {
                    List<WorkItemUpdate> workItemUpdate = default;

                    if (result.Links?.WorkItemUpdates?.Href != null)
                    {
                        workItemUpdate = (await _devOpsService.Updates(result.Links.WorkItemUpdates.Href))?.Value;
                    }

                    yield return (result, workItemUpdate);
                }
            }
        }

        private async Task<WorkItem> GetWorkItem(Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.WorkItemLink workItem)
        {
            if (workItem.Source != null && workItem.Target != null)
            {
                return await _devOpsService.WorkItem(workItem.Target.Url);
            }

            return null;
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
    }
}
