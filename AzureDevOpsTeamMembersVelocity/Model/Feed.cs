using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AzureDevOpsTeamMembersVelocity.Model
{
    public class Feed
    {
        public string Description { get; set; }

        public string Url { get; set; }

        [JsonPropertyName("_links")]
        public FeedLinks Links { get; set; }

        public Guid DefaultViewId { get; set; }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool UpstreamEnabled { get; set; }

        public string ViewId { get; set; }

        public string ViewName { get; set; }

        public string FullyQualifiedName { get; set; }

        public Guid FullyQualifiedId { get; set; }

        public List<UpstreamResource> UpstreamSources { get; set; }

        public string Capabilities { get; set; }
    }
}
