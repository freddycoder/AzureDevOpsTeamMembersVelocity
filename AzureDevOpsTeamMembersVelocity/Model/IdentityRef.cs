using System.Text.Json.Serialization;

namespace AzureDevOpsTeamMembersVelocity.Model
{
    public class IdentityRef : Microsoft.VisualStudio.Services.WebApi.IdentityRef
    {
        [JsonPropertyName("descriptor")]
        public new string? Descriptor { get; set; }
    }
}
