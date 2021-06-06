using System.Text.Json.Serialization;

namespace AzureDevOpsTeamMembersVelocity.Model
{
    /// <inheritdoc cref="Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.IdentityReference"></inheritdoc>
    public class IdentityReference : Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.IdentityReference
    {
        /// <summary>
        /// The descriptor field in the REST response
        /// </summary>
        [JsonPropertyName("descriptor")]
        public new string? Descriptor { get; set; }
    }
}