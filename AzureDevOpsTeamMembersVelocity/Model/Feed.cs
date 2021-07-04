using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AzureDevOpsTeamMembersVelocity.Model
{
    /// <summary>
    /// Represent a feed from the azure DevOps REST API
    /// </summary>
    public class Feed
    {
        /// <summary>
        /// Description of the feed
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// The URL of the feed
        /// </summary>
        public string? Url { get; set; }

        [JsonPropertyName("_links")]
        public FeedLinks? Links { get; set; }

        public Guid DefaultViewId { get; set; }

        public Guid Id { get; set; }

        public string? Name { get; set; }

        public bool UpstreamEnabled { get; set; }

        public string? ViewId { get; set; }

        public string? ViewName { get; set; }

        /// <summary>
        /// The fully qualified name of the feed
        /// </summary>
        public string? FullyQualifiedName { get; set; }

        /// <summary>
        /// The fully qualified id of the feed
        /// </summary>
        public Guid FullyQualifiedId { get; set; }

        /// <summary>
        /// List of upstream sources
        /// </summary>
        public List<UpstreamResource>? UpstreamSources { get; set; }

        /// <summary>
        /// Capabilities of the feed
        /// </summary>
        public string? Capabilities { get; set; }
    }
}
