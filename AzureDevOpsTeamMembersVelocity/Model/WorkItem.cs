using System.Text.Json.Serialization;

namespace AzureDevOpsTeamMembersVelocity.Model
{
    public class WorkItem : Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.WorkItem
    {
        [JsonPropertyName("_links")]
        public new WorkItemLinks? Links { get; set; }
    }
}
