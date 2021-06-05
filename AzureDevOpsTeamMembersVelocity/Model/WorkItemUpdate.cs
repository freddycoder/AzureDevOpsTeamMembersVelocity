using System;

namespace AzureDevOpsTeamMembersVelocity.Model
{
    public class WorkItemUpdate : Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.WorkItemUpdate, IComparable<WorkItemUpdate>
    {
        public new IdentityReference RevisedBy { get; set; }

        public string RelatedTaskTitle { get; set; }

        public int CompareTo(WorkItemUpdate other)
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
