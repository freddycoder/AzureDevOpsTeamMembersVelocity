using System;
using System.Text.Json.Serialization;

namespace AzureDevOpsTeamMembersVelocity.Model
{
    /// <summary>
    /// Represent a git repository from the Azure DevOps REST API
    /// </summary>
    public class GitRepository
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Url
        /// </summary>
        public string? Url { get; set; }

        /// <summary>
        /// Links of resources related to the GitRepository
        /// </summary>
        [JsonPropertyName("_links")]
        public GitRepositoryLinks? Links { get; set; }
    }
}
