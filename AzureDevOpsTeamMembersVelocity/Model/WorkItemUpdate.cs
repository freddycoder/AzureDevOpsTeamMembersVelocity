using System.Text.Json.Serialization;

namespace AzureDevOpsTeamMembersVelocity.Model
{
    public class WorkItemUpdate : Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.WorkItemUpdate
    {
        public new IdentityReference RevisedBy { get; set; }

        public string RelatedTaskTitle { get; set; }
    }
}
