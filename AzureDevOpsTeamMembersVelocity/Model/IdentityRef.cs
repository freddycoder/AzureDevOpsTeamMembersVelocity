using System.Text.Json.Serialization;

namespace AzureDevOpsTeamMembersVelocity.Model
{
    /// <inheritdoc cref="Microsoft.VisualStudio.Services.WebApi.IdentityRef" />
    public class IdentityRef : Microsoft.VisualStudio.Services.WebApi.IdentityRef
    {
        /// <inheritdoc cref="Microsoft.VisualStudio.Services.WebApi.IdentityRef.Descriptor" />
        [JsonPropertyName("descriptor")]
        public new string? Descriptor { get; set; }
    }
}
