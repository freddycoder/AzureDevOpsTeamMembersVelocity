using System.Text.Json.Serialization;

namespace AzureDevOpsTeamMembersVelocity.Model
{
    public class GitRepository : Microsoft.TeamFoundation.SourceControl.WebApi.GitRepository
    {
        [JsonPropertyName("_links")]
        public new GitRepositoryLinks Links { get; set; }
    }
}
