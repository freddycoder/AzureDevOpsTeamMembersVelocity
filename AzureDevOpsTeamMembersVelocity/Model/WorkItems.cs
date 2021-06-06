using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using System.Collections.Generic;

namespace AzureDevOpsTeamMembersVelocity.Model
{
    /// <summary>
    /// A work item graph
    /// </summary>
    public class WorkItems
    {
        /// <summary>
        /// Work item URL
        /// </summary>
        public string? Url { get; set; }

        /// <summary>
        /// List of related work item
        /// </summary>
        public List<WorkItemLink>? WorkItemRelations { get; set; }
    }
}
