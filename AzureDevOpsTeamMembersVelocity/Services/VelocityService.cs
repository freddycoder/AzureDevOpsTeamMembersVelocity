using AzureDevOpsTeamMembersVelocity.Extensions;
using AzureDevOpsTeamMembersVelocity.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AzureDevOpsTeamMembersVelocity.Services
{
    /// <summary>
    /// Service use to aggregate and group history of a sprint
    /// </summary>
    public class VelocityService
    {
        private readonly DevOpsService _devOpsService;

        /// <summary>
        /// Constructor with dependencies
        /// </summary>
        /// <param name="devOpsService">Instance of DevOpsService use to fetch data needed</param>
        public VelocityService(DevOpsService devOpsService)
        {
            _devOpsService = devOpsService;
        }

        /// <summary>
        /// Asynchronously enumerate each member's velocity. 
        /// Previously return member also updates if needed at each iteration.
        /// </summary>
        /// <param name="sprintUrl">Sprint to analyse</param>
        /// <param name="capacities">Capacities informations to enhance result</param>
        /// <param name="sprint">Sprint information is use to enhance result</param>
        /// <param name="teamDaysOff">Team days off is use to enhance result and do the right calculation</param>
        /// <param name="teamSettings">Team settings is use to enhance result and do the right calculation</param>
        /// <returns></returns>
        public async IAsyncEnumerable<MemberVelocity> MemberVelocities(string sprintUrl, List<Capacity>? capacities = null, Sprint? sprint = null, Microsoft.TeamFoundation.Work.WebApi.TeamSettingsDaysOff? teamDaysOff = null, Microsoft.TeamFoundation.Work.WebApi.TeamSetting? teamSettings = null)
        {
            var items = (await _devOpsService.WorkItems(sprintUrl))?.WorkItemRelations;

            if (items != null)
            {
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
        }

        private static MemberVelocity EnhanceMemberVolocityInfo(MemberVelocity velocity, List<Capacity>? capacities = null, Sprint? sprint = null, Microsoft.TeamFoundation.Work.WebApi.TeamSettingsDaysOff? teamDaysOff = null, Microsoft.TeamFoundation.Work.WebApi.TeamSetting? teamSettings = null)
        {
            if (capacities != default)
            {
                var capacity = capacities.FirstOrDefault(c => c.TeamMember?.DisplayName == velocity.DisplayName);

                if (capacity != null && sprint != null)
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
            if (double.TryParse(sx.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator), out var x))
            {
                return x;
            }

            return 0.0;
        }

        private async IAsyncEnumerable<(WorkItem, List<WorkItemUpdate>?)> GetWorksAndHistory(List<Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.WorkItemLink> items)
        {
            foreach (var item in items)
            {
                var result = await GetWorkItem(item);

                if (result != null)
                {
                    List<WorkItemUpdate>? workItemUpdate = default;

                    if (result.Links?.WorkItemUpdates?.Href != null)
                    {
                        workItemUpdate = (await _devOpsService.Updates(result.Links.WorkItemUpdates.Href))?.Value;
                    }

                    yield return (result, workItemUpdate);
                }
            }
        }

        private async Task<WorkItem?> GetWorkItem(Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.WorkItemLink workItem)
        {
            if (workItem.Source != null && workItem.Target != null)
            {
                return await _devOpsService.WorkItem(workItem.Target.Url);
            }

            return null;
        }

        /// <summary>
        /// Group the list of updates into the MemberVelocity object associate with the person name
        /// </summary>
        /// <param name="groupByPerson">Dictionary used to to the group by, can be pre-populated</param>
        /// <param name="workItem">Work item</param>
        /// <param name="workItemUpdates">List of updates to group</param>
        public static void GroupByPerson(Dictionary<string, MemberVelocity> groupByPerson, WorkItem workItem, List<WorkItemUpdate>? workItemUpdates)
        {
            if (workItemUpdates == null) return;

            foreach (var update in workItemUpdates)
            {
                var person = update.RevisedBy?.DisplayName ?? string.Empty;

                if (!groupByPerson.TryGetValue(person, out MemberVelocity? velocity))
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

                    if (update != null)
                    {
                        update.RelatedTaskTitle = workItem.Fields?.MaybeGet("System.Title")?.ToString();

                        velocity.Updates.Add(update);
                    }
                }
            }
        }
    }
}
