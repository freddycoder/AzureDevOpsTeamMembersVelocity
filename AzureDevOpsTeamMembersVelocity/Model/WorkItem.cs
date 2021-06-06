using System.Text.Json.Serialization;

namespace AzureDevOpsTeamMembersVelocity.Model
{
    /// <inheritdoc cref="Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.WorkItem" />
    public class WorkItem : Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.WorkItem
    {
        /// <inheritdoc cref="Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.WorkItemTrackingResource.Links" />
        [JsonPropertyName("_links")]
        public new WorkItemLinks? Links { get; set; }
    }
}
