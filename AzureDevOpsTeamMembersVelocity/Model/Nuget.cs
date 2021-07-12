using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AzureDevOpsTeamMembersVelocity.Model
{
    /// <summary>
    /// Represent a package nuget from the Azure DevOps REST API
    /// </summary>
    public class Nuget
    {
        public Guid Id { get; set; }

        public string? NormalizedName { get; set; }

        public string? Name { get; set; }

        /// <summary>
        /// Protocole type ex: nuget, npm, etc.
        /// </summary>
        public string? ProtocolType { get; set; }

        public string? Url { get; set; }

        public List<NugetVersion>? Versions { get; set; }

        [JsonPropertyName("_links")]
        public NugetLinks? Links { get; set; }
    }
}
