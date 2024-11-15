using System;
using System.Collections.Generic;

namespace AzureDevOpsTeamMembersVelocity.Model
{
    /// <summary>
    /// WorkItemUpdate
    /// </summary>
    public class WorkItemUpdate : IComparable<WorkItemUpdate>
    {
        /// <summary>
        /// The title of the associate WorkItem. 
        /// </summary>
        /// <remarks>
        /// Must be managed by the program logic. 
        /// This data is not in the response of Azure DevOps REST API.
        /// </remarks>
        public string? RelatedTaskTitle { get; set; }

        /// <summary>
        /// The date of the last update of the WorkItem
        /// </summary>
        public DateTimeOffset RevisedDate { get; set; }

        /// <summary>
        /// RevisedBy
        /// </summary>
        public UserObj? RevisedBy { get; set; }

        /// <summary>
        /// Url
        /// </summary>
        public string Url { get; set; } = string.Empty;

        /// <summary>
        /// CreationDate
        /// </summary>
        public DateTimeOffset CreationDate { get; set; }

        /// <summary>
        /// Fields
        /// </summary>
        public Dictionary<string, WorkItemFieldUpdate>? Fields { get; set; }

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

    /// <summary>
    /// UserObj
    /// </summary>
    public class UserObj
    {
        /// <summary>
        /// DisplayName
        /// </summary>
        public string? DisplayName { get; set; }
    }
}
