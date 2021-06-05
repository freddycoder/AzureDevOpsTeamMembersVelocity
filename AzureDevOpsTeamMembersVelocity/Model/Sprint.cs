using System;
using System.Text.Json.Serialization;

namespace AzureDevOpsTeamMembersVelocity.Model
{
    public class Sprint
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public SprintAttribute Attributes { get; set; }
        public string Url { get; set; }

        [JsonPropertyName("_links")]
        public SprintLinks Links { get; set; }
    }
}
