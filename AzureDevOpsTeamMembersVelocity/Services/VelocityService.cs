﻿using AzureDevOpsTeamMembersVelocity.Extensions;
using AzureDevOpsTeamMembersVelocity.Model;
using AzureDevOpsTeamMembersVelocity.Repository;
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
        private readonly IVelocityRepository _repo;

        /// <summary>
        /// Constructor with dependencies
        /// </summary>
        /// <param name="devOpsService">Instance of DevOpsService use to fetch data needed</param>
        /// <param name="velocityRepository">The velocity repository to store and retrive calculated results</param>
        public VelocityService(DevOpsService devOpsService, IVelocityRepository velocityRepository)
        {
            _devOpsService = devOpsService;
            _repo = velocityRepository;
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
        /// <param name="useCache">Indicate if the value can be get from memory or the results is calculated</param>
        /// <returns></returns>
        public async IAsyncEnumerable<MemberVelocity> MemberVelocities(string sprintUrl, List<Microsoft.TeamFoundation.Work.WebApi.TeamMemberCapacityIdentityRef>? capacities = null, Sprint? sprint = null, Microsoft.TeamFoundation.Work.WebApi.TeamSettingsDaysOff? teamDaysOff = null, Microsoft.TeamFoundation.Work.WebApi.TeamSetting? teamSettings = null, bool useCache = true)
        {
            if (useCache && _repo.TryGet(sprintUrl, out IEnumerable<MemberVelocity>? memberVelocities) && memberVelocities != null)
            {
                foreach (var memberVelocity in memberVelocities)
                {
                    yield return memberVelocity;
                }
            }
            else
            {
                var workItems = (await _devOpsService.WorkItems(sprintUrl)).Item1?.WorkItemRelations;

                if (workItems != null)
                {
                    var personDictionary = new Dictionary<string, MemberVelocity>();

                    await foreach (var (workItem, workItemUpdates) in GetWorksAndHistory(workItems))
                    {
                        GroupByPerson(personDictionary, workItem, workItemUpdates, sprint);

                        foreach (var value in personDictionary.Values)
                        {
                            yield return EnhanceMemberVolocityInfo(value, capacities, sprint, teamDaysOff, teamSettings);
                        }
                    }
                }
            }
        }

        private static MemberVelocity EnhanceMemberVolocityInfo(MemberVelocity velocity, List<Microsoft.TeamFoundation.Work.WebApi.TeamMemberCapacityIdentityRef>? capacities = null, Sprint? sprint = null, Microsoft.TeamFoundation.Work.WebApi.TeamSettingsDaysOff? teamDaysOff = null, Microsoft.TeamFoundation.Work.WebApi.TeamSetting? teamSettings = null)
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
                var workItem = await GetWorkItem(item);

                if (workItem != null)
                {
                    List<WorkItemUpdate>? workItemUpdate = default;

                    if (workItem.Links?.WorkItemUpdates?.Href != null)
                    {
                        workItemUpdate = (await _devOpsService.Updates(workItem.Links.WorkItemUpdates.Href)).Item1?.Value;
                    }

                    yield return (workItem, workItemUpdate);
                }
            }
        }

        private async Task<WorkItem?> GetWorkItem(Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.WorkItemLink workItem)
        {
            if (workItem.Source != null && workItem.Target != null)
            {
                return (await _devOpsService.WorkItem(workItem.Target.Url)).Item1;
            }

            return null;
        }

        /// <summary>
        /// Group the list of updates into the MemberVelocity object associate with the person name
        /// </summary>
        /// <param name="groupByPerson">Dictionary used to to the group by, can be pre-populated</param>
        /// <param name="workItem">Work item</param>
        /// <param name="workItemUpdates">List of updates to group</param>
        /// <param name="sprint">The sprint fi available to not consider change history that append in others sprints</param>
        public static void GroupByPerson(Dictionary<string, MemberVelocity> groupByPerson, WorkItem workItem, List<WorkItemUpdate>? workItemUpdates, Sprint? sprint = null)
        {
            if (workItemUpdates == null) return;

            foreach (var update in workItemUpdates.Where(w => sprint?.Attributes?.StartDate == null ||       // Filter to get only changes
                                                              sprint.Attributes.StartDate <= w.RevisedDate)) // where the change append after
                                                                                                             // the begining of the sprint
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

                    if (delta < 0)
                    {
                        velocity.HoursAdded += Math.Abs(delta);
                    }
                    else
                    {
                        velocity.HoursRemoved += delta;
                    }

                    if (update != null)
                    {
                        update.RelatedTaskTitle = workItem.Fields?.MaybeGet("System.Title")?.ToString();

                        velocity.Updates.Add(update);
                    }
                }
            }
        }

        /// <summary>
        /// Store the member velocities associate with a strintUrl
        /// </summary>
        /// <param name="sprintUrl"></param>
        /// <param name="memberVelocities"></param>
        public void SaveVelocity(string sprintUrl, IEnumerable<MemberVelocity> memberVelocities)
        {
            _repo.Save(sprintUrl, memberVelocities);
        }
    }
}
