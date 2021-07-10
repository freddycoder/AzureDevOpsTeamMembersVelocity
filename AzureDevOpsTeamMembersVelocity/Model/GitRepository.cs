using System.Text.Json.Serialization;

namespace AzureDevOpsTeamMembersVelocity.Model
{
    /// <summary>
    /// Represent a git repository from the Azure DevOps REST API
    /// </summary>
    public class GitRepository : Microsoft.TeamFoundation.SourceControl.WebApi.GitRepository
    {
        /// <summary>
        /// Links of resources related to the GitRepository
        /// </summary>
        [JsonPropertyName("_links")]
        public new GitRepositoryLinks? Links { get; set; }
    }
}
