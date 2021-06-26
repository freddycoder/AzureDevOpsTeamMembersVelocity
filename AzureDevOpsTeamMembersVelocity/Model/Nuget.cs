using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AzureDevOpsTeamMembersVelocity.Model
{
    public class Nuget
    {
        public Guid Id { get; set; }

        public string? NormalizedName { get; set; }

        public string? Name { get; set; }

        public string? ProtocolType { get; set; }

        public string? Url { get; set; }

        public List<NugetVersion>? Versions { get; set; }

        [JsonPropertyName("_links")]
        public NugetLinks? Links { get; set; }
    }
}
