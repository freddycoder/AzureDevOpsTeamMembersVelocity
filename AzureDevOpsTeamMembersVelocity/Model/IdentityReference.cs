using System.Text.Json.Serialization;

namespace AzureDevOpsTeamMembersVelocity.Model
{
    public class IdentityReference : Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.IdentityReference
    {
        [JsonPropertyName("descriptor")]
        public new string? Descriptor { get; set; }
    }
}