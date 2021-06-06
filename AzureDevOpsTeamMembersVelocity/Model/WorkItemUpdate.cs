using System;

namespace AzureDevOpsTeamMembersVelocity.Model
{
    /// <inheritdoc cref="Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.WorkItemUpdate"/>
    public class WorkItemUpdate : Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.WorkItemUpdate, IComparable<WorkItemUpdate>
    {
        /// <inheritdoc cref="Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.WorkItemUpdate.RevisedBy"/>
        public new IdentityReference? RevisedBy { get; set; }

        /// <summary>
        /// The title of the associate WorkItem. 
        /// </summary>
        /// <remarks>
        /// Must be managed by the program logic. 
        /// This data is not in the response of Azure DevOps REST API.
        /// </remarks>
        public string? RelatedTaskTitle { get; set; }

        /// <summary>
        /// Compare a WorkItemUpdate base on the RelatedTaskTitle and if the save
        /// the RevisedDate
        /// </summary>
        public int CompareTo(WorkItemUpdate? other)
        {
            if (other == null) return 1;

            var initial = string.Compare(RelatedTaskTitle, other.RelatedTaskTitle);

            if (initial == 0)
            {
                return RevisedDate.CompareTo(other.RevisedDate);
            }

            return initial;
        }
    }
}
