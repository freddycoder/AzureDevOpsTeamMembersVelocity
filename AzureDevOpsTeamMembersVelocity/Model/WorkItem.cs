using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AzureDevOpsTeamMembersVelocity.Model
{
    /// <summary>
    /// WorkItem
    /// </summary>
    public class WorkItem
    {
        public Dictionary<string, object?> Fields { get; set; } = new Dictionary<string, object?>();

        /// <summary>
        /// Links
        /// </summary>
        [JsonPropertyName("_links")]
        public WorkItemLinks? Links { get; set; }
    }
}
